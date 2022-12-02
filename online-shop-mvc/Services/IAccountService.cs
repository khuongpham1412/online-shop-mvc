using Model.Entities;
using Model.Models.Response;

namespace online_shop_mvc.Services
{
	public interface IAccountService
	{
		public Task<IList<Account>> GetAllAccounts();
		public Task<Account> CheckLogin(string username, string password);
		public Task<Account> UpdateStatus(int id, int status);
		public Task<Account> GetAccountById(int id);
        public Task<IList<InfomationUserAccountModelResponse>> GetInfoAccounts();
    }
}
