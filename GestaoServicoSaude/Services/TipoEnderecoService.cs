using GestaoServicoSaude.Repositories.impl;
using GestaoServicoSaude.Repositories;
using GestaoServicoSaude.Models;
using GestaoServicoSaude.Data;
using Microsoft.EntityFrameworkCore;
using GestaoServicoSaude.Migrations;

namespace GestaoServicoSaude.Services
{
    public class TipoEnderecoService : IRepository<TipoEndereco>
    {
        private readonly Context _context;

        public TipoEnderecoService(Context context)
        {
            _context = context;
        }

        public Task AddAsync(TipoEndereco entity)
        {
            _context.TipoEndereco.Add(entity);
            return _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            /*var tipoEndereco = GetByIdAsync(id);
            
            _context.TipoEndereco.Remove(tipoEndereco);
            await _context.SaveChangesAsync();
            return Task.CompletedTask;*/
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TipoEndereco>> GetAllAsync()
        {
            return _context.TipoEndereco.ToListAsync() == null ? throw new InvalidOperationException() : await _context.TipoEndereco.ToListAsync();
        }

        public async Task<TipoEndereco> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "");
            }

            return _context.TipoEndereco.FirstOrDefaultAsync(entity => entity.Id == id) == null ? throw new InvalidOperationException() : await _context.TipoEndereco.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public Task UpdateAsync(TipoEndereco entity)
        {
            throw new NotImplementedException();
        }
    }
}
