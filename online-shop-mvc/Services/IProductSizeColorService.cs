using Model.Entities;

namespace online_shop_mvc.Services
{
    public interface IProductSizeColorService
    {
        public Task<ProductSizeColor> Add(ProductSizeColor productSizeColor);
        public Task<ProductSizeColor> Update(ProductSizeColor productSizeColor);
        public Task<bool> Delete(ProductSizeColor productSizeColor);
        public Task<IList<ProductSizeColor>> GetAllCategories();
        public Task<IList<ProductSizeColor>> GetColorByProductAndSize(int productID,int sizeID);
        public Task<IList<ProductSizeColor>> GetSizeByProductId(int productID);
    }
}
