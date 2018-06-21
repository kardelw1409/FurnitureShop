using System;
using System.ComponentModel.DataAnnotations;

namespace Shop_project.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public Customer Customer { get; set; }

        public DateTime TimeOfOrder { get; set; }

        public double OrderPrice { get; set; }

    }
}