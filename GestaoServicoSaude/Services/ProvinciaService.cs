using GestaoServicoSaude.Data;
using GestaoServicoSaude.Models;
using GestaoServicoSaude.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestaoServicoSaude.Services
{
    public class ProvinciaService : IRepository<Provincia>
    {
        private readonly Context _context; 
        public ProvinciaService(Context context)
        {
            _context = context;
        }

        public Task AddAsync(Provincia entity)
        {
            _context.Provincia.Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Provincia>> GetAllAsync()
        {
            return _context.Provincia.ToListAsync() == null ? throw new InvalidOperationException() : await _context.Provincia.ToListAsync();
        }

        public async Task<Provincia> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "");
            }

            return _context.Provincia.FirstOrDefaultAsync(entity => entity.Id == id) == null ? throw new InvalidOperationException() : await _context.Provincia.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public Task UpdateAsync(Provincia entity)
        {
            throw new NotImplementedException();
        }
    }
}
