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
    public class EmployeeRepo
    {
        private readonly OnlineShopDbContext _onlineShopDbContext = new OnlineShopDbContext();
        public async Task<Employee> Add(Employee employee)
        {
            try
            {
                _onlineShopDbContext.Employees.Add(employee);
                await _onlineShopDbContext.SaveChangesAsync();
                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Employee> Update(Employee employee)
        {
            try
            {
                _onlineShopDbContext.Employees.Add(employee);
                await _onlineShopDbContext.SaveChangesAsync();
                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<bool> Delete(Employee employee)
        {
            try
            {
                _onlineShopDbContext.Employees.Remove(employee);
                await _onlineShopDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<IList<Employee>> GetAllEmployee()
        {
            try
            {
                return await _onlineShopDbContext.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

    }
}
