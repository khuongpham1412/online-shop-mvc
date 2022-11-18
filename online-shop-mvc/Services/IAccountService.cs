using Model.Entities;

namespace online_shop_mvc.Services
{
	public interface IAccountService
	{
		public Task<IList<Account>> GetAllAccounts();
		public Task<Account> CheckLogin(string username, string password);
		public Task<Boolean> BlockAccount(string id, string status);
	}
}
