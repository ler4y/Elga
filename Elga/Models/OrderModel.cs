using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Elga.Models
{
    public class OrderModel
    {
        public OrderModel()
        {
            Files = new List<HttpPostedFileBase>();
        }
        [Required]
        public string Name { get; set; }
        public string Number { get; set; }
        public string University { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

        public List<HttpPostedFileBase> Files { get; set; }
    }
}