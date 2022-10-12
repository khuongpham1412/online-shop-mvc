using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using online_shop_mvc.Services;

namespace online_shop_mvc.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        public CartController(IProductService productService, ICategoryService categoryService, IOrderService orderService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
        }
        public async Task<IActionResult> Index()
        {
            IList<Category> categories = await _categoryService.GetAllCategories();
            if (categories != null)
            {
                ViewBag.Categories = categories;
            }

            //Handle user order product
            
                Order order = new Order()
                {
                    CreatedDate = DateTime.Now,
                    CustomerID = 1,
                };
                await _orderService.Add(order);

            return View();
        }
    }
}
