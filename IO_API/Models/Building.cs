using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IO_API.Models
{
    public class Building
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public int Level { get; set; }
        public int AccountingValue { get; set; }
        public int AccountedCoins { get; set; }
        public int NumberOfAccountings { get; set; }

    }
}
