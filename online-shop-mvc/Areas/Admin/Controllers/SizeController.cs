using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using online_shop_mvc.Services;
using online_shop_mvc.ServicesImp;

namespace online_shop_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SizeController : Controller
    {
        private readonly ISizeService sizeService;
        public SizeController(ISizeService sizeService)
        {
            this.sizeService = sizeService;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> handleLoadSizes()
        {
            IList<Size> size = await sizeService.GetAllSizes();
            if (size != null)
            {
                return Json(new { Status = "Success", Data = size });
            }

            return Json(new { Status = "Fail", Data = "null" });
        }


        [HttpPost]
        public async Task<JsonResult> handleEditSize(Size data)
        {
            Size size = await sizeService.Update(data);
            if (size != null)
            {
                return Json(new { Status = "Success", Data = size });
            }

            return Json(new { Status = "Fail", Data = "null" });
        }

        [HttpPost]
        public async Task<JsonResult> handleAddSize(Size data)
        {
            Size size = await sizeService.Add(data);
            if (size != null)
            {
                return Json(new { Status = "Success", Data = size });
            }

            return Json(new { Status = "Fail", Data = "null" });
        }
    }
}
