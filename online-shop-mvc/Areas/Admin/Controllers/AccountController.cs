using Microsoft.AspNetCore.Mvc;
using online_shop_mvc.Services;

namespace online_shop_mvc.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("Account/HandleUpdateStatusAccount/{accountid:int}/{status:int}")]
        public async Task<IActionResult> HandleUpdateStatusAccount([FromQuery(Name = "status")] int status, [FromQuery(Name = "accountid")] int accountid)
        {
            //int status = Int32.Parse(Request.Query["status"]);
            //int accountId = Int32.Parse(Request.Query["accountid"]);
            await _accountService.UpdateStatus(accountid, status);
            return RedirectToAction("Index", "Customer");
        }
    }
}
