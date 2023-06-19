namespace RezerwacjeSalAB.Models
{
    public class Building
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Street { get; set; }
        public int? BuildingNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }

        public List<Room>? Rooms { get; set; }
    }
}