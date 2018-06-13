using Show_project.Models;

namespace Shop_project.Models
{
    public class Cart
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public Furniture Furniture { get; set; }

        public int Amount { get; set; }

    }
}