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

        public Task<IEnumerable<Municipio>> GetAllAsync()
        {
            return _context.Municipio.ToListAsync() == null ? throw new InvalidOperationException() : await _context.Municipio.ToListAsync();
        }

        public Task<Municipio> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "");
            }

            return _context.Municipio.FirstOrDefaultAsync(entity => entity.Id == id) == null ? throw new InvalidOperationException() : await _context.Municipio.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public Task UpdateAsync(Municipio entity)
        {
            throw new NotImplementedException();
        }
    }
}
