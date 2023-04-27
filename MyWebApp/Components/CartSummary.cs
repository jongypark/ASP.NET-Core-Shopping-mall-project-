using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Components
{
    public class CartSummary : ViewComponent
    {
        private Cart _cart;
        public CartSummary(Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }
    }
}