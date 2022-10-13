using Microsoft.AspNetCore.Mvc;

namespace online_shop_mvc.Areas.Admin.Controllers
{
    [Area("Home")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
