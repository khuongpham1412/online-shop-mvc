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

            }
            return null;
        }
    }
}
