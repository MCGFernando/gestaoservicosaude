namespace GestaoServicoSaude.Models
{
    public class TipoEndereco
    {
        //Funcionario, Paciente, Profissinal ...
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
    }
}
