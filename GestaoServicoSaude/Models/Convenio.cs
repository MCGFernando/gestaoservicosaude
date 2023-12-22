namespace GestaoServicoSaude.Models
{
    public class Convenio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get;}
        public DateTime DataFim { get;}
        public bool Activo { get; set; }
        public int UnidadeAtendimentoId { get; set; }
        public UnidadeAtendimento UnidadeAtendimento { get; set; }
    }
}
