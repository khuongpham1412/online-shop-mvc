using Model.Entities;

namespace online_shop_mvc.Services
{
    public interface ISizeService
    {
        public Task<Size> Add(Size size);
        public Task<Size> Update(Size size);
        public Task<bool> Delete(Size size);
        public Task<IList<Size>> GetAllSizes();
        public Task<Size> GetSizeById(int id);
    }
}
