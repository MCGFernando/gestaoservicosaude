namespace GestaoServicoSaude.Models
{
    public class Provincia
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int PaisId { get; set; }
        public Pais? Pais { get; set; }
    }
}
