
using System.ComponentModel.DataAnnotations;

namespace Show_project.Models
{
    public class Furniture
    {
        [Key]
        public int FurnitureId { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string Color { get; set; }

        public string Type { get; set; }

        public Category Category { get; set; }

    }
}