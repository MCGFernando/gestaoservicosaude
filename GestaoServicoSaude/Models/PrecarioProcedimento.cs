namespace GestaoServicoSaude.Models
{
    public class PrecarioProcedimento
    {
        public int Id { get; set; }
        public int ProcedimentoId { get; set; }
        public Procedimento Procedimento { get; set; }
        public int PlanoId { get; set; }
        public Plano Plano { get; set; }
    }
}
