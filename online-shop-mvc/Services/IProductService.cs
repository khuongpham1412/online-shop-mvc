using Model.Entities;

namespace online_shop_mvc.Services
{
    public interface IProductService
    {
        public Task<Product> Add(Product product);
        public Task<Product> Update(Product product);
        public Task<bool> Delete(int ProductID);
        public Task<IList<Product>> GetAllProductsPaging(int page, int quantity);
        public Task<int> GetCountProduct();
        public Task<Product> GetProductById(int id);
        public Task<IList<Product>> GetAllProductByCategoryId(int categoryID);
        public Task<int> GetLatestProductId();
    }
}
