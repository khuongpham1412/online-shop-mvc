using Model.Entities;
using online_shop_mvc.Services;
using Repository.Repo;

namespace online_shop_mvc.ServicesImp
{
	public class AccountService : IAccountService
	{
		private readonly AccountRepo accountRepo = new AccountRepo();
		public Task<bool> BlockAccount(string id, string status)
		{
			return null;

        }

		public Task<Account> CheckLogin(string username, string password)
		{
			return accountRepo.CheckLogin(username, password);

        }

		public Task<IList<Account>> GetAllAccounts()
		{
			throw new NotImplementedException();
		}
	}
}
