namespace Basketteam.Models
{
    public class Dto
    {
        public record CreatePlayerDto(string Name ,int Height, int Weight, DateTime? Createdtime);

        public record UpdatedPlayerDto(string Name, int Height, int Weight, DateTime? UpdatedTime);

        public record CreateMatchDto(DateTime? sub_in,DateTime? sub_out ,Guid PlayerId,int FGA, int FGM, int Foul,DateTime CreatedTime);

        public record UpdatedMatchDto(DateTime? sub_in, DateTime? sub_out, Guid PlayerId, int FGA, int FGM, int Foul, DateTime UpdatedTime);
    }
}
