using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Expence
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
