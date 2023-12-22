using GestaoServicoSaude.Models.Enums;

namespace GestaoServicoSaude.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        public string? Telefone { get; set; }
        public string? Telemovel { get; set; }
        public string? Email { get; set; }
        public string? Site { get; set; }
        public bool Principal { get; set; } = true;
        public int? PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
        public int? TipoContactoId { get; set; }
        public TipoContacto? TipoContacto { get; set; }
        public int? EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }
        public MeioContacto MeioContacto { get; set; } = MeioContacto.NENHUM;
    }
}
