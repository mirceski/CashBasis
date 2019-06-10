using CashBasis.BusinessModel.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashBasis.Services.Interfaces
{
    public interface IBillService
    {
        Task<List<BillDto>> GetAllBills(int pageNumber, int pageSize = 15);
        BillDto GetBillById(int id);
        BillCreateUpdateDto CreateBill(BillCreateUpdateDto item);
        BillItemsDto CreateBillItem(BillItemsDto item);
        BillItemsDto UpdateBillItem(int billItemId, BillItemsDto item);
        BillCreateUpdateDto UpdateBill(int id, BillCreateUpdateDto item);
        void RemoveBill(int id);
    }
}
