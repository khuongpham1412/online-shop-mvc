using Model.Entities;
using Model.Models.Request;

namespace online_shop_mvc.Services
{
    public interface IOrderService
    {
        public Task<CustomerOrderRequestModel> Add(CustomerOrderRequestModel userOrder);
        public Task<Order> Update(Order order);
        public Task<bool> Delete(int orderId);
        public Task<IList<Order>> GetAllOrders();
        public Task<bool> CheckUserOrder(int userID);
        public Task<Order> GetOrderById(int id);
        public Task<int> GetOrderIdByCustomerId(int customerId);
    }
}
