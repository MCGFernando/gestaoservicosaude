namespace GestaoServicoSaude.Models
{
    public class ProfissionalSaude : Pessoa
    {
        public int Id { get; set; }
        public string RegistroProfissional { get; set; } //Nº da ordem dos médicos
        public string Mecanografico { get; set; }
        public string NIF { get; set; }

    }
}
