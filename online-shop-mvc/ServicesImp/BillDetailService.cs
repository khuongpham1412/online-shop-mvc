using Model.Entities;
using Model.Models.Response;
using online_shop_mvc.Services;
using Repository.Repo;

namespace online_shop_mvc.ServicesImp
{
    public class BillDetailService : IBillDetailService
    {
        private readonly BillDetailRepo _billDetailRepo = new BillDetailRepo();
        private readonly ProductRepo _productRepo = new ProductRepo();
        private readonly SizeRepo _sizeRepo = new SizeRepo();
        private readonly ColorRepo _colorRepo = new ColorRepo();
        public Task<BillDetail> Add(BillDetail billDetail)
        {
            try
            {
                return _billDetailRepo.Add(billDetail);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<IList<BillDetail>> AddRanges(IList<BillDetail> billDetail)
        {
            try
            {
                return _billDetailRepo.AddRanges(billDetail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<IList<CustomerOrderResponseModel>> GetAllBillDetailsByBillId(int billId)
        {
            try
            {
                IList<CustomerOrderResponseModel> response = new List<CustomerOrderResponseModel>();
                var billDetail = (IList<BillDetail>) await _billDetailRepo.GetAllBillDetailsByBillId(billId);
                if (billDetail != null)
                {
                    foreach (var item in billDetail)
                    {
                        Product product = await _productRepo.GetProductById((int)item.ProductId);
                        Size size = await _sizeRepo.GetSizeById((int)item.SizeId);
                        Color color = await _colorRepo.GetColorById((int)item.ColorId);

                        string sizeName = size.Name;
                        string colorName = color.Name;
                        int quantity = item.Quantity;
                        decimal price = product.Price;
                        decimal unitPrice = price * quantity;

                        var customerOrder = new CustomerOrderResponseModel()
                        {
                            SizeId = item.SizeId,
                            SizeName = sizeName,
                            ColorId = item.ColorId,
                            ColorName = colorName,
                            ProductId = item.ProductId,
                            UnitPrice = unitPrice,
                            Price = price,
                            PathImage = product.Image,
                            ProductName = product.Name,
                            OrderDetailId = (int)item.Id,
                            BillId = (int)item.BillId,
                            Quantity = quantity,
                        };

                        response.Add(customerOrder);
                    }

                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public Task<BillDetail> GetBillDetailById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BillDetail> Update(BillDetail billDetail)
        {
            throw new NotImplementedException();
        }
    }
}
