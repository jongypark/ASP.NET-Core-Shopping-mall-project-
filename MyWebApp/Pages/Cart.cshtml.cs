using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Migrations;
using MyWebApp.Classes;
using MyWebApp.Models;

namespace MyWebApp.Pages
{
    public class CartModel : PageModel
    {
        private IMyDBRepository _repository;

        public CartModel(IMyDBRepository repository)
        {
            _repository = repository;
        }

        public Cart? Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long ProductID, string returnUrl)
        {
            Product? product = _repository.Products.FirstOrDefault(p => p.Id == ProductID);

            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);

                HttpContext.Session.SetJson("cart", Cart);
            }

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}