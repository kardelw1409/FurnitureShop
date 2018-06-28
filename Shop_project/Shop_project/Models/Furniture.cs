using System.ComponentModel.DataAnnotations;

namespace Show_project.Models
{
    public class Furniture
    {
        [Key]
        public int FurnitureId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Color { get; set; }

        public int CategoryId { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public Category Category { get; set; }

    }
}