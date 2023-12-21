

using GestaoServicoSaude.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoServicoSaude.Repositories.impl
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Context _context;

       public Repository(Context context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

           
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
          return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
