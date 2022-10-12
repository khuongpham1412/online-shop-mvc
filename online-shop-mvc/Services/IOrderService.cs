using Model.Entities;

namespace online_shop_mvc.Services
{
    public interface IOrderService
    {
        public Task<Order> Add(Order order);
        public Task<Order> Update(Order order);
        public Task<bool> Delete(Order order);
        public Task<IList<Order>> GetAllOrders();
        public Task<bool> CheckUserOrder(int userID);
    }
}
