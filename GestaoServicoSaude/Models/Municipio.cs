namespace GestaoServicoSaude.Models
{
    public class Municipio
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia? Provincia { get; set; }
    }
}
