using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Bleems.Dev.Test.Models
{
    public class ProductNewModel
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        [Required(ErrorMessage ="Choose Category")]
        public int ProductCategoryId { get; set; }
        public IFormFile ProductPhoto { get; set; }
    }
}
