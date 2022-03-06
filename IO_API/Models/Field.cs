namespace IO_API.Models
{
    public class Field
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public int AdjacentFieldID { get; set; }
        public string DirectionOfAdjacency { get; set; } = string.Empty;
        public int BuildingID { get; set; }

    }
}
