using Show_project.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shop_project.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }

        public string CartId { get; set; }

        public int FurnitureId { get; set; }

        public Furniture Furniture { get; set; }

        public DateTime DateCreated { get; set; }

        public int Amount { get; set; }

    }
}