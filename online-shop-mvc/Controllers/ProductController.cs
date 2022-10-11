using Microsoft.AspNetCore.Mvc;
using online_shop_mvc.ServicesImp;

namespace online_shop_mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productServiceImp;
        public ProductController(ProductService productServiceImp)
        {
            _productServiceImp = productServiceImp;
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
