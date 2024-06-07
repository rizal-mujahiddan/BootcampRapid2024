using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.Controllers
{
    //Home/Index
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["FullName"] = "Rizal Mujahiddan";
            ViewBag.Address = "Jl. Jend. Sudirman No. 1";

            Category model = new Category
            {
                CategoryId = 1,
                CategoryName = "Laptop Gaming"
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}