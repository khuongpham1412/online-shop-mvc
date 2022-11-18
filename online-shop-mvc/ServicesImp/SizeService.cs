using Model.Entities;
using online_shop_mvc.Services;
using Repository.Repo;

namespace online_shop_mvc.ServicesImp
{
    public class SizeService : ISizeService
    {
        private readonly SizeRepo _sizeRepo = new SizeRepo();
        public Task<Size> Add(Size size)
        {
            try
            {
                var Response = _sizeRepo.Add(size);
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

        public async Task<bool> Delete(Size size)
        {
            try
            {
                if (await _sizeRepo.Delete(size))
                {
                    return true;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<IList<Size>> GetAllSizes()
        {
            try
            {
                var sizes = await _sizeRepo.GetAllSize();
                if(sizes != null)
                {
                    return sizes;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Size> GetSizeById(int id)
        {
            try
            {
                var size = await _sizeRepo.GetSizeById(id);
                if(size != null)
                {
                    return size;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Size> Update(Size size)
        {
            try
            {
                var res = await _sizeRepo.Update(size);
                if (res != null)
                {
                    return res;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
