using Shop_project.Models;
using Shop_project.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Shop_project.Controllers
{
    public class CartListController : Controller
    {
        ModelsDbContext storeDb = new ModelsDbContext();

        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = CartList.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new CartListViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            ViewBag.List = viewModel;
            // Return the view
            return View(viewModel);
        }

        public ActionResult AddToShoppingCart(int id)
        {
            var addedFurniture = storeDb.Furnitures
                .Single(furniture => furniture.FurnitureId == id);

            var cart = CartList.GetCart(this.HttpContext);

            cart.AddToCart(addedFurniture);

            return RedirectToAction("Index");

        }

        public ActionResult RemoveFromShoppingCart(int id)
        {
            var selectedFurniture = storeDb.Furnitures.FirstOrDefault(s => s.FurnitureId == id);

            // Remove the item from the cart
            var cart = CartList.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string furniture = storeDb.Carts
                .Single(item => item.RecordId == id).CartId;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            return RedirectToAction("Index");
        }
    }
}