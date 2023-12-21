namespace GestaoServicoSaude.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public string? NomeEndereco { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Referencia { get; set; }
        public string? CodigoPostal { get; set; }
        public bool Principal { get; set; } = true;
        public int? PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }
        public int? TipoEnderecoId { get; set; }
        public TipoEndereco? TipoEndereco { get; set; }

    }
}
