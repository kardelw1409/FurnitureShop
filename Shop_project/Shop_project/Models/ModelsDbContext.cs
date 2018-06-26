using Show_project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shop_project.Models
{
    public class ModelsDbContext : DbContext 
    {
        public ModelsDbContext() : base("DefaultConect") { }

        public DbSet<Furniture> Furnitures { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}