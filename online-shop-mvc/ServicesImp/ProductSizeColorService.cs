using online_shop_mvc.Services;
using Model.Entities;
using System.Linq.Expressions;
using Repository.Repo;

namespace online_shop_mvc.ServicesImp
{
    public class ProductSizeColorService : IProductSizeColorService
    {
        private readonly ProductSizeColorRepo _productSizeColorRepo = new ProductSizeColorRepo();
        public Task<ProductSizeColor> Add(ProductSizeColor productSizeColor)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(ProductSizeColor productSizeColor)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ProductSizeColor>> GetAllProductSizeColor()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ProductSizeColor>> GetColorByProductAndSize(int productID, int sizeID)
        {
            try
            {
                return await _productSizeColorRepo.GetColorByProductAndSize(productID, sizeID);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<int> GetQuantityByProductSizeColor(int productID, int sizeID, int colorID)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ProductSizeColor>> GetSizeByProductId(int productID)
        {
            try
            {
                return await _productSizeColorRepo.GetSizeByProductId(productID);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<ProductSizeColor> Update(ProductSizeColor productSizeColor)
        {
            throw new NotImplementedException();
        }
    }
}
