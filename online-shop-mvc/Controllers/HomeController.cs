using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Model.ShopDbContext;
using online_shop_mvc.Models;
using online_shop_mvc.Services;
using System.Diagnostics;

namespace online_shop_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;
        
        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

       /* public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public async Task<IActionResult> Index()
        {
            try
            {
                IList<Category> categories = await _categoryService.GetAllCategory();
                if(categories != null)
                {
                    ViewBag.Categories = categories;
                    return View();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}