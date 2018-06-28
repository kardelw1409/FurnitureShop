using System;
using System.Linq;
using System.Web.Mvc;
using Shop_project.Models;

namespace Shop_project.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        ModelsDbContext storeDB = new ModelsDbContext();
        //
        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            return View();
        }
        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                var cart = CartList.GetCart(HttpContext);
                order.Username = User.Identity.Name;
                order.TimeOfOrder = DateTime.Now;
                order.Total = cart.GetTotal();

                storeDB.Orders.Add(order);
                storeDB.SaveChanges();

                cart.CreateOrder(order);
                
                return RedirectToAction("Complete", new { id = order.OrderId });

            }
            catch
            {
                return View(order);
            }
        }
        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            bool isValid = storeDB.Orders.Any(
                o => o.OrderId == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}