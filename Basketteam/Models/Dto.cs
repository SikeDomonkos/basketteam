namespace Basketteam.Models
{
    public class Dto
    {
        public record CreatePlayerDto(string Name ,int Height, int Weight, DateTime? Createdtime);

        public record UpdatedPlayerDto(string Name, int Height, int Weight, DateTime? UpdatedTime);

        public record CreateMatchDto(DateTime? SubIn,Guid PlayerId,int FGA, int FGM, int Foul,DateTime CreatedTime);

        public record UpdatedMatchDto(DateTime? SubOut, Guid PlayerId, int FGA, int FGM, int Foul, DateTime UpdatedTime);
    }
}
