using Show_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_project.Models
{
    public class CartList
    {
        ModelsDbContext storeDB = new ModelsDbContext();

        public List<Cart> Cart { get; set; }

        public string CartListId { get; set; }

        public const string CartSessionKey = "CartId";

        public static CartList GetCart(HttpContextBase context)
        {
            var cart = new CartList();
            cart.CartListId = cart.GetCartId(context);
            return cart;
        }

        public static CartList GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Furniture furniture, int amount)
        {
            var cartItem = storeDB.Carts.SingleOrDefault(
                c => c.CartId == CartListId
                && c.FurnitureId == furniture.FurnitureId);

            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    FurnitureId = furniture.FurnitureId,
                    CartId = CartListId,
                    Amount = 1,
                    DateCreated = DateTime.Now
                };
                storeDB.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Amount++;
            }
            // Save changes
            storeDB.SaveChanges();
        }

        public int RemoveFromCart(Furniture furniture)
        {
            var cartItem = storeDB.Carts.SingleOrDefault(
                s => s.Furniture.FurnitureId == furniture.FurnitureId && s.CartId == CartListId);
            var localAmount = 0;

            if (cartItem != null)
            {
                if (cartItem.Amount > 1)
                {
                    cartItem.Amount--;
                    localAmount = cartItem.Amount;
                }
                else
                {
                    storeDB.Carts.Remove(cartItem);
                }
            }

            storeDB.SaveChanges();

            return localAmount;
        }
        public void EmptyCart()
        {
            var cartItems = storeDB.Carts.Where(
                cart => cart.CartId == CartListId);

            foreach (var cartItem in cartItems)
            {
                storeDB.Carts.Remove(cartItem);
            }

            storeDB.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return storeDB.Carts.Where(
                cart => cart.CartId == CartListId).ToList();
        }

        public int GetCount()
        {

            int? count = (from cartItems in storeDB.Carts
                          where cartItems.CartId == CartListId
                          select (int?)cartItems.Amount).Sum();

            return count ?? 0;
        }
        public double GetTotal()
        {
            double? total = (from cartItems in storeDB.Carts
                              where cartItems.CartId == CartListId
                              select (int?)cartItems.Amount *
                              cartItems.Furniture.Price).Sum();

            return (double)total;
        }
        public int CreateOrder(Order order)
        {
            double orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    UnitPrice = item.Furniture.Price,
                    Quantity = item.Amount
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Amount * item.Furniture.Price);

                storeDB.OrderDetails.Add(orderDetail);

            }

            order.Total = orderTotal;

            storeDB.SaveChanges();

            EmptyCart();

            return order.OrderId;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {

                    Guid tempCartId = Guid.NewGuid();

                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public void MigrateCart(string userName)
        {
            var shoppingCart = storeDB.Carts.Where(
                c => c.CartId == CartListId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            storeDB.SaveChanges();
        }

    }
}