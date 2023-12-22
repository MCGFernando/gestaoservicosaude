namespace GestaoServicoSaude.Models
{
    public class Procedimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public bool Activo { get; set; } = true;   // Se o procedimento pode ser usado ou nao
        public bool Exclusao { get; set; } = false; // Se dentro do convenio o procedimento é exclusao ou nao ?????? pensar bem nesta implementacao
    }
}
