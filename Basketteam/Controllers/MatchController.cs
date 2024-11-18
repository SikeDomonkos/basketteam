using Basketteam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Text.RegularExpressions;
using static Basketteam.Models.Dto;

namespace Basketteam.Controllers
{
    [Route("Matchdatum")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Matchdatum> Post(CreateMatchDto createdMatch)
        {
            using (var context = new BasketteamContext())
            {
                var match = new Matchdatum
                {
                    SubIn = DateTime.Now,
                    PlayerId = Guid.NewGuid(),
                    Fga = createdMatch.FGA,
                    Fgm = createdMatch.FGM,
                    Foul = createdMatch.Foul,
                    CreatedTime = DateTime.Now,
                };
                if (match != null)
                {
                    context.Matchdata.Add(match);
                    context.SaveChanges();
                    return StatusCode(201, match);

                }
                else
                {
                    return BadRequest();
                }
            }


           
        }
        [HttpGet]
        public ActionResult<Match> Get()
        {
            using (var context = new BasketteamContext())
            {
                return Ok(context.Matchdata.ToList());
            }

        }
        [HttpPut]
        public ActionResult<Match> Put(Guid Id, UpdatedMatchDto updatedMatchDto)
        {
            using (var context = new BasketteamContext())
            {
                var existingMatch = context.Players.FirstOrDefault(x => x.Id == Id);
                if (existingMatch != null)
                {
                    
                    context.Players.Update(existingMatch);
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
                var match = context.Players.FirstOrDefault(x => x.Id == Id);
                if (match != null)
                {
                    var match1 = new Player();
                    context.Players.Remove(match1);
                    context.SaveChanges();
                    return StatusCode(200, new { message = "Sikeres törlés." });
                }
                return NotFound(new { message = "Sikertelen törlés." });
            }
        }


    }
}
