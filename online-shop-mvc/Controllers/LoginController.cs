using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Model.Entities;
using Model.Models.Request;
using Newtonsoft.Json;
using online_shop_mvc.Services;

namespace online_shop_mvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAccountService accountService;
        public LoginController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> HandleLogin(LoginRequest login)
        {
            if (login != null)
            {
                Account account = await accountService.CheckLogin(login.Username, login.Password);
                if (account != null)
                {
                    HttpContext.Session.SetString("USER_LOGIN", JsonConvert.SerializeObject(account));
                }
                
            }
            return RedirectToAction("Index");
        }
    }
}
