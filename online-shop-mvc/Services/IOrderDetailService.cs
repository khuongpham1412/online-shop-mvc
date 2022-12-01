using Microsoft.CodeAnalysis;
using Model.Entities;
using Model.Models.Response;

namespace online_shop_mvc.Services
{
    public interface IOrderDetailService
    {
        public Task<OrderDetail> Add(OrderDetail orderDetail);
        public Task<IList<OrderDetail>> AddRanges(IList<OrderDetail> orderDetail);
        public Task<OrderDetail> Update(OrderDetail orderDetail);
        public Task<bool> Delete(int id);
        public Task<bool> DeleteRanges(int orderId);
        public Task<IList<OrderDetail>> GetAllOrderDetails();
        public Task<IList<CustomerOrderResponseModel>> GetAllOrderDetailsByOrderId(int orderId);
        public Task<int> GetCountOrderDetailsByOrderId(int orderId);
        public Task<OrderDetail> GetOrderDetailById(int id);
        public Task<OrderDetail> CheckUserOrderProduct(int orderId, int productId, int sizeId, int colorId);
    }
}
