using Model.Entities;
using online_shop_mvc.Services;
using Repository.Repo;

namespace online_shop_mvc.ServicesImp
{
    public class ColorService : IColorService
    {
        private readonly ColorRepo _colorRepo = new ColorRepo();
        public Task<Color> Add(Color color)
        {
            try
            {
                var Response = _colorRepo.Add(color);
                if (Response != null)
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

        public async Task<bool> Delete(Color color)
        {
            try
            {
                if (await _colorRepo.Delete(color))
                {
                    return true;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<IList<Color>> GetAllColors()
        {
            try
            {
                var colors = await _colorRepo.GetAllColor();
                if(colors != null)
                {
                    return colors;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Color> GetColorById(int id)
        {
            try
            {
                var color = await _colorRepo.GetColorById(id);
                if(color != null)
                {
                    return color;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<Color> Update(Color color)
        {
            throw new NotImplementedException();
        }
    }
}
