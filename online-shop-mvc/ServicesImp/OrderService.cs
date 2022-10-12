using Model.Entities;
using online_shop_mvc.Services;
using Repository.Repo;

namespace online_shop_mvc.ServicesImp
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepo _orderRepo = new OrderRepo();
        private readonly OrderDetailRepo _orderDetailRepo = new OrderDetailRepo();
        public async Task<Order> Add(Order order)
        {
            try
            {
                int orderID = 1;
                if (!await _orderRepo.CheckUserOrder(1))
                {
                    Order order1 = new Order()
                    {
                        CreatedDate = DateTime.Now,
                        CustomerID = 1,
                    };
                    orderID = await _orderRepo.Add(order);
                }
                if (orderID != -1)
                {
                    OrderDetail orderDetail = new OrderDetail()
                    {
                        ProductID = 1,
                        Quantity = 2,
                        UnitPrice = 100,
                        OrderID = orderID,
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
