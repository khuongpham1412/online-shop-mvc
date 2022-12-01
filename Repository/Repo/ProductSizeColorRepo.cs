using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.ShopDbContext;
using System;
using System.Collections;
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
        public async Task<bool> UpdateQuantity(int productId, int sizeId, int colorId, int quantity)
        {
            try
            {
               var product = await _onlineShopDbContext.ProductSizeColors.Where(p => p.ProductId == productId && p.SizeId == sizeId && p.ColorId == colorId).FirstOrDefaultAsync();
                if(product != null)
                {
                    product.Quantity = quantity;
                }
                await _onlineShopDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
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

        /*public async Task<ProductSizeColor> GetQuantityProductFromSizeAndColor(int productID, int sizeID, int colorID)
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
        }*/

        public async Task<IList<ProductSizeColor>> GetColorByProductAndSize(int productID, int sizeID)
        {
            try
            {
                IList<ProductSizeColor> response = new List<ProductSizeColor>();
                var colors = (IList<ProductSizeColor>)_onlineShopDbContext.ProductSizeColors
                    .Where(p => p.ProductId == productID && p.SizeId == sizeID)
                    .AsEnumerable()
                    .ToList();

                foreach(var color in colors)
                {
                    int quantity = await this.GetQuantityByProductSizeColor((int)color.ProductId, (int)color.SizeId,(int) color.ColorId);
                    if(quantity > 0)
                    {
                        response.Add(color);
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public async Task<IList<ProductSizeColor>> GetSizeByProductId(int productID)
        {
            try
            {
                var sizes = (IList<ProductSizeColor>) _onlineShopDbContext.ProductSizeColors
                    .Where(p => p.ProductId == productID)
                    .AsEnumerable()
                    .GroupBy(p => p.SizeId)
                    .SelectMany(p => p)
                    .ToList();

                return sizes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        /* public async Task<ProductSizeColor> GetQuantityProductFromSizeAndColor(int productID, int sizeID, int colorID)
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
         }*/

        public async Task<int> GetQuantityByProductSizeColor(int productID, int sizeID, int colorID)
        {
            var product = await _onlineShopDbContext.ProductSizeColors.Where(p => p.ProductId == productID && p.SizeId == sizeID && p.ColorId == colorID).FirstOrDefaultAsync();
            return product.Quantity;
        }
    }
}
