namespace GestaoServicoSaude.Models
{
    public class TipoContacto
    {
        //Funcionario, Paciente, Profissinal ...
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
    }
}
