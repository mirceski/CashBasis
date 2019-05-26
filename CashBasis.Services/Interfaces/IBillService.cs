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
        Task<BillDto> CreateBill(BillDto item);
        Task<BillDto> UpdateBill(int id, BillDto item);
        void RemoveBill(int id);
    }
}
