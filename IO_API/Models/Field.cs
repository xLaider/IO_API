using System.ComponentModel.DataAnnotations;

namespace IO_API.Models
{
    public class Field
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public Field? AdjacentField { get; set; }
        public string? DirectionOfAdjacency { get; set; }
        public Building? PlacedBuilding { get; set; }

    }
}
