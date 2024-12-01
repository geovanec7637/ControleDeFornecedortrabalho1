using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeFornecedor.Models
{
    [Table("Fornecedores")] // Nome da tabela no banco de dados
    public class FornecedorModel
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string EnderecoCompleto { get; set; }
        public string PessoaDeContato { get; set; }
    }
}
