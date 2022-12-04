using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.ShopDbContext;
using online_shop_mvc.Models.Request;
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

        public async Task<IList<Product>> GetAllProductsPaging1(FilterRequestModel filterRequest)
        {
            try
            {
                var nameSearch = (string) filterRequest.NameSearch;
                var prices = (IList<decimal>) filterRequest.Price;
                var sizes = (IList<string>) filterRequest.Size;
                var colors = (IList<string>) filterRequest.Color;

                return await _onlineShopDbContext.Products.Skip((filterRequest.PageIndex * filterRequest.PageSize) - filterRequest.PageSize).Take(filterRequest.PageSize).Where(p => p.Name == nameSearch).ToListAsync();
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
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                return await _onlineShopDbContext.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        } 

        public async Task<IList<Product>> GetAllProductByCategoryId(int categoryID)
        {
            try
            {
                return await _onlineShopDbContext.Products.Where(p => p.CategoryID == categoryID).ToListAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        //public async Task<int> GetLatestProductId()
        //{
        //    try
        //    {
        //        return await _onlineShopDbContext.Products.OrderByDescending()
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return null;
        //}
    }
}
