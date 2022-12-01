﻿using Model.Entities;

namespace online_shop_mvc.Services
{
    public interface IBillService
    {
        public Task<Bill> Add(Bill bill);
        public Task<IList<Bill>> AddRanges(IList<Bill> bills);
        public Task<Bill> Update(Bill bill);
        public Task<bool> Delete(int BillId);
        public Task<IList<Bill>> GetAllBill();
    }
}