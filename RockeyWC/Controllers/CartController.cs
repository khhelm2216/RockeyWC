//I will be implmenting and expanding this code to include cart features for rentals

/*using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using RockeyWC.Infrastructure;
using RockeyWC.Models;
//using RockeyWC.Models.ViewModels;

namespace RockeyWC.Controllers {

    public class CartController : Controller {
        private IProductRepository repository;
        private Cart cart;

        // Constructor declares it needs an IProductRepository and Cart service objects.
        public CartController(IProductRepository repo, Cart cartService) {
            // Needs a repository of (products)
            repository = repo;
            // Needs a cart service object
            cart = cartService;
        }

        // Method renders a view to the response given a returnUrl.
        public ViewResult Index(string returnUrl) {
            return View(new CartIndexViewModel {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        // Controller method for adding items to a/the cart object.
        public RedirectToActionResult AddToCart(int productId, string returnUrl) {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null) {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        // Controller method for removing items to a/the cart object.
        public RedirectToActionResult RemoveFromCart(int productId,
                string returnUrl) {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null) {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
*/