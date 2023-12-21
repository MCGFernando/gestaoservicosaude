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
            return _context.TipoContacto.ToListAsync() == null ? throw new InvalidOperationException() : await _context.TipoContacto.ToListAsync();
        }

        public async Task<TipoContacto> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "");
            }

            return _context.TipoContacto.FirstOrDefaultAsync(entity => entity.Id == id) == null ? throw new InvalidOperationException() : await _context.TipoContacto.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public Task UpdateAsync(TipoContacto entity)
        {
            throw new NotImplementedException();
        }
    }
}
