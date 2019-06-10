using CashBasis.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashBasis.DAL.Interfaces
{
    public interface IBillItemRepository : IBaseRepository<BillItem>
    {
        Task<BillItem> DeleteByBillId(int Id);
    }
}
