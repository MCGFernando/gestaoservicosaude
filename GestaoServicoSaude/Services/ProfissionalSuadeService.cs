using GestaoServicoSaude.Data;
using GestaoServicoSaude.Models;
using GestaoServicoSaude.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestaoServicoSaude.Services
{
    public class ProfissionalSuadeService : IRepository<ProfissionalSaude>
    {
        private readonly Context _context; 
        public ProfissionalSuadeService(Context context)
        {
            _context = context;
        }

        public Task AddAsync(ProfissionalSaude entity)
        {
            _context.ProfissionalSaude.Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProfissionalSaude>> GetAllAsync()
        {
            return _context.ProfissionalSaude.ToListAsync() == null ? throw new InvalidOperationException() : await _context.ProfissionalSaude.ToListAsync();
        }

        public async Task<ProfissionalSaude> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "");
            }

            return _context.ProfissionalSaude.FirstOrDefaultAsync(entity => entity.Id == id) == null ? throw new InvalidOperationException() : await _context.ProfissionalSaude.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public Task UpdateAsync(ProfissionalSaude entity)
        {
            throw new NotImplementedException();
        }
    }
}
