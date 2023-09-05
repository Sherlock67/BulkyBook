
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Bulky.Models
{
    public class Category
    {
        
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(30)]
        public string CategoryName { get; set; }
        [Range(1,100,ErrorMessage ="Display order must be between 1-100")]  
        public int DisplayOrder { get; set; }
    }
}
