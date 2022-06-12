using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bleems.Database
{
    internal class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId ")]
        public Category ProductCategory { get; set; }

        [MaxLength(100)]
        [Required]
        public string ProductName { get; set; }
        
        [MaxLength(200)]
        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public decimal ProductPrice { get; set; }
        
        [MaxLength(265)]
        public string ProductPhoto { get; set; }
        [MaxLength(265)]
        public string FileUrlBase { get; set; }

        internal string GetFullPhotoUrl()
        {
            return $"{FileUrlBase}/{ProductPhoto}";
        }

    }
}
