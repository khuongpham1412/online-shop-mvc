using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using online_shop_mvc.Services;
using online_shop_mvc.ServicesImp;

namespace online_shop_mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISizeService _sizeService;
        private readonly IColorService _colorService;
        public ProductController(IProductService productService, ISizeService sizeService, IColorService colorService)
        {
            _productService = productService;
            _sizeService = sizeService;
            _colorService = colorService;
        }
        public async Task<IActionResult> Index()
        {
            IList<Product> products = await _productService.GetAllProductsPaging(1, 5);
            int count = await _productService.GetCountProduct();
            IList<Size> sizes = await _sizeService.GetAllSizes();
            ViewBag.Products = products;
            ViewBag.Sizes = sizes;
            ViewBag.Count = count;

            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            IList<Size> sizes = await _sizeService.GetAllSizes();
            ViewBag.Sizes = sizes;
            IList<Color> colors = await _colorService.GetAllColors();
            ViewBag.Colors = colors;
            if (id != null)
            {
                Product product = await _productService.GetProductById(id);
                if(product != null)
                {
                    ViewBag.Product = product;
                }
            }
            return View();
        }

        public IActionResult Category()
        {
            return RedirectToAction("Index");
        }
    }
}
