using ControleDeFornecedor.Data;
using ControleDeFornecedor.Models;

namespace ControleDeFornecedor._Repositorio
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly BancoContext _bancoContext;

        public FornecedorRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public FornecedorModel ListarPorId(int id)
        {
            return _bancoContext.Fornecedores.FirstOrDefault(x => x.Id == id);
        }
        public List<FornecedorModel> BuscarTodos()
        {
            return _bancoContext.Fornecedores.ToList();
        }

        public FornecedorModel Adicionar(FornecedorModel fornecedor)
        {
            _bancoContext.Fornecedores.Add(fornecedor);
            _bancoContext.SaveChanges();
            return fornecedor;
        }

        public FornecedorModel Atualizar(FornecedorModel fornecedor)
        {
            FornecedorModel fornecedorDB = ListarPorId(fornecedor.Id);

            if (fornecedorDB == null) throw new System.Exception("houve um erro na atualização do Fornecedor");
            fornecedorDB.RazaoSocial = fornecedor.RazaoSocial;
            fornecedorDB.NomeFantasia = fornecedor.NomeFantasia;
            fornecedorDB.Email = fornecedor.Email;
            fornecedorDB.Telefone = fornecedor.Telefone;
            fornecedorDB.EnderecoCompleto = fornecedor.EnderecoCompleto;
            fornecedorDB.PessoaDeContato = fornecedor.PessoaDeContato;

            _bancoContext.Fornecedores.Update(fornecedorDB);
            _bancoContext.SaveChanges();
            return fornecedorDB;
        }

        public bool Apagar(int id)
        {
            FornecedorModel fornecedorDB = ListarPorId(id);

            if (fornecedorDB == null) throw new System.Exception("houve um erro na deleção do Fornecedor");

            _bancoContext.Remove(fornecedorDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}