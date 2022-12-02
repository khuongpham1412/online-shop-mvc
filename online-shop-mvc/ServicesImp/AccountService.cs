using Model.Entities;
using Model.Models.Response;
using online_shop_mvc.Models;
using online_shop_mvc.Services;
using Repository.Repo;

namespace online_shop_mvc.ServicesImp
{
	public class AccountService : IAccountService
	{
		private readonly AccountRepo accountRepo = new AccountRepo();
		private readonly CustomerRepo customerRepo = new CustomerRepo();
		public async Task<Account> UpdateStatus(int id, int status)
		{
			try
			{
				return await accountRepo.UpdateStatus(id, status);
			}catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return null;
        }

		public async Task<Account> CheckLogin(string username, string password)
		{
			return await accountRepo.CheckLogin(username, password);

        }

		public async Task<IList<Account>> GetAllAccounts()
		{
            try
            {
                return await accountRepo.GetAllAccounts();
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
                return await accountRepo.GetAccountById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

		public async Task<IList<InfomationUserAccountModelResponse>> GetInfoAccounts()
		{
			try
			{
				IList<Account> accounts = await accountRepo.GetAllAccounts();
				if(accounts != null && accounts.Count > 0)
				{
					IList<InfomationUserAccountModelResponse> listInfo = new List<InfomationUserAccountModelResponse>();
					foreach(var account in accounts)
					{
                        InfomationUserAccountModelResponse cus = new InfomationUserAccountModelResponse()
						{
							AccountId = account.Id,
							UserName = account.Username,
							FullName = customerRepo.GetCustomerByAccountId(account.Id).Result.FullName,
							Phone = customerRepo.GetCustomerByAccountId(account.Id).Result.PhoneNumber,
							Address = customerRepo.GetCustomerByAccountId(account.Id).Result.Address,
							Created = customerRepo.GetCustomerByAccountId(account.Id).Result.CreatedDate,
							Status = account.Status
                        };
						listInfo.Add(cus);
					}
					return listInfo;
				}
			}catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return null;
		}
	}
}
