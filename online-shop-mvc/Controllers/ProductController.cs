using Microsoft.AspNetCore.Mvc;
using online_shop_mvc.Services;
using online_shop_mvc.ServicesImp;

namespace online_shop_mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        public ProductController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Category()
        {
            return RedirectToAction("Index");
        }
    }
}
