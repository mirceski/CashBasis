using CashBasis.DAL.Implementation;
using CashBasis.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.DAL.Interfaces
{
    public class BillItemRepository : BaseRepository<BillItem>, IBillItemRepository
    {
        public BillItemRepository(CBContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<BillItem>();
        }

        public BillItem DeleteByBillId(int Id)
        {
            var entity = FindById(Id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
            return entity;
        }
    }
}
