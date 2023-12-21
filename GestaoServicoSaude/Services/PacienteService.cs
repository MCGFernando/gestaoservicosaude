using GestaoServicoSaude.Data;
using GestaoServicoSaude.Models;
using GestaoServicoSaude.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestaoServicoSaude.Services
{
    public class PacienteService : IRepository<Paciente>
    {
        private readonly Context _context; 
        public PacienteService(Context context)
        {
            _context = context;
        }

        public Task AddAsync(Paciente entity)
        {
            _context.Paciente.Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            return _context.Paciente.ToListAsync() == null ? throw new InvalidOperationException() : await _context.Paciente.ToListAsync();
        }

        public async Task<Paciente> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "");
            }

            return _context.Paciente.FirstOrDefaultAsync(entity => entity.Id == id) == null ? throw new InvalidOperationException() : await _context.Paciente.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public Task UpdateAsync(Paciente entity)
        {
            throw new NotImplementedException();
        }
    }
}
