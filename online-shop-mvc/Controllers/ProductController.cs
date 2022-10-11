using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using online_shop_mvc.Services;
using online_shop_mvc.ServicesImp;

namespace online_shop_mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            IList<Product> products = await _productService.GetAllProductsPaging(1, 5);
            int count = await _productService.GetCountProduct();
            ViewBag.Products = products;
            ViewBag.Count = count;

            return View();
        }
        public IActionResult Category()
        {
            return RedirectToAction("Index");
        }
    }
}
