namespace GestaoServicoSaude.Models
{
    public class UnidadeAtendimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public int ConvenioId { get; set; }
        public Convenio Convenio { get; set; }
    }
}
