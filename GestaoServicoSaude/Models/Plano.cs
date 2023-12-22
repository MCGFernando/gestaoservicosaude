namespace GestaoServicoSaude.Models
{
    public class Plano
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; } //Apolice
        public string Descricao { get; set; }

        public int ConvenioId { get; set; }
        public Convenio Convenio { get; set; }
    }
}
