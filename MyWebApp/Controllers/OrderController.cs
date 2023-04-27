using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _repository;
        private Cart _cart;

        public OrderController(IOrderRepository repository, Cart cart)
        {
            _repository = repository;
            _cart = cart;
        }

        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (_cart.Items.Count() == 0)
            {
                ModelState.AddModelError(String.Empty, "장바구니에 주문가능한 제품이 포함되어 있지 않습니다.");
            }

            if (ModelState.IsValid)
            {
                order.Items = _cart.Items.ToArray();
                _repository.SaveOrder(order);

                _cart.Clear();

                return RedirectToPage("/OrderComplete", new { OrderId = order.OrderID });
            }
            else
            {
                return View();
            }
        }
    }
}