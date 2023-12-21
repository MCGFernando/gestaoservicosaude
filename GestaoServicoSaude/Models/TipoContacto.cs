using System.ComponentModel.DataAnnotations;

namespace GestaoServicoSaude.Models
{
    public class TipoContacto
    {
        //Funcionario, Paciente, Profissinal ...
        [Key]
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
    }
}
