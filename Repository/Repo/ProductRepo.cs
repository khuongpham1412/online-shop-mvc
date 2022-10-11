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
        private readonly OnlineShopDbContext _onlineShopDbContext;
        public ProductRepo(OnlineShopDbContext onlineShopDbContext)
        {
            _onlineShopDbContext = onlineShopDbContext;
        }
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

        public async Task<IList<Product>> GetAllCategoryPaging(int page, int quantity)
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
    }
}
