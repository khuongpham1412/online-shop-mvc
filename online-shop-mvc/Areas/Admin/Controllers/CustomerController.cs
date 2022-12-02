using Microsoft.AspNetCore.Mvc;
using Model.Models.Response;
using online_shop_mvc.Services;

namespace online_shop_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<IActionResult> Index()
        {
            IList<InfomationUserAccountModelResponse> lists = await _customerService.GetInfoCustomer();
            return View(lists);
        }
    }
}
