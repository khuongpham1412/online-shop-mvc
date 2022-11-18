using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Model.Models.Request;
using online_shop_mvc.Services;
using online_shop_mvc.ServicesImp;

namespace online_shop_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> handleLoadCategories()
        {
            IList<Category> category = await categoryService.GetAllCategories();
            if (category != null)
            {
                return Json(new { Status = "Success", Data = category });
            }

            return Json(new { Status = "Fail", Data = "null" });
        }


        [HttpPost]
        public async Task<JsonResult> handleEditCategory(Category data)
        {
            Category category = await categoryService.Update(data);
            if (category != null)
            {
                return Json(new { Status = "Success", Data = category });
            }

            return Json(new { Status = "Fail", Data = "null" });
        }

        [HttpPost]
        public async Task<JsonResult> handleAddCategory(Category data)
        {
            Category category = await categoryService.Add(data);
            if (category != null)
            {
                return Json(new { Status = "Success", Data = category });
            }

            return Json(new { Status = "Fail", Data = "null" });
        }
    }
}
