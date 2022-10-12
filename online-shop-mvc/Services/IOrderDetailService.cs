using Model.Entities;

namespace online_shop_mvc.Services
{
    public interface IOrderDetailService
    {
        public Task<OrderDetail> Add(OrderDetail orderDetail);
        public Task<OrderDetail> Update(OrderDetail orderDetail);
        public Task<bool> Delete(OrderDetail orderDetail);
        public Task<IList<OrderDetail>> GetAllOrderDetails();
    }
}
