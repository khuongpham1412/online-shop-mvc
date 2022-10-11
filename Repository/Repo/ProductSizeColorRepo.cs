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
    public class ProductSizeColorRepo
    {
        private readonly OnlineShopDbContext _onlineShopDbContext = new OnlineShopDbContext();
        public async Task<ProductSizeColor> Add(ProductSizeColor ProductSizeColor)
        {
            try
            {
                _onlineShopDbContext.ProductSizeColors.Add(ProductSizeColor);
                await _onlineShopDbContext.SaveChangesAsync();
                return ProductSizeColor;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<ProductSizeColor> Update(ProductSizeColor ProductSizeColor)
        {
            try
            {
                _onlineShopDbContext.ProductSizeColors.Add(ProductSizeColor);
                await _onlineShopDbContext.SaveChangesAsync();
                return ProductSizeColor;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<bool> Delete(ProductSizeColor ProductSizeColor)
        {
            try
            {
                _onlineShopDbContext.ProductSizeColors.Remove(ProductSizeColor);
                await _onlineShopDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<IList<ProductSizeColor>> GetAllProductSizeColor()
        {
            try
            {
                return await _onlineShopDbContext.ProductSizeColors.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<ProductSizeColor> GetProductSizeColorById(int id)
        {
            try
            {
                return await _onlineShopDbContext.ProductSizeColors.Where(s => s.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<ProductSizeColor> GetQuantityProductFromSizeAndColor(int productID, int sizeID, int colorID)
        {
            try
            {
                return await _onlineShopDbContext.ProductSizeColors.Where(s => s.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<ProductSizeColor> GetColorFromProductSize(int productID, int sizeID)
        {
            try
            {
                return await _onlineShopDbContext.ProductSizeColors.Where(s => s.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<ProductSizeColor> GetQuantityProductFromSizeAndColor(int productID, int sizeID, int colorID)
        {
            try
            {
                return await _onlineShopDbContext.ProductSizeColors.Where(s => s.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
