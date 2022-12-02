using Model.Entities;
using Model.Models.Response;
using online_shop_mvc.Services;
using Repository.Repo;
using System.Reflection.Metadata.Ecma335;

namespace online_shop_mvc.ServicesImp
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepo _customerRepo = new CustomerRepo();
        private readonly AccountRepo _accountRepo = new AccountRepo();
        public Task<Customer> Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Customer>> GetAllCustomer()
        {
            try
            {
                return await _customerRepo.GetAllCustomer();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Customer> GetCustomerByAccountId(int id)
        {

            try
            {
                return await _customerRepo.GetCustomerByAccountId(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            try
            {
                return await _customerRepo.GetCustomerById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<IList<InfomationUserAccountModelResponse>> GetInfoCustomer()
        {
            try
            {
                IList<Customer> customers = await _customerRepo.GetAllCustomer();
                if (customers != null && customers.Count > 0)
                {
                    IList<InfomationUserAccountModelResponse> listInfo = new List<InfomationUserAccountModelResponse>();
                    foreach (var customer in customers)
                    {
                        InfomationUserAccountModelResponse cus = new InfomationUserAccountModelResponse()
                        {
                            AccountId = customer.AccountId,
                            UserName = _accountRepo.GetAccountById(customer.AccountId).Result.Username,
                            FullName = customer.FullName,
                            Phone = customer.PhoneNumber,
                            Address = customer.Address,
                            Created = customer.CreatedDate,
                            Status = _accountRepo.GetAccountById(customer.AccountId).Result.Status
                        };
                        listInfo.Add(cus);
                    }
                    return listInfo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<Customer> Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
