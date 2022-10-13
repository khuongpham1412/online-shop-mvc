using Microsoft.CodeAnalysis.QuickInfo;
using Model.Entities;
using Model.Models.Request;
using online_shop_mvc.Services;
using Repository.Repo;

namespace online_shop_mvc.ServicesImp
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepo _orderRepo = new OrderRepo();
        private readonly OrderDetailRepo _orderDetailRepo = new OrderDetailRepo();
        private readonly ProductRepo _productRepo = new ProductRepo();
        public async Task<CustomerOrderRequestModel> Add(CustomerOrderRequestModel userOrder)
        {
            try
            {
                int customerId = userOrder.CustomerId;
                int sizeId = userOrder.SizeId;
                int colorId = userOrder.ColorId;
                int quantity = userOrder.Quantity;
                int productId = userOrder.ProductId;    

                int orderID;
                if (!await _orderRepo.CheckUserOrder(customerId))
                {
                    Order order = new Order()
                    {
                        CreatedDate = userOrder.CreateDate,
                        CustomerID = customerId,
                    };
                    orderID = await _orderRepo.Add(order);
                }
                else
                {
                    orderID = await GetOrderIdByCustomerId(customerId);
                }
                var product = (Product)await _productRepo.GetProductById(productId);
                decimal unitPrice = product.Price * quantity;

                if (orderID != -1)
                {
                    OrderDetail orderDetail = new OrderDetail()
                    {
                        OrderID = orderID,
                        ProductID = productId,
                        Quantity = quantity,
                        UnitPrice = unitPrice,
                        SizeID = sizeId,
                        ColorID = colorId,
                    };
                    var response = await _orderDetailRepo.Add(orderDetail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<int> GetOrderIdByCustomerId(int customerId)
        {
            try
            {
                return await _orderRepo.GetOrderIdByCustomerId(customerId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        public async Task<bool> CheckUserOrder(int userID)
        {
            try
            {
                return await _orderRepo.CheckUserOrder(userID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<bool> Delete(Order order)
        {
            try
            {
                if (await _orderRepo.Delete(order))
                {
                    return true;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<IList<Order>> GetAllOrders()
        {
            try
            {
                var orders = await _orderRepo.GetAllOrder();
                if(orders != null)
                {
                    return orders;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Order> GetOrderById(int id)
        {
            try
            {
                var order = await _orderRepo.GetOrderById(id);
                if(order != null)
                {
                    return order;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<Order> Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
