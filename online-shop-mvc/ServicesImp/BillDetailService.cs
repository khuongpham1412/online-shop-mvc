using Model.Entities;
using Model.Models.Response;
using online_shop_mvc.Services;
using Repository.Repo;

namespace online_shop_mvc.ServicesImp
{
    public class BillDetailService : IBillDetailService
    {
        private readonly BillDetailRepo _billDetailRepo = new BillDetailRepo();
        public Task<BillDetail> Add(BillDetail billDetail)
        {
            try
            {
                return _billDetailRepo.Add(billDetail);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<IList<BillDetail>> AddRanges(IList<BillDetail> billDetail)
        {
            try
            {
                return _billDetailRepo.AddRanges(billDetail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<IList<CustomerOrderResponseModel>> GetAllBillDetailsByBillId(int billId)
        {
            throw new NotImplementedException();
        }

        public Task<BillDetail> GetBillDetailById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BillDetail> Update(BillDetail billDetail)
        {
            throw new NotImplementedException();
        }
    }
}
