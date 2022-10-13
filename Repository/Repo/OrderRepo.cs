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
    public class OrderRepo
    {
        private readonly OnlineShopDbContext _onlineShopDbContext = new OnlineShopDbContext();
        public async Task<int> Add(Order order)
        {
            try
            {
                _onlineShopDbContext.Orders.Add(order);
                await _onlineShopDbContext.SaveChangesAsync();
                return order.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        public async Task<Order> Update(Order order)
        {
            try
            {
                _onlineShopDbContext.Orders.Add(order);
                await _onlineShopDbContext.SaveChangesAsync();
                return order;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<bool> Delete(Order order)
        {
            try
            {
                _onlineShopDbContext.Orders.Remove(order);
                await _onlineShopDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<IList<Order>> GetAllOrder()
        {
            try
            {
                return await _onlineShopDbContext.Orders.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Order> GetOrderById(int id)
        {
            try
            {
                return await _onlineShopDbContext.Orders.Where(s => s.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<bool> CheckUserOrder(int userID)
        {
            try
            {
                var order = await _onlineShopDbContext.Orders.Where(s => s.CustomerID == userID).ToListAsync();
                return order.Count() == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<int> GetOrderIdByCustomerId(int userId)
        {
            try
            {
                var orderId = await _onlineShopDbContext.Orders.Where(s => s.CustomerID == userId).FirstOrDefaultAsync();
                return orderId.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }
    }
}
