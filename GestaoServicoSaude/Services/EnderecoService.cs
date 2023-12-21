
using GestaoServicoSaude.Data;
using GestaoServicoSaude.Models;
using GestaoServicoSaude.Repositories;
using GestaoServicoSaude.Repositories.impl;
using Microsoft.EntityFrameworkCore;

namespace GestaoServicoSaude.Services
{
    public class EnderecoService : IRepository<Endereco>
    {
        private readonly Context _context;
        public EnderecoService(Context context)
        {
            _context = context;
        }

        public Task AddAsync(Endereco entity)
        {
            _context.Endereco.Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Endereco>> GetAllAsync()
        {
            return _context.Endereco.ToListAsync() == null ? throw new InvalidOperationException() : await _context.Endereco.ToListAsync();
        }

        public async Task<Endereco> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "");
            }

            return _context.Endereco.FirstOrDefaultAsync(entity => entity.Id == id) == null ? throw new InvalidOperationException() : await _context.Endereco.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public Task UpdateAsync(Endereco entity)
        {
            throw new NotImplementedException();
        }
    }
}
