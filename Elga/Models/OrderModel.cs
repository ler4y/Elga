using System.ComponentModel.DataAnnotations;

namespace Elga.Models
{
    public class OrderModel
    {
        [Required]
        public string Name { get; set; }
        public string Number { get; set; }
        public string University { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }
}