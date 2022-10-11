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
    public class ProductRepo
    {
        private readonly OnlineShopDbContext _onlineShopDbContext = new OnlineShopDbContext();
        public async Task<Product> Add(Product product)
        {
            try
            {
                _onlineShopDbContext.Products.Add(product);
                _onlineShopDbContext.SaveChangesAsync();
                return product;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return null;
        }
        public async Task<Product> Update(Product product)
        {
            try
            {
                _onlineShopDbContext.Products.Add(product);
                await _onlineShopDbContext.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<bool> Delete(Product product)
        {
            try
            {
                _onlineShopDbContext.Products.Remove(product);
                await _onlineShopDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public async Task<IList<Product>> GetAllProductsPaging(int page, int quantity)
        {
            try
            {
                return await _onlineShopDbContext.Products.Skip((page * quantity) - quantity).Take(quantity).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public async Task<int> GetCountProduct()
        {
            try
            {
                return await _onlineShopDbContext.Products.CountAsync();
            }
            catch (Exception ex)
            {
                return -1;
            }
            return -1;
        }
    }
}
