using Model.Entities;
using Model.Models.Request;

namespace online_shop_mvc.Services
{
    public interface IOrderService
    {
        public Task<Order> Add(Order order);
        public Task<Order> Update(Order order);
        public Task<bool> Delete(int orderId);
        public Task<IList<Order>> GetAllOrders();
        public Task<bool> CheckUserOrder(int userID);
        public Task<Order> GetOrderById(int id);
        public Task<Order> GetOrderIdByCustomerId(int customerId);
    }
}
