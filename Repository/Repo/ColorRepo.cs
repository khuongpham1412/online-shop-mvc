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
    public class ColorRepo
    {
        private readonly OnlineShopDbContext _onlineShopDbContext = new OnlineShopDbContext();
        public async Task<Color> Add(Color color)
        {
            try
            {
                _onlineShopDbContext.Colors.Add(color);
                await _onlineShopDbContext.SaveChangesAsync();
                return color;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Color> Update(Color color)
        {
            try
            {
                _onlineShopDbContext.Colors.Add(color);
                await _onlineShopDbContext.SaveChangesAsync();
                return color;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<bool> Delete(Color color)
        {
            try
            {
                _onlineShopDbContext.Colors.Remove(color);
                await _onlineShopDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<IList<Color>> GetAllColor()
        {
            try
            {
                return await _onlineShopDbContext.Colors.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Color> GetColorById(int id)
        {
            try
            {
                return await _onlineShopDbContext.Colors.Where(s => s.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
