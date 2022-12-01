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
    public class BillDetailRepo
    {
        private readonly OnlineShopDbContext _context = new OnlineShopDbContext();
        public async Task<BillDetail> Add(BillDetail billDetail)
        {
            try
            {
                await _context.BillDetails.AddAsync(billDetail);
                await _context.SaveChangesAsync();
                return billDetail;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public async Task<IList<BillDetail>> AddRanges(IList<BillDetail> billDetails)
        {
            try
            {
                await _context.BillDetails.AddRangeAsync(billDetails);
                await _context.SaveChangesAsync();
                return billDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public async Task<BillDetail> Update(BillDetail bill)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public async Task<IList<BillDetail>> GetAllBillDetails()
        {
            try
            {
                return await _context.BillDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
