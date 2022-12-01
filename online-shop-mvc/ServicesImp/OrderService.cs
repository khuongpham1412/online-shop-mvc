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
        public async Task<Order> Add(Order order)
        {
            try
            {
                return await _orderRepo.Add(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Order> GetOrderIdByCustomerId(int customerId)
        {
            try
            {
                return await _orderRepo.GetOrderIdByCustomerId(customerId);
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

        public async Task<bool> Delete(int orderId)
        {
            try
            {
                var order = await GetOrderById(orderId);
                if(order != null)
                {
                    return await _orderRepo.Delete(order);
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
