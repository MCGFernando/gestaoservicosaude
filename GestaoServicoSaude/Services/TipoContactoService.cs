using GestaoServicoSaude.Data;
using GestaoServicoSaude.Models;
using GestaoServicoSaude.Repositories;
using GestaoServicoSaude.Repositories.impl;
using Microsoft.EntityFrameworkCore;

namespace GestaoServicoSaude.Services
{
    public class TipoContactoService : IRepository<TipoContacto>
    {
        private readonly Context _context;

        public TipoContactoService(Context context)
        {
            _context = context;
        }

        public Task AddAsync(TipoContacto entity)
        {
            _context.TipoContacto.Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TipoContacto>> GetAllAsync()
        {
            return await _context.TipoContacto.ToListAsync();
        }

        public async Task<TipoContacto> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "");
            }

            return await _context.TipoContacto.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task UpdateAsync(TipoContacto entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            bool hasAny = await _context.TipoContacto.AnyAsync(e => e.Id == entity.Id);

            if (!hasAny)
            {
                throw new ArgumentException();
            }
            try
            {
                _context.TipoContacto.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> TipoContactoExists(int id)
        {
            bool hasAny = await _context.TipoContacto.AnyAsync(e => e.Id == id);
            return hasAny;
        }
    }
}
