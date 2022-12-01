using Model.Entities;
using Model.Models.Response;

namespace online_shop_mvc.Services
{
    public interface IBillDetailService
    {
        public Task<BillDetail> Add(BillDetail billDetail);
        public Task<IList<BillDetail>> AddRanges(IList<BillDetail> billDetail);
        public Task<BillDetail> Update(BillDetail billDetail);
        public Task<IList<CustomerOrderResponseModel>> GetAllBillDetailsByBillId(int billId);
        public Task<BillDetail> GetBillDetailById(int id);
    }
}
