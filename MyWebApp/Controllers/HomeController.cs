using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Models.ViewModels;

namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMyDBRepository _repository;
        public int PageSize = 2;

        public HomeController(IMyDBRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(int currentPage = 1)
        {
            var result = _repository.Products.OrderBy(p => p.Id)
                .Skip((currentPage - 1) * PageSize)
                .Take(PageSize);

            return View(
                new ProductsListViewModel
                {
                    Products = result,
                    PageInfo = new PageInfo
                    {
                        CurrentPage = currentPage,
                        ItemsPerPage = PageSize,
                        TotalItems = _repository.Products.Count()
                    }
                });
        }
    }
}