using GestaoServicoSaude.Models.Enums;

namespace GestaoServicoSaude.Models
{
    public class Paciente : Pessoa
    {
        public int Id { get; set; }
        public string NumeroBeneficiario { get; set; }    
        public double Peso { get; set; }    
        public double Altura { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public bool Alergia { get; set; } = false;
        //public List<string> Alergias { get; set; }
        public bool DoencaHereditaria { get; set; }
        //public List<string> DoencasHereditarias { get; set; }
        public bool Cirurgia { get; set; }
        public string CirurgiaDescricao { get; set; }
        public bool Activo { get; set; }    = true;
        public bool RecebeEmail { get; set; }    = true;
        public bool RecebeSMS { get; set; }    = true;

           
    }
}
