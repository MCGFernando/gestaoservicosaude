using GestaoServicoSaude.Data;
using GestaoServicoSaude.Models;
using GestaoServicoSaude.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestaoServicoSaude.Services
{
    public class MunicipioService : IRepository<Municipio>
    {
        private readonly Context _context;

        public MunicipioService(Context context)
        {
            _context = context;
        }

        public Task AddAsync(Municipio entity)
        {
            _context.Municipio.Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Municipio>> GetAllAsync()
        {
            return await _context.Municipio.Include(m => m.Provincia).ToListAsync();
        }

        public async Task<Municipio> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "");
            }

            return await _context.Municipio.Include(m => m.Provincia).FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task UpdateAsync(Municipio entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            bool hasAny = await _context.Municipio.AnyAsync(e => e.Id == entity.Id);

            if (!hasAny)
            {
                throw new ArgumentException();
            }
            try
            {
                _context.Municipio.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> MunicipioExists(int id)
        {
            bool hasAny = await _context.Municipio.AnyAsync(e => e.Id == id);
            return hasAny;
        }

        /* Methodos Adicionais */

        public async Task<IEnumerable<Municipio>> GetProvinciasByPaisIdAsync(int id)
        {
            
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "");
            }

            var municipios = from m in _context.Municipio
                             join pr in _context.Provincia on m.ProvinciaId equals pr.Id
                             where pr.PaisId == id
                             select new Municipio{ 
                             Id =    m.Id, 
                              Nome =   m.Nome 
                             };

            return await municipios.ToListAsync();
        }
    }
}
