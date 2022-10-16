﻿using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.ShopDbContext;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public class OrderDetailRepo
    {
        private readonly OnlineShopDbContext _onlineShopDbContext = new OnlineShopDbContext();
        public async Task<OrderDetail> Add(OrderDetail orderDetail)
        {
            try
            {
                _onlineShopDbContext.OrderDetails.Add(orderDetail);
                await _onlineShopDbContext.SaveChangesAsync();
                return orderDetail;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<OrderDetail> Update(OrderDetail orderDetail)
        {
            try
            {
                _onlineShopDbContext.OrderDetails.Update(orderDetail);
                await _onlineShopDbContext.SaveChangesAsync();
                return orderDetail;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<bool> Delete(OrderDetail orderDetail)
        {
            try
            {
                _onlineShopDbContext.OrderDetails.Remove(orderDetail);
                await _onlineShopDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<IList<OrderDetail>> GetAllOrderDetail()
        {
            try
            {
                return await _onlineShopDbContext.OrderDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            try
            {
                var orderDetail = await _onlineShopDbContext.OrderDetails.Where(s => s.Id == id).FirstOrDefaultAsync();
                return orderDetail;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<IList<OrderDetail>> GetAllOrderDetailsByOrderId(int orderId)
        {
            try
            {
                return await _onlineShopDbContext.OrderDetails.Where(s => s.OrderID == orderId).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<OrderDetail> CheckUserOrderProduct(int orderId, int productId, int sizeId, int colorId)
        {
            try
            {
                var userOrderProduct = await _onlineShopDbContext.OrderDetails.Where(o => o.OrderID == orderId && o.ProductID == productId && o.SizeID == sizeId && o.ColorID == colorId).FirstOrDefaultAsync();
                if(userOrderProduct != null)
                {
                    return userOrderProduct;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<int> GetCountOrderDetailsByOrderId(int orderId)
        {
            try
            {
                var count = await _onlineShopDbContext.OrderDetails.Where(o => o.OrderID == orderId).CountAsync();
                if (count != null)
                {
                    return count;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

    }
}
