using System.ComponentModel.DataAnnotations;

namespace IO_API.Models
{
    public class World
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public IList<Field> Fields { get; set; }
    }
}
