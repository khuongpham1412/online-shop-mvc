using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.ShopDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public class CustomerRepo
    {
        private readonly OnlineShopDbContext _onlineShopDbContext = new OnlineShopDbContext();
        public async Task<Customer> Add(Customer customer)
        {
            try
            {
                await _onlineShopDbContext.Customers.AddAsync(customer);
                await _onlineShopDbContext.SaveChangesAsync();
                return customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Customer> Update(Customer customer)
        {
            try
            {
                _onlineShopDbContext.Customers.Add(customer);
                await _onlineShopDbContext.SaveChangesAsync();
                return customer;
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
                Customer customer = await _onlineShopDbContext.Customers.FindAsync(id);
                if(customer != null)
                {
                    return customer;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public async Task<Customer> GetCustomerByAccountId(int id)
        {
            try
            {
                return await _onlineShopDbContext.Customers.Where(c => c.AccountId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<bool> Delete(Customer customer)
        {
            try
            {
                _onlineShopDbContext.Customers.Remove(customer);
                await _onlineShopDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<IList<Customer>> GetAllCustomer()
        {
            try
            {
                return await _onlineShopDbContext.Customers.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

    }
}
