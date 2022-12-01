using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Model.Models.Response;
using online_shop_mvc.Services;

namespace online_shop_mvc.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IBillService _billService;
        private readonly IBillDetailService _billDetailService;
        private readonly IProductSizeColorService _productSizeColorService;
        private readonly IProductService _productService;
        public CheckOutController(IOrderService orderService, IOrderDetailService orderDetailService, IBillService billService, IBillDetailService billDetailService, IProductSizeColorService productSizeColorService, IProductService productService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _billService = billService;
            _billDetailService = billDetailService;
            _productSizeColorService = productSizeColorService;
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> HandleCheckout()
        {
            Order order = await _orderService.GetOrderIdByCustomerId(1);
            if (order != null)
            {
                IList<CustomerOrderResponseModel> orderDetails = await _orderDetailService.GetAllOrderDetailsByOrderId(order.Id);
                if (orderDetails.Count > 0)
                {
                    Bill bill = await _billService.Add(
                      new Bill()
                      {
                          CreatedDate = DateTime.Now,
                          CustomerId = 1,
                          Total = order.Total,
                          Status = 0
                      });

                    IList<BillDetail> billDetails = new List<BillDetail>();
                    foreach (var item in orderDetails)
                    {
                        int quantity = await _productSizeColorService.GetQuantityByProductSizeColor(item.ProductId, item.SizeId, item.ColorId);
                        await _productSizeColorService.UpdateQuantity(item.ProductId, item.SizeId, item.ColorId, quantity - item.Quantity );
                        BillDetail billDetail = new BillDetail()
                        {
                            BillId = bill.Id,
                            ProductId = item.ProductId,
                            SizeId = item.SizeId,
                            ColorId = item.ColorId,
                            UnitPrice = item.UnitPrice,
                            Quantity = item.Quantity
                        };
                        billDetails.Add(billDetail);
                    }

                    await _billDetailService.AddRanges(billDetails);

                    await _orderDetailService.DeleteRanges(order.Id);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
