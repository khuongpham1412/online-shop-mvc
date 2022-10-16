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

        public async Task<bool> Delete(OrderDetail orderDetail)
        {
            try
            {
                if (await _orderDetailRepo.Delete(orderDetail))
                {
                    return true;
                }
            }catch(Exception ex)
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
                if(orderDetails != null)
                {
                    return orderDetails;
                }
            }catch(Exception ex)
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
                var orderDetail = (IList<OrderDetail>) await _orderDetailRepo.GetAllOrderDetailsByOrderId(orderId);
                if (orderDetail != null)
                {
                    foreach (var item in orderDetail)
                    {
                        Product product = await _productRepo.GetProductById((int)item.ProductID);
                        Size size = await _sizeRepo.GetSizeById((int)item.SizeID);
                        Color color = await _colorRepo.GetColorById((int)item.ColorID);

                        string sizeName = size.Name;
                        string colorName = color.Name;
                        int quantity = item.Quantity;
                        decimal price = product.Price;
                        decimal unitPrice = price * quantity;

                        var customerOrder = new CustomerOrderResponseModel()
                        {
                            SizeName = sizeName,
                            ColorName = colorName,
                            Quantity = quantity,
                            UnitPrice = unitPrice,
                            Price = price,
                            SizeId = item.SizeID,
                            ColorId =item.ColorID,
                            ProductId = (int)item.ProductID,
                            PathImage = product.Image,
                            ProductName = product.Name,
                            OrderDetailId = (int)item.Id,
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

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            try
            {
                var orderDetail = await _orderDetailRepo.GetOrderDetailById(id);
                if(orderDetail != null)
                {
                    return orderDetail;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<OrderDetail> Update(OrderDetail orderDetail)
        {
            try
            {
                Console.WriteLine(orderDetail.Id);
                var response = await GetOrderDetailById(orderDetail.Id);
                
                if (response != null)
                {
                    response.Quantity = orderDetail.Quantity;
                    return await _orderDetailRepo.Update(response);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
