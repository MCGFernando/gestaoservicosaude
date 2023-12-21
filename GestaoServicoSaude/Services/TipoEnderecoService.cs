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
            return  await _context.TipoEndereco.ToListAsync();
        }

        public async Task<TipoEndereco> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "");
            }

            return await _context.TipoEndereco.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task UpdateAsync(TipoEndereco entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            bool hasAny = await _context.TipoEndereco.AnyAsync(e => e.Id == entity.Id);

            if (!hasAny)
            {
                throw new ArgumentException();
            }
            try
            {
                _context.TipoEndereco.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> TipoEnderecoExists(int id)
        {
            bool hasAny = await _context.TipoEndereco.AnyAsync(e => e.Id == id);
            return hasAny;
        }
    }
}
