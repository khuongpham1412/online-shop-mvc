using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Model.Entities;
using Model.Models.Request;
using Model.Models.Response;
using Model.ShopDbContext;
using Newtonsoft.Json;
using online_shop_mvc.Services;
using Repository.Repo;
using System.Data;
using System.Text.Json.Serialization;

namespace online_shop_mvc.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IProductSizeColorService _productSizeColorService;
        private readonly OnlineShopDbContext _context = new OnlineShopDbContext();
        public CartController(IProductService productService, ICategoryService categoryService, IOrderService orderService, IOrderDetailService orderDetailService, IProductSizeColorService productSizeColorService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _productSizeColorService = productSizeColorService;
        }
        public async Task<IActionResult> Index()
        {
            //Get all categories
            IList<Category> categories = await _categoryService.GetAllCategories();
            if (categories != null)
            {
                ViewBag.Categories = categories;
            }

            //Get order id by customer id
            Order order = await _orderService.GetOrderIdByCustomerId(1);
            if (order != null)
            {
                //Get all orders of customer
                var orderOfUser = (IList<CustomerOrderResponseModel>)await _orderDetailService.GetAllOrderDetailsByOrderId(order.Id);
                if (orderOfUser != null)
                {
                    ViewBag.OrderOfUser = orderOfUser;
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> HandleUserOrder()
        {
            int productID = Int32.Parse(Request.Form["product"]);
            int sizeID = Int32.Parse(Request.Form["size"]);
            int colorID = Int32.Parse(Request.Form["color"]);
            int quantity = Int32.Parse(Request.Form["quantity"]);
            int customerId = 1;
            Order order;
            DateTime dateTime = DateTime.Now;
            //Check user order
            bool check = await _orderService.CheckUserOrder(customerId);
            Console.WriteLine(check);
            if (check)
            {
                order = await _orderService.GetOrderIdByCustomerId(customerId);

                var product = (Product)await _productService.GetProductById(productID);
                decimal unitPrice = product.Price * quantity;

                if (order != null)
                {
                    var checkUserOrder = await _orderDetailService.CheckUserOrderProduct(order.Id, productID, sizeID, colorID);
                    if (checkUserOrder != null)
                    {
                        checkUserOrder.Quantity = checkUserOrder.Quantity + quantity;
                        checkUserOrder.UnitPrice = checkUserOrder.UnitPrice + product.Price;
                        var response = await _orderDetailService.Update(checkUserOrder);
                    }
                    else
                    {
                        OrderDetail orderDetail = new OrderDetail()
                        {
                            OrderId = order.Id,
                            ProductId = productID,
                            Quantity = quantity,
                            UnitPrice = unitPrice,
                            SizeId = sizeID,
                            ColorId = colorID,
                        };
                        var response = await _orderDetailService.Add(orderDetail);
                    }
                }
            }
            else
            {
                Order order1 = new Order()
                {
                    CreatedDate = dateTime,
                    CustomerId = customerId,
                };
                var test = await _orderService.Add(order1);
                order = await _orderService.GetOrderIdByCustomerId(customerId);
                var product = (Product)await _productService.GetProductById(productID);
                decimal unitPrice = product.Price * quantity;

                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderId = order.Id,
                    ProductId = productID,
                    Quantity = quantity,
                    UnitPrice = unitPrice,
                    SizeId = sizeID,
                    ColorId = colorID,
                };
                var response = await _orderDetailService.Add(orderDetail);
            }

           //Handle user order product
            //customerorderrequestmodel userorder = new customerorderrequestmodel()
            //{
            //    customerid = customerid,
            //    productid = productid,
            //    createdate = datetime.now,
            //    sizeid = sizeid,
            //    colorid = colorid,
            //    quantity = quantity,
            //};
            //await _orderService.Add(userOrder);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<JsonResult> HandleUserOrderUpdateQuantity(CustomerUpdateQuantityModel data)
        {
            int quantity = data.Quantity;
            int orderDetailId = data.OrderDetailId;

            OrderDetail detail = await _orderDetailService.GetOrderDetailById(orderDetailId);
            int quantityProduct = await _productSizeColorService.GetQuantityByProductSizeColor(detail.ProductId, detail.SizeId, detail.ColorId);
            if (quantityProduct < quantity)
            {
                return Json(new { status = "error" ,data = "Sản phẩm vượt quá giới hạn !!!"});
            }

            OrderDetail orderDetail = new OrderDetail()
            {
                Id = orderDetailId,
                Quantity = quantity
            };
            await _orderDetailService.Update(orderDetail);

            return Json(new { status = "success", data = "" });
        }

        [HttpPost]
        public async Task<JsonResult> HandleDeleteCartItem(int orderId, int orderDetailId)
        {
            if (orderId > 0 && orderDetailId > 0)
            {
                int count = await _orderDetailService.GetCountOrderDetailsByOrderId(orderId);
                if (count == 1)
                {
                    await _orderService.Delete(orderId);
                }
                if (await _orderDetailService.Delete(orderDetailId))
                {
                    return Json(new { Status = "success", Count = count });
                }
            }

            return Json(new { Status = "fail" });
        }
    }
}
