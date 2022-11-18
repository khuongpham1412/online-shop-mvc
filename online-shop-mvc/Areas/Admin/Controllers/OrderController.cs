using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using online_shop_mvc.Services;

namespace online_shop_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;

        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OrderDetail()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> handleLoadOrders()
        {
            IList<Order> orders = await orderService.GetAllOrders();
            if (orders != null)
            {
                return Json(new { Status = "Success", Data = orders });
            }

            return Json(new { Status = "Fail", Data = "null" });
        }


        [HttpPost]
        public async Task<JsonResult> handleConfirmOrder(int orderId, int status)
        {
            //Order order = await orderService.Update(data);
            //if (order != null)
            //{
            //    return Json(new { Status = "Success", Data = order });
            //}

            return Json(new { Status = "Fail", Data = "null" });
        }
    }
}
