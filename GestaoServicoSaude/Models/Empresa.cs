namespace GestaoServicoSaude.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set;}
        public string RazaoSocial { get; set;}
        public string NIF { get; set;}
        public bool Activo { get; set; } = true;
        public List<Contacto> Contacto { get; set; }
        public List<Endereco> Endereco { get; set; }
    }
}
