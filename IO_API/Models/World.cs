﻿using System.ComponentModel.DataAnnotations;

namespace IO_API.Models
{
    public class World
    {
        [Key]
        public int ID { get; set; }
        public string UserID { get; set; }
        public IList<BigField>? BigFields { get; set; }
    }
}
