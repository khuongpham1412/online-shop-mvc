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
    public class CategoryRepo
    {
        private readonly OnlineShopDbContext _onlineShopDbContext = new OnlineShopDbContext();
       /* public CategoryRepo(OnlineShopDbContext onlineShopDbContext)
        {
            _onlineShopDbContext = onlineShopDbContext;
        }*/
        public async Task<Category> Add(Category category)
        {
            try
            {
                _onlineShopDbContext.Categories.Add(category);
                await _onlineShopDbContext.SaveChangesAsync();
                return category;
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        public async Task<Category> Update(Category category)
        {
            try
            {
                _onlineShopDbContext.Categories.Add(category);
                await _onlineShopDbContext.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<bool> Delete(Category category)
        {
            try
            {
                _onlineShopDbContext.Categories.Remove(category);
                await _onlineShopDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public async Task<IList<Category>> GetAllCategories()
        {
            try
            {
                return await _onlineShopDbContext.Categories.ToListAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return null;
        }
    }
}
