using Model.Entities;
using online_shop_mvc.Services;
using Repository.Repo;
using System.Reflection.Metadata.Ecma335;

namespace online_shop_mvc.ServicesImp
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepo _customerRepo = new CustomerRepo();
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
                IList<Customer> customers = await _customerRepo.GetAllCustomer();
                if(customers != null) return customers;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Customer> GetCustomerById(int id)
        {

            try
            {
                Customer customer = await _customerRepo.GetCustomerById(id);
                if (customer != null) return customer;
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
