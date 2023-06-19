namespace RezerwacjeSalAB.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int? Number { get; set; }
        public int? MaxPeopleCount { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Equipment>? Equipments { get; set; }
    }
}
