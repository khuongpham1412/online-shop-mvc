using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Entities;
using Model.Models.Request;
using Model.Models.Response;
using Model.ShopDbContext;
using online_shop_mvc.Services;
using online_shop_mvc.ServicesImp;

namespace online_shop_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            List<SelectListItem> listSelectSizes = new List<SelectListItem>();
            foreach (var size in sizes)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = size.Name,
                    Value = size.Id.ToString()
                };
                listSelectSizes.Add(selectList);
                ViewBag.SizesChosen = new SelectList(listSelectSizes, "Value", "Text");
            }
            //Get all colors
            IList<Color> colors = await _colorService.GetAllColors();
            ViewBag.Colors = colors;
            List<SelectListItem> listSelectColors = new List<SelectListItem>();

            foreach (var color in colors)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = color.Name,
                    Value = color.Id.ToString()
                };
                listSelectColors.Add(selectList);
                ViewBag.ColorsChosen = new SelectList(listSelectColors, "Value", "Text");
            }

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> handleLoadProducts()
        {
            IList<Product> product = await _productService.GetAllProductsPaging(1, 10);
            if (product != null)
            {
                return Json(new { Status = "Success", Data = product });
            }

            return Json(new { Status = "Fail", Data = "null" });
        }

        [HttpPost]
        public async Task<JsonResult> handleAddProduct(InsertProductRequestModel data)
        {
            //Product product = await _productService.Add(new Product()
            //{
            //    Name = data.Name,
            //    CategoryID = data.CategoryId,
            //    Description = data.Description,
            //    Image = data.Image,
            //    Price = data.Price
            //})

            var product = new Product()
            {
                Name = data.Name,
                CategoryID = data.CategoryId,
                Description = data.Description,
                Image = data.Image,
                Price = data.Price
            };
            await _productService.Add(product);
            if (product != null)
            {
                Console.WriteLine(product.Id);
                IList<ProductSizeColor> list = new List<ProductSizeColor>();
                foreach (var size in data.SizeId)
                {
                    foreach (var color in data.ColorId)
                    {
                        list.Add(new ProductSizeColor()
                        {
                            ProductID = 2,
                            SizeID = size,
                            ColorID = color,
                            Quantity = data.Quantity
                        });
                    }
                }
                await _onlineShopDbContext.ProductSizeColors.AddRangeAsync(list);
                await _onlineShopDbContext.SaveChangesAsync();

                //return Json(new { Status = "Success", Data = product });
            }


            return Json(new { Status = "Fail", Data = "null" });
        }

        [HttpPost]
        public async Task<JsonResult> handleEditProduct(Product data)
        {
            Product product = await _productService.Update(data);
            if (product != null)
            {
                return Json(new { Status = "Success", Data = product });
            }

            return Json(new { Status = "Fail", Data = "null" });
        }

        [HttpPost]
        public async Task<JsonResult> viewToEdit(int productId)
        {
            Product product = await _productService.GetProductById(productId);
            //Category category = await _categoryService.GetCategoryById();
            var sizes = await _productSizeColorService.GetSizeByProductId(productId);
            if(sizes != null)
            {
                foreach (var size in sizes)
                {
                    var colors = await _productSizeColorService.GetColorByProductAndSize(productId, size.Id);
                    if(colors != null)
                    {
                        foreach(var color in colors)
                        {
                            var quantity = await _productSizeColorService.GetQuantityByProductSizeColor(productId, size.Id, color.Id);
                        }
                    }
                }
            }
            //ProductResponseModel productResponse = new ProductResponseModel() 
            //{
            //    Name = product.Name,
            //    CategoryName = 

            //}


            if(product != null)
            {
                return Json(new { Status = "Success", Data = product });
            }

            return Json(new { Status = "Fail", Data = "null" });
        }
    }
}
