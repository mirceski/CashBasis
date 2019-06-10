using CashBasis.DAL.Implementation;
using CashBasis.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashBasis.DAL.Interfaces
{
    public class BillItemRepository : BaseRepository<BillItem>, IBillItemRepository
    {
        public BillItemRepository(CBContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<BillItem>();
        }
        
        public async Task<BillItem> DeleteByBillId(int Id)
        {
            var entity = await _dbSet.SingleOrDefaultAsync(x => x.BillId == Id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
            return entity;
        }
    }
}
