using Model.Entities;

namespace online_shop_mvc.Services
{
    public interface ICategoryService
    {
        public Task<Category> Add(Category category);
        public Task<Category> Update(Category category);
        public Task<bool> Delete(Category category);
        public Task<IList<Category>> GetAllCategory();
    }
}
