using GestaoServicoSaude.Data;
using GestaoServicoSaude.Models;
using GestaoServicoSaude.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GestaoServicoSaude.Services
{
    public class ContactoService : IRepository<Contacto>
    {
        private readonly Context _context;

        public ContactoService(Context context)
        {
            _context = context;
        }

        public Task AddAsync(Contacto entity)
        {
            _context.Contacto.Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contacto>> GetAllAsync()
        {
            return _context.Contacto.ToListAsync() == null ? throw new InvalidOperationException() : await _context.Contacto.ToListAsync();
        }

        public async Task<Contacto> GetByIdAsync(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "");
            }

            return _context.Contacto.FirstOrDefaultAsync(entity => entity.Id == id) == null ? throw new InvalidOperationException() : await _context.Contacto.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public Task UpdateAsync(Contacto entity)
        {
            throw new NotImplementedException();
        }
    }
}
