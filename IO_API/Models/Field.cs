using System.ComponentModel.DataAnnotations;

namespace IO_API.Models
{
    public class Field
    {
        public int ID { get; set; }
        public Building? PlacedBuilding { get; set; }
    }
}
