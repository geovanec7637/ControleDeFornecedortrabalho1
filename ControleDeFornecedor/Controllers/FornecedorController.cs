using ControleDeFornecedor._Repositorio;
using ControleDeFornecedor.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeFornecedor.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;

        public FornecedorController(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }

        // Exibe a lista de fornecedores
        public IActionResult Index()
        {
            List<FornecedorModel> fornecedores = _fornecedorRepositorio.BuscarTodos();
            return View(fornecedores);
        }

        // Exibe o formulário para criar um novo fornecedor
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(FornecedorModel fornecedor)
        {
            if (ModelState.IsValid)
            {
                _fornecedorRepositorio.Adicionar(fornecedor);
                return RedirectToAction("Index");
            }

            return View(fornecedor);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            FornecedorModel fornecedor = _fornecedorRepositorio.ListarPorId(id);
            return View(fornecedor);
        }
        public IActionResult Apagar(int id)
        {
            _fornecedorRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }
        
        public IActionResult Editar(int id)
        {
            FornecedorModel fornecedor = _fornecedorRepositorio.ListarPorId(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // Processa as alterações no fornecedor
        [HttpPost]
        public IActionResult Editar(FornecedorModel fornecedor)
        {
            if (ModelState.IsValid)
            {
                _fornecedorRepositorio.Atualizar(fornecedor);
                return RedirectToAction("Index");
            }

            return View(fornecedor);
        }
    }
}
