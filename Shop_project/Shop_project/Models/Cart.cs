using Show_project.Models;
using System.ComponentModel.DataAnnotations;

namespace Shop_project.Models
{
    public class Cart
    {
        [Key]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public Furniture Furniture { get; set; }

        public int Amount { get; set; }

    }
}