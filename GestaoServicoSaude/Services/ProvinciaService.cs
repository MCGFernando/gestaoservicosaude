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
            return await _context.Provincia.Include(p => p.Pais).ToListAsync();
        }

        public async Task<Provincia> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "");
            }

            return await _context.Provincia.Include(p => p.Pais).FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task UpdateAsync(Provincia entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            bool hasAny = await _context.Provincia.AnyAsync(e => e.Id == entity.Id);

            if (!hasAny)
            {
                throw new ArgumentException();
            }
            try
            {
                _context.Provincia.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ProvinciaExists(int id)
        {
            bool hasAny = await _context.Provincia.AnyAsync(e => e.Id == id);
            return hasAny;
        }
    }
}
