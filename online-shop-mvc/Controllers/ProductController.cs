using AntDesign;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.ShopDbContext;
using NuGet.Protocol;
using online_shop_mvc.Models.Request;
using online_shop_mvc.Services;
using online_shop_mvc.ServicesImp;
using System.Collections.Immutable;
using System.Linq;
using Color = Model.Entities.Color;

namespace online_shop_mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly OnlineShopDbContext _onlineShopDbContext = new OnlineShopDbContext();
        private readonly IProductService _productService;
        private readonly ISizeService _sizeService;
        private readonly IColorService _colorService;
        private readonly ICategoryService _categoryService;
        private readonly IProductSizeColorService _productSizeColorService;
        public ProductController(IProductService productService, ISizeService sizeService, IColorService colorService, ICategoryService categoryService, IProductSizeColorService productSizeColorService)
        {
            _productService = productService;
            _sizeService = sizeService;
            _colorService = colorService;
            _categoryService = categoryService;
            _productSizeColorService = productSizeColorService;
        }
        public async Task<IActionResult> Index()
        {
            IList<Category> categories = await _categoryService.GetAllCategories();
            if (categories != null)
            {
                ViewBag.Categories = categories;
            }

            //Get count product
            int count = await _productService.GetCountProduct();
            ViewBag.Count = count;
            //Get all sizes
            IList<Size> sizes = await _sizeService.GetAllSizes();
            ViewBag.Sizes = sizes;
            //Get all colors
            IList<Color> colors = await _colorService.GetAllColors();
            ViewBag.Colors = colors;

            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.ProductSelected = id;
            int productID = id;
            int sizeID = 0;
            if (Request.QueryString.HasValue)
            {
                sizeID = Int32.Parse(Request.Query["sizeID"]);
                
            }

            if(productID > 0 && sizeID > 0)
            {
                var colorsByProductId = (IList<ProductSizeColor>)await _productSizeColorService.GetColorByProductAndSize(productID, sizeID);
                ViewBag.ColorsByProductId = colorsByProductId;
                ViewBag.SizeSelected = sizeID;
            }

            IList<Size> sizes = await _sizeService.GetAllSizes();
            ViewBag.Sizes = sizes;
            IList<Color> colors = await _colorService.GetAllColors();
            ViewBag.Colors = colors;
            if (id != null)
            {
                var sizesByProductId = await _productSizeColorService.GetSizeByProductId(id);
                if (sizesByProductId != null)
                {
                    ViewBag.SizesByProductId = sizesByProductId;
                }
                Product product = await _productService.GetProductById(id);
                if(product != null)
                {
                    ViewBag.Product = product;
                }
            }

            return View();
        }

        public async Task<IActionResult> Category(int id)
        {
            IList<Product> productCategories = await _productService.GetAllProductByCategoryId(id);
            ViewBag.ProductCategories = productCategories;

            IList<Category> categories = await _categoryService.GetAllCategories();
            if (categories != null)
            {
                ViewBag.Categories = categories;
            }
            //IList<Product> products = await _productService.GetAllProductsPaging(1, 5);
            int count = await _productService.GetCountProduct();
            IList<Size> sizes = await _sizeService.GetAllSizes();
            //ViewBag.Products = products;
            ViewBag.Sizes = sizes;
            ViewBag.Count = count;
            //TempData["mydata"] = products;
            //IList<Color> colors = await _colorService.GetAllColors();
            //ViewBag.Colors = colors;
            /*if (categoryID != null)
            {
                Product product = await _productService.GetProductById(categoryID);
                if (product != null)
                {
                    ViewBag.Product = product;
                }
            }*/
            return View();
        }

        public async Task<IActionResult> HandleSizeOption(int id)
        {
            int productID = id;
            int sizeID = Int32.Parse(Request.Query["sizeID"]);

            var colors = (IList<ProductSizeColor>) await _productSizeColorService.GetColorByProductAndSize(productID, sizeID);
            /*if (colors != null)
            {
                ViewBag["data"] = colors;
            }*/

            return RedirectToAction("Details", "Product", new
            {
                colors = colors.ToString()
            });
        }

        [HttpGet]
        [Route("Product/LoadProductByPaging/{page:int}")]
        public async Task<JsonResult> LoadProductByPaging([FromQuery(Name = "page")] int page = 1)
        {
            IList<Product> products = await _productService.GetAllProductsPaging(1, 5);
            return Json(new { Status = "success", Data = products });
        }

        [HttpGet]
        public async Task<JsonResult> LoadProductByFilter(FilterRequestModel data)
        {
            int[] sizes = data.Size;
            int[] colors = data.Color;
            string search = data.NameSearch;
            Console.WriteLine("Da vao");
            Console.WriteLine(search);

            //var res = (from p in _onlineShopDbContext.ProductSizeColors
            //           join ps in _onlineShopDbContext.Products
            //           on p.ProductID equals ps.Id into g
            //           where sizes.Contains(p.SizeId) && colors.Contains(p.ColorId) && search != null
            //           //group ps by p.ProductID into g
            //           select g.ToList()).AsEnumerable().Skip(0).Take(5).ToList();
            //IList<Product> p1 = new List<Product>();
            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //    p1.Add(item[0]);
            //}

            return Json(new { Status = "success", Data = ""});
        }
    }
}
