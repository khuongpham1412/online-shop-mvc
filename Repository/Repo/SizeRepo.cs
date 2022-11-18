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
    public class SizeRepo
    {
        private readonly OnlineShopDbContext _onlineShopDbContext = new OnlineShopDbContext();
        public async Task<Size> Add(Size size)
        {
            try
            {
                _onlineShopDbContext.Sizes.Add(size);
                await _onlineShopDbContext.SaveChangesAsync();
                return size;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Size> Update(Size size)
        {
            try
            {
                _onlineShopDbContext.Sizes.Update(size);
                await _onlineShopDbContext.SaveChangesAsync();
                return size;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<bool> Delete(Size size)
        {
            try
            {
                _onlineShopDbContext.Sizes.Remove(size);
                await _onlineShopDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<IList<Size>> GetAllSize()
        {
            try
            {
                return await _onlineShopDbContext.Sizes.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Size> GetSizeById(int id)
        {
            try
            {
                return await _onlineShopDbContext.Sizes.Where(s => s.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
