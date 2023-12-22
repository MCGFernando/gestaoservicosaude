namespace GestaoServicoSaude.Models
{
    public class Parentesco
    {
        public int Id { get; set; }
        public Pessoa Pessoa { get; set;}
        public string GrauParentesco { get; set; }
    }
}
