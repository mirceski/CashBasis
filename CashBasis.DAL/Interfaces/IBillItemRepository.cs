using CashBasis.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.DAL.Interfaces
{
    public interface IBillItemRepository : IBaseRepository<BillItem>
    {
        BillItem DeleteByBillId(int Id);
    }
}
