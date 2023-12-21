using GestaoServicoSaude.Data;
using GestaoServicoSaude.Models;
using GestaoServicoSaude.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestaoServicoSaude.Services
{
    public class FuncionarioService : IRepository<Funcionario>
    {
        private readonly Context _context; 
        public FuncionarioService(Context context)
        {
            _context = context;
        }

        public Task AddAsync(Funcionario entity)
        {
            _context.Funcionario.Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Funcionario>> GetAllAsync()
        {
            return _context.Funcionario.ToListAsync() == null ? throw new InvalidOperationException() : await _context.Funcionario.ToListAsync();
        }

        public async Task<Funcionario> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "");
            }

            return _context.Funcionario.FirstOrDefaultAsync(entity => entity.Id == id) == null ? throw new InvalidOperationException() : await _context.Funcionario.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public Task UpdateAsync(Funcionario entity)
        {
            throw new NotImplementedException();
        }
    }
}
