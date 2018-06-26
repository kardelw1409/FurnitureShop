using Shop_project.Models;
using Shop_project.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Shop_project.Controllers
{
    public class CartListController : Controller
    {
        private readonly FurnitureRepository furnitureRepository;

        private readonly CartList cartList;

        public CartListController(FurnitureRepository furnitureRepository, CartList cartList)
        {
            this.furnitureRepository = furnitureRepository;
            this.cartList = cartList;
        }

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
            // Return the view
            return View(viewModel);
        }

        public ViewResult Index()
        {
            var items = cartList.GetCartItems();
            cartList.Cart = items;

            var shoppingCartViewModel = new CartListViewModel
            {
                CartItems = cartList,
                CartTotal = cartList.GetTotal()
            };

            return View(shoppingCartViewModel);
        }

        public ActionResult AddToShoppingCart(int furnitureId)
        {
            var selectedFurniture = furnitureRepository.Furnitures.FirstOrDefault(s => s.FurnitureId == furnitureId); //jak nie zadziala to trzeba dodac do ISnowboardRepository liste snowboardow

            if (selectedFurniture != null)
            {
                cartList.AddToCart(selectedFurniture, 1);
            }
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromShoppingCart(int furnitureId)
        {
            var selectedFurniture = furnitureRepository.Furnitures.FirstOrDefault(s => s.FurnitureId == furnitureId); //jak nie zadziala to trzeba dodac do ISnowboardRepository liste snowboardow

            if (selectedFurniture != null)
            {
                cartList.RemoveFromCart(selectedFurniture);
            }

            return RedirectToAction("Index");
        }
    }
}