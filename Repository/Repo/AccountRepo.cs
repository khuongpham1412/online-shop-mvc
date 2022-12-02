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
    public class AccountRepo
    {
        private readonly OnlineShopDbContext _context = new OnlineShopDbContext();
        public async Task<Account> CheckLogin(string username, string password)
        {
            try
            {
                Account account = await _context.Accounts.Where(a => a.Username == username && a.Password == password).FirstOrDefaultAsync();
                await _context.SaveChangesAsync();
                return account;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public async Task<Account> UpdateStatus(int id, int status)
        {
            try
            {
                Account account = await GetAccountById(id);
                if(account != null)
                {
                    account.Status = status;
                    await _context.SaveChangesAsync();
                    return account;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Account> GetAccountById(int id)
        {
            try
            {
                return await _context.Accounts.Where(a => a.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public async Task<IList<Account>> GetAllAccounts()
        {
            try
            {
                return await _context.Accounts.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
