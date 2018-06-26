using System;
using System.ComponentModel.DataAnnotations;

namespace Shop_project.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Sity { get; set; }

        public String Address { get; set; }

        public String PhoneNumber { get; set; }

        public DateTime TimeOfOrder { get; set; }

        public double OrderPrice { get; set; }

        public double Total { get; set; }

    }
}