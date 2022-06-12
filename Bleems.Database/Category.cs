using System.ComponentModel.DataAnnotations;

namespace Bleems.Database
{
    internal class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string CategoryName { get; set; }

    }
}
