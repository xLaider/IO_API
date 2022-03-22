namespace IO_API.Models
{
    public class BuildingsShop
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public int AccountingValue { get; set; }
        public int PopulationValue { get; set; }
        public int PopulationNeeded { get; set; }
        public int Price { get; set; }
    }
}
