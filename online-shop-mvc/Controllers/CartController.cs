using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Model.Models.Request;
using Model.Models.Response;
using online_shop_mvc.Services;

namespace online_shop_mvc.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        public CartController(IProductService productService, ICategoryService categoryService, IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }
        public async Task<IActionResult> Index()
        {
            IList<Category> categories = await _categoryService.GetAllCategories();
            if (categories != null)
            {
                ViewBag.Categories = categories;
            }

            int productID = 1;
            //Console.WriteLine(Request.Form["size"].ToString());

            /*int sizeID = Int32.Parse(Request.Form["size"]);
            int colorID = Int32.Parse(Request.Form["color"]);
            int quantity = Int32.Parse(Request.Form["quantity"]);

            //Handle user order product
            CustomerOrderRequestModel userOrder = new CustomerOrderRequestModel()
            {
                CustomerId = 1,
                ProductId = productID,
                CreateDate = DateTime.Now,
                SizeId = sizeID,
                ColorId = colorID,
                Quantity = quantity,
            };
            await _orderService.Add(userOrder);*/

            var orderId = await _orderService.GetOrderIdByCustomerId(1);
            if(orderId != -1)
            {
                var orderOfUser = (IList<CustomerOrderResponseModel>) await _orderDetailService.GetAllOrderDetailsByOrderId(orderId);
                if(orderOfUser != null)
                {
                    ViewBag.OrderOfUser = orderOfUser;
                }
            }

            return View();
        }
    }
}
