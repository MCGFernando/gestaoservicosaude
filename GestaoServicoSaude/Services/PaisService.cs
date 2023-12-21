using GestaoServicoSaude.Data;
using GestaoServicoSaude.Models;
using GestaoServicoSaude.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestaoServicoSaude.Services
{
    public class PaisService : IRepository<Pais>
    {
        private readonly Context _context; 
        public PaisService(Context context)
        {
            _context = context;
        }

        public Task AddAsync(Pais entity)
        {
            _context.Pais.Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pais>> GetAllAsync()
        {
            return _context.Pais.ToListAsync() == null ? throw new InvalidOperationException() : await _context.Pais.ToListAsync();
        }

        public async Task<Pais> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "");
            }

            return _context.Pais.FirstOrDefaultAsync(entity => entity.Id == id) == null ? throw new InvalidOperationException() : await _context.Pais.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public Task UpdateAsync(Pais entity)
        {
            throw new NotImplementedException();
        }
    }
}
