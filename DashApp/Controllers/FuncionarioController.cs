using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashApp.ViewsModels;
using DashAppData.Repositories;
using DashAppDomain.Cargos;
using DashAppDomain.Departamentos;
using DashAppDomain.Funcionarios;
using DashAppDomain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DashApp.Controllers
{
    public class FuncionarioController : Controller
    {

        private readonly FuncionarioStorer _funcionarioStorer;
        private readonly IRepository<Funcionario> _funcionarioRepository;
        private readonly IRepository<Cargo> _cargoRepository;
        private readonly IRepository<Departamento> _departamentoRepository;

        public FuncionarioController(FuncionarioStorer funcionarioStorer, 
                                     IRepository<Funcionario> funcionarioRepository, 
                                     IRepository<Cargo> cargoRepository, 
                                     IRepository<Departamento> departamentoRepository)
        {
            _funcionarioStorer = funcionarioStorer;
            _funcionarioRepository = funcionarioRepository;
            _cargoRepository = cargoRepository;
            _departamentoRepository = departamentoRepository;

        }

        // GET: Funcionario
        public ActionResult Index()
        {
            var funcionario = _funcionarioRepository.All();
            if (funcionario.Any())
            {
                var viewModel = funcionario.Select(p => new FuncionarioViewModel { Id = p.Id, Nome = p.Nome, Cpf = p.Cpf, CargoName = p.Cargo.Atribuicao, DepartamentoName = p.Departamento.Setor});
                return View(viewModel);
            }
            return View();
        }

        // GET: Funcionario/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = new FuncionarioViewModel();
            var cargos = _cargoRepository.All();
            var departamentos = _departamentoRepository.All();

            if (cargos.Any())
            {
                viewModel.Cargos = cargos.Select(c => new CargoViewModel { Id = c.Id, Atribuicao = c.Atribuicao });
            }
            if (departamentos.Any())
            {
                viewModel.Departamentos = departamentos.Select(c => new DepartamentoViewModel { Id = c.Id, Setor = c.Setor });
            }
            if (id > 0)
            {
                var funcionario = _funcionarioRepository.GetById(id);
                viewModel.Id = funcionario.Id;
                viewModel.Nome = funcionario.Nome;
                viewModel.Cpf = funcionario.Cpf;
                viewModel.Rg = funcionario.Rg;
                viewModel.Endereco = funcionario.Endereco;
                viewModel.Cep = funcionario.Cep;
                viewModel.Cidade = funcionario.Cidade;
                viewModel.Estado = funcionario.Estado;
                viewModel.Pais = funcionario.Pais;
                viewModel.CargoId = funcionario.Cargo.Id;
                viewModel.DepartamentoId = funcionario.Departamento.Id;

                return View(viewModel);
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateOrEdit(int id)
        {
            var viewModel = new FuncionarioViewModel();
            var cargos = _cargoRepository.All();
            var departamentos = _departamentoRepository.All();

            if (cargos.Any())
            {
                viewModel.Cargos = cargos.Select(c => new CargoViewModel { Id = c.Id, Atribuicao = c.Atribuicao });
            }
            if (departamentos.Any())
            {
                viewModel.Departamentos = departamentos.Select(c => new DepartamentoViewModel { Id = c.Id, Setor = c.Setor });
            }
            if(id > 0)
            {
                var funcionario = _funcionarioRepository.GetById(id);
                viewModel.Id = funcionario.Id;
                viewModel.Nome = funcionario.Nome;
                viewModel.Cpf = funcionario.Cpf;
                viewModel.Rg = funcionario.Rg;
                viewModel.Endereco = funcionario.Endereco;
                viewModel.Cep = funcionario.Cep;
                viewModel.Cidade = funcionario.Cidade;
                viewModel.Estado = funcionario.Estado;
                viewModel.Pais = funcionario.Pais;
                viewModel.CargoId = funcionario.Cargo.Id;
                viewModel.DepartamentoId = funcionario.Departamento.Id;

                return View(viewModel);
            }

            return View(viewModel);
        }

        // POST: Funcionario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrEdit(FuncionarioViewModel viewModel)
        {
            _funcionarioStorer.Store(viewModel.Id, viewModel.Nome, viewModel.Cpf, viewModel.Rg, viewModel.Endereco, viewModel.Cep, viewModel.Cidade, viewModel.Estado, viewModel.Pais, viewModel.CargoId, viewModel.DepartamentoId);
            return RedirectToAction("Index");
        }

        // GET: Funcionario/Delete/5
        [HttpGet]
        public ActionResult Deletar(int id)
        {
            var funcionario = _funcionarioRepository.GetById(id);
            if (funcionario != null)
            {
                _funcionarioRepository.Delete(funcionario);
                return RedirectToAction("Index");
            }

            return View();
        }

        // POST: Funcionario/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Deletar(int id)
        //{
        //    var funcionario = _funcionarioRepository.GetById(id);
        //    if(funcionario != null)
        //    {
        //        _funcionarioRepository.Delete(funcionario);
        //        return RedirectToAction("Index");
        //    }

        //    return View();

        //}
    }
}