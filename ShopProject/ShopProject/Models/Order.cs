using System;

namespace ShopProject.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public Customer Customer { get; set; }

        public DateTime TimeOfOrder { get; set; }

        public double OrderPrice { get; set; }

    }
}