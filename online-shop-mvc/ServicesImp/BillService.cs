using Model.Entities;
using online_shop_mvc.Services;
using Repository.Repo;

namespace online_shop_mvc.ServicesImp
{
    public class BillService : IBillService
    {
        private readonly BillRepo _billRepo = new BillRepo();
        public async Task<Bill> Add(Bill bill)
        {
            try
            {
                return await _billRepo.Add(bill);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<IList<Bill>> AddRanges(IList<Bill> bills)
        {
            try
            {
                return await _billRepo.AddRanges(bills);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<bool> Delete(int BillId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Bill>> GetAllBill()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<Bill> Update(Bill bill)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
