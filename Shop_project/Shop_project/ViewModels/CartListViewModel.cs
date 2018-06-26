using Shop_project.Models;
using System.Collections.Generic;

namespace Shop_project.ViewModels
{
    public class CartListViewModel
    {
        public List<Cart> CartItems { get; set; }
        public double CartTotal { get; set; }
    }
}