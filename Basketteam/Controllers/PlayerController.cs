using Basketteam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using static Basketteam.Models.Dto;

namespace Basketteam.Controllers
{
    [Route("player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        [HttpPost]
        public ActionResult<Player> Post(CreatePlayerDto createPlayerDto)
        {
            using (var context = new BasketteamContext())
            {
                var player = new Player
                {
                    Id = Guid.NewGuid(),
                    Name = createPlayerDto.Name,
                    Weight = createPlayerDto.Weight,
                    Height = createPlayerDto.Height,
                    CreatedTime = DateTime.Now,
                };
                if (player != null)
                {
                    context.Players.Add(player);
                    context.SaveChanges();
                    return StatusCode(201, player);
                    
                }
                else
                {
                    return BadRequest();
                }
            }
        }
        [HttpGet]
        public ActionResult<Player> Get()
        {
            using (var context = new BasketteamContext())
            {
                return Ok(context.Players.ToList());
            }

        }

        [HttpPut]
        public ActionResult<Player> Put(Guid Id, UpdatedPlayerDto updateplayerDto)
        {
            using (var context = new BasketteamContext())
            {
                var existingPlayer = context.Players.FirstOrDefault(x => x.Id == Id);
                if (existingPlayer != null)
                {
                    existingPlayer.Name = updateplayerDto.Name;
                    context.Players.Update(existingPlayer);
                    context.SaveChanges();
                    return StatusCode(200);
                }
                return Ok();

            }
        }

        [HttpDelete]
        public ActionResult<object> Delete(Guid Id)
        {
            using (var context = new BasketteamContext())
            {
                var player = context.Players.FirstOrDefault(x => x.Id == Id);
                if (player != null)
                {
                    var player1 = new Player();
                    context.Players.Remove(player);
                    context.SaveChanges();
                    return StatusCode(200, new { message = "Sikeres törlés." });
                }
                return NotFound(new { message = "Sikertelen törlés." });
            }
        }
    }
   
    
}
