using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Show_project.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите название категории")]
        [Display(Name = "Title")]
        [StringLength(50)]
        public string Title { get; set; }

    }
}