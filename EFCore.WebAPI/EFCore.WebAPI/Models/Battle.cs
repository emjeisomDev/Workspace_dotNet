namespace EFCore.WebAPI.Models
{
    public class Battle
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Description { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
    }
}
