using MatchMyTrip.Application.contracts;
using MatchMyTrip.Persistence.context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Persistence.repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MatchMyTripDbContext _context;

        public Repository(MatchMyTripDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> DeleteAsync(Guid id)
        {
            var objectToRemove = await _context.Set<T>().FindAsync(id);

            if(objectToRemove != null)
            {
                _context.Set<T>().Remove(objectToRemove);
                _context.SaveChangesAsync();
            }

            return objectToRemove;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
