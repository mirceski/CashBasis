using CashBasis.DAL.Implementation;
using CashBasis.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashBasis.DAL.Interfaces
{
    public class BillRepository : BaseRepository<Bill>, IBillRepository
    {
        public BillRepository(CBContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Bill>();
        }

        public IQueryable<Bill> GetAllBillsWithRelatedEntities()
        {
            return _dbSet.Include(x => x.BillItems)
                .Include(x => x.Category)
                .Include(x => x.Recurrence);
        }

        public Bill GetBillWithRelatedEntitiesById(int id)
        {
            return _dbSet.Include(x => x.BillItems)
                .Include(x =>x.Category)
                .Include(x => x.Recurrence)
                .SingleOrDefault(x => x.BillId == id);
        }
    }
}
