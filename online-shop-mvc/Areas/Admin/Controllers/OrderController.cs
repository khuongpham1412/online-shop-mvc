using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Model.Models.Response;
using online_shop_mvc.Services;
using System.Collections.Generic;

namespace online_shop_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly ICustomerService customerService;
        private IOrderDetailService orderDetailService;
        public OrderController(IOrderService orderService, ICustomerService customerService, IOrderDetailService orderDetailService)
        {
            this.orderService = orderService;
            this.customerService = customerService;
            this.orderDetailService = orderDetailService;
        }
        
        public async Task<IActionResult> Index()
        {
            IList<Order> orders = await orderService.GetAllOrders();
            IList<CustomerOrderModel> ordersList = new List<CustomerOrderModel>();
            if(orders != null)
            {
                foreach(var item in orders)
                {
                    Customer cus = await customerService.GetCustomerById(item.CustomerId);
                    var order1 = new CustomerOrderModel()
                    {
                        OrderId = item.Id,
                        CustomerName = cus.FullName,
                        DateCreate = item.CreatedDate.ToString(),
                    };
                    ordersList.Add(order1);
                }
                return View(ordersList);
            }
            return NotFound();
        }

        public async Task<IActionResult> OrderDetail(int id)
        {
            IList<CustomerOrderResponseModel> orderDetail = await orderDetailService.GetAllOrderDetailsByOrderId(id);
            if(orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
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
