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
        private readonly IBillService _billService;
        private readonly ICustomerService _customerService;
        private readonly IBillDetailService _billDetailService;
        public OrderController(IBillService billService, ICustomerService customerService, IBillDetailService billDetailService)
        {
            _billService = billService;
            _customerService = customerService;
            _billDetailService = billDetailService;
        }

        public async Task<IActionResult> Index()
        {
            IList<Bill> bills = await _billService.GetAllBill();
            Console.WriteLine(bills);
            IList<CustomerOrderModel> billList = new List<CustomerOrderModel>();
            if (bills != null)
            {
                foreach (var item in bills)
                {
                    Customer cus = await _customerService.GetCustomerById(item.CustomerId);
                    var bill = new CustomerOrderModel()
                    {

                        BillId = item.Id,
                        CustomerName = cus.FullName,
                        Phone = cus.PhoneNumber,
                        Address = cus.Address,
                        DateCreate = item.CreatedDate.ToString(),
                        Total = item.Total,
                        EmployeeId = item.EmployeeId,
                        EmployeeName = "test",
                        Status = item.Status,

                    };
                    billList.Add(bill);
                }
                return View(billList);
            }
            return NotFound();
        }

        public async Task<IActionResult> OrderDetail(int id)
        {
            IList<CustomerOrderResponseModel> billDetail = await _billDetailService.GetAllBillDetailsByBillId(id);
            if (billDetail == null)
            {
                return NotFound();
            }
            return View(billDetail);
        }

        [HttpPost]
        public async Task<JsonResult> handleLoadOrders()
        {
            //IList<Order> orders = await orderService.GetAllOrders();
            //if (orders != null)
            //{
            //    return Json(new { Status = "Success", Data = orders });
            //}

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

        [HttpGet]
        public async Task<IActionResult> HandleUpdateStatusBill()
        {
            int status = Int32.Parse(Request.Query["status"]);
            int billId = Int32.Parse(Request.Query["billid"]);
            await _billService.UpdateStatus(billId, status);
            return RedirectToAction("Index");
        }
    }
}
