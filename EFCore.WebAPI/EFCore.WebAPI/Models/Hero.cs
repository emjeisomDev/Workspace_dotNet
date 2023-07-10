namespace EFCore.WebAPI.Models
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Battle Battle { get; set; }
        public int BattleId { get; set; }
    }
}
