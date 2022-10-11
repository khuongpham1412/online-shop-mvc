using Microsoft.AspNetCore.Mvc;

namespace online_shop_mvc.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
