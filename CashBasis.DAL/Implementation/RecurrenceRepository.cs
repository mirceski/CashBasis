using CashBasis.DAL.Implementation;
using CashBasis.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashBasis.DAL.Interfaces
{
    public class RecurrenceRepository : BaseRepository<Recurrence>, IRecurrenceRepository
    {
        public RecurrenceRepository(CBContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Recurrence>();
        }
    }
}
