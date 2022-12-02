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
    public class BillRepo
    {
        private readonly OnlineShopDbContext _context = new OnlineShopDbContext();
        public async Task<Bill> Add(Bill bill)
        {
            try
            {
                await _context.Bills.AddAsync(bill);
                await _context.SaveChangesAsync();
                return bill;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public async Task<IList<Bill>> AddRanges(IList<Bill> bills)
        {
            try
            {
                await _context.Bills.AddRangeAsync(bills);
                await _context.SaveChangesAsync();
                return bills;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Bill> GetBillById(int billId)
        {
            try
            {
                return await _context.Bills.Where(b => b.Id == billId).FirstOrDefaultAsync();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public async Task<Bill> UpdateStatus(int billId, int status)
        {
            try
            {
                Bill bill = await GetBillById(billId);
                if(bill != null)
                {
                    bill.Status = status;
                    await _context.SaveChangesAsync();
                    return bill;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public async Task<Bill> Update(Bill bill)
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
        public async Task<IList<Bill>> GetAllBills()
        {
            try
            {
                return await _context.Bills.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
