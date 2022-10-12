using Model.Entities;
using online_shop_mvc.Services;
using Repository.Repo;

namespace online_shop_mvc.ServicesImp
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly OrderDetailRepo _orderDetailRepo = new OrderDetailRepo();
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

        public Task<OrderDetail> Update(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
