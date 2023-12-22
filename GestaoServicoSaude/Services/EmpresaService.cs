using GestaoServicoSaude.Data;
using GestaoServicoSaude.Models;
using GestaoServicoSaude.Repositories;

namespace GestaoServicoSaude.Services
{
    public class EmpresaService : IRepository<Empresa>
    {
        private readonly Context _context;

        public EmpresaService(Context context)
        {
            _context = context;
        }

        public Task AddAsync(Empresa entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Empresa>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Empresa> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Empresa entity)
        {
            throw new NotImplementedException();
        }
    }
}
