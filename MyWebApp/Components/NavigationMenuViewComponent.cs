using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using MyWebApp.Models;

namespace MyWebApp.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IMyDBRepository _repository;

        public NavigationMenuViewComponent(IMyDBRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.CurrentCategory = RouteData?.Values["category"];

            return View(_repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
        }
    }
}