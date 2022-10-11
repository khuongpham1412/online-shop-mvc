using Model.Entities;
using online_shop_mvc.Services;
using Repository.Repo;

namespace online_shop_mvc.ServicesImp
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepo _categoryRepo;
        public CategoryService(CategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public Task<Category> Add(Category category)
        {
            return _categoryRepo.Add(category);
        }
        public Task<bool> Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Category>> GetAllCategory()
        {
            try
            {
                IList<Category> categories = await _categoryRepo.GetAllCategory();

                if (categories != null)
                {
                    return categories;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            return null;
        }

        public Task<Category> Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
