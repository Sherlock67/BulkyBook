using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get;set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public string Isbn { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name = "List Price 1-50")]
        [Range(1,1000)]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }
    }
}
