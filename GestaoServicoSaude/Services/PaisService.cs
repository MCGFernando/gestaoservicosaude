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
            return await _context.Pais.ToListAsync();
        }

        public async Task<Pais> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "");
            }

            return await _context.Pais.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task UpdateAsync(Pais entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            bool hasAny = await _context.Pais.AnyAsync(e => e.Id == entity.Id);

            if (!hasAny)
            {
                throw new ArgumentException();
            }
            try
            {
                _context.Pais.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> PaisExists(int id)
        {
            bool hasAny = await _context.Pais.AnyAsync(e => e.Id == id);
            return hasAny;
        }
    }
}
