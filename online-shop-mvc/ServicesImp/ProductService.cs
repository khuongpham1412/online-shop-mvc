using Model.Entities;
using online_shop_mvc.Services;
using Repository.Repo;

namespace online_shop_mvc.ServicesImp
{
    public class ProductService : IProductService
    {
        private readonly ProductRepo _productRepo;
        public ProductService(ProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public Task<Product> Add(Product product)
        {
            try
            {
                var Response = _productRepo.Add(product);
                if(Response != null)
                {
                    return Response;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public Task<bool> Delete(int ProductID)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Product>> GetAllProductPaging(int page, int quantity)
        {
            try
            {
                IList<Product> products = await _productRepo.GetAllCategoryPaging(page, quantity);

                if (products != null)
                {
                    return products;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public Task<Product> Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
