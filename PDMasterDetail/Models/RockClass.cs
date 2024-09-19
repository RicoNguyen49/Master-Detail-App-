using System.ComponentModel.DataAnnotations;

namespace PDMasterDetail.Models
{
    public class RockClass
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Color { get; set; }
        public string? Location { get; set; }
        public int Hardness { get; set; }
    }
}
