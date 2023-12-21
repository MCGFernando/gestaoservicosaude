using GestaoServicoSaude.Models.Enums;

namespace GestaoServicoSaude.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string BI { get; set; }
        public DateTime Nascimento { get; set; }
        public int? Nacionalidade { get; set; } // Será o Id do Pais selecionado
        public string? Naturalidade { get; set; }
        public Genero Genero { get; set; }
        public int? GeneroNascenca { get; set; }
        public bool Falecido { get; set; } = false;
        public DateTime? DataFalecido { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
    }
}
