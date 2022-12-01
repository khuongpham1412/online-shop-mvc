using Model.Entities;
using Model.Models.Response;
using online_shop_mvc.Services;
using Repository.Repo;

namespace online_shop_mvc.ServicesImp
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly OrderDetailRepo _orderDetailRepo = new OrderDetailRepo();
        private readonly ProductRepo _productRepo = new ProductRepo();
        private readonly SizeRepo _sizeRepo = new SizeRepo();
        private readonly ColorRepo _colorRepo = new ColorRepo();
        public Task<OrderDetail> Add(OrderDetail orderDetail)
        {
            try
            {
                var Response = _orderDetailRepo.Add(orderDetail);
                if (Response != null)
                {
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<IList<OrderDetail>> AddRanges(IList<OrderDetail> orderDetail)
        {
            try
            {
                var Response = await _orderDetailRepo.AddRanges(orderDetail);
                if (Response != null)
                {
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<OrderDetail> CheckUserOrderProduct(int orderId, int productId, int sizeId, int colorId)
        {
            try
            {
                var Response = _orderDetailRepo.CheckUserOrderProduct(orderId, productId, sizeId, colorId);
                if (Response != null)
                {
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var orderDetail = await GetOrderDetailById(id);
                if (orderDetail != null)
                    return await _orderDetailRepo.Delete(orderDetail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<bool> DeleteRanges(int orderId)
        {
            try
            {
                return await _orderDetailRepo.DeleteRanges(orderId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<IList<OrderDetail>> GetAllOrderDetails()
        {
            try
            {
                var orderDetails = await _orderDetailRepo.GetAllOrderDetail();
                if (orderDetails != null)
                {
                    return orderDetails;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<IList<CustomerOrderResponseModel>> GetAllOrderDetailsByOrderId(int orderId)
        {
            try
            {
                IList<CustomerOrderResponseModel> response = new List<CustomerOrderResponseModel>();
                var orderDetail = (IList<OrderDetail>)await _orderDetailRepo.GetAllOrderDetailsByOrderId(orderId);
                if (orderDetail != null)
                {
                    foreach (var item in orderDetail)
                    {
                        Product product = await _productRepo.GetProductById((int)item.ProductId);
                        Size size = await _sizeRepo.GetSizeById((int)item.SizeId);
                        Color color = await _colorRepo.GetColorById((int)item.ColorId);

                        string sizeName = size.Name;
                        string colorName = color.Name;
                        int quantity = item.Quantity;
                        decimal price = product.Price;
                        decimal unitPrice = price * quantity;

                        var customerOrder = new CustomerOrderResponseModel()
                        {
                            SizeId = item.SizeId,
                            SizeName = sizeName,
                            ColorId = item.ColorId,
                            ColorName = colorName,
                            ProductId = item.ProductId,
                            UnitPrice = unitPrice,
                            Price = price,
                            PathImage = product.Image,
                            ProductName = product.Name,
                            OrderDetailId = (int)item.Id,
                            OrderId = (int)item.OrderId,
                            Quantity = quantity,
                        };

                        response.Add(customerOrder);
                    }

                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<int> GetCountOrderDetailsByOrderId(int orderId)
        {
            try
            {
                return await _orderDetailRepo.GetCountOrderDetailsByOrderId(orderId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            try
            {
                var orderDetail = await _orderDetailRepo.GetOrderDetailById(id);
                if (orderDetail != null)
                    return orderDetail;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<OrderDetail> Update(OrderDetail orderDetail)
        {
            try
            {
                var response = await GetOrderDetailById(orderDetail.Id);

                if (response != null)
                {
                    response.Quantity = orderDetail.Quantity;
                    return await _orderDetailRepo.Update(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
