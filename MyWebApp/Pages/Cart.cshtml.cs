using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWebApp.Models;

namespace MyWebApp.Pages
{
    public class CartModel : PageModel
    {
        private IMyDBRepository _repository;

        public CartModel(IMyDBRepository repository, Cart cart)
        {
            _repository = repository;
            Cart = cart;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long ProductID, string returnUrl)
        {
            Product? product = _repository.Products.FirstOrDefault(p => p.Id == ProductID);

            if (product != null)
                Cart.AddItem(product, 1);

            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            var item = Cart.Items.First(cl => cl.Product.Id == productId).Product;
            Cart.RemoveItem(item);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}