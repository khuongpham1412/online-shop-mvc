using Model.Entities;

namespace online_shop_mvc.Services
{
    public interface ICustomerService
    {
        Task<Customer> Add(Customer customer);
        Task<Customer> Update(Customer customer);
        Task<bool> Delete(int id);
        Task<Customer> GetCustomerById(int id);
        Task<IList<Customer>> GetAllCustomer();
    }
}
