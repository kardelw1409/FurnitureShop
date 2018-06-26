using Show_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_project.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public int FurnitureId { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public Furniture Furniture { get; set; }

        public Order Order { get; set; }
    }
}