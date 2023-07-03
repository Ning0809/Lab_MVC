using System.ComponentModel.DataAnnotations;

namespace Lab_MVC.Models
{
    public class ProductDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
