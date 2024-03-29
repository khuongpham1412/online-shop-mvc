﻿using Model.Entities;

namespace online_shop_mvc.Services
{
    public interface IProductService
    {
        public Task<Product> Add(Product product);
        public Task<Product> Update(Product product);
        public Task<bool> Delete(int ProductID);
        public Task<IList<Product>> GetAllProductPaging(int page, int quantity);
    }
}
