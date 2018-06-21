using System;
using System.ComponentModel.DataAnnotations;

namespace Shop_project.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Sity { get; set; }

        public String Address { get; set; }

        public String PhoneNumber { get; set; }

    }
}