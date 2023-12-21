using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestaoServicoSaude.Models;

namespace GestaoServicoSaude.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<GestaoServicoSaude.Models.Endereco> Endereco { get; set; } = default!;

        public DbSet<GestaoServicoSaude.Models.TipoEndereco>? TipoEndereco { get; set; }

        public DbSet<GestaoServicoSaude.Models.TipoContacto>? TipoContacto { get; set; }
        public DbSet<GestaoServicoSaude.Models.Provincia>? Provincia { get; set; }
        public DbSet<GestaoServicoSaude.Models.ProfissionalSaude>? ProfissionalSaude { get; set; }
        public DbSet<GestaoServicoSaude.Models.Pais>? Pais { get; set; }
        public DbSet<GestaoServicoSaude.Models.Paciente>? Paciente { get; set; }
        public DbSet<GestaoServicoSaude.Models.Municipio>? Municipio { get; set; }
        public DbSet<GestaoServicoSaude.Models.Funcionario>? Funcionario { get; set; }
        public DbSet<GestaoServicoSaude.Models.Contacto>? Contacto { get; set; }
    }
}
