using Model.Entities;

namespace online_shop_mvc.Services
{
    public interface IColorService
    {
        public Task<Color> Add(Color color);
        public Task<Color> Update(Color color);
        public Task<bool> Delete(Color color);
        public Task<IList<Color>> GetAllColors();
        public Task<Color> GetColorById(int id);
    }
}
