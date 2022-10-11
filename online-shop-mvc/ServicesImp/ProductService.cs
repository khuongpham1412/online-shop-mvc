using Microsoft.AspNetCore.Mvc.RazorPages;
using Model.Entities;
using online_shop_mvc.Services;
using Repository.Repo;

namespace online_shop_mvc.ServicesImp
{
    public class ProductService : IProductService
    {
        private readonly ProductRepo _productRepo = new ProductRepo();
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
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<bool> Delete(int ProductID)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Product>> GetAllProductsPaging(int page, int quantity)
        {
            try
            {
                IList<Product> products = await _productRepo.GetAllProductsPaging(page, quantity);

                if (products != null)
                {
                    return products;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<int> GetCountProduct()
        {
            try
            {
                int count = await _productRepo.GetCountProduct();

                if (count != -1)
                {
                    return count;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                var product = await _productRepo.GetProductById(id);

                if (product != null)
                {
                    return product;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Product> Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
