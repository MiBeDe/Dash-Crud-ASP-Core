using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashApp.ViewsModels;
using DashAppDomain.Departamentos;
using DashAppDomain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DashApp.Controllers
{
    public class DepartamentoController : Controller
    {

        private readonly DepartamentoStorer _departamentoStorer;
        private readonly IRepository<Departamento> _departamentoRepository;

        public DepartamentoController(IRepository<Departamento> departamentoRepository, DepartamentoStorer departamentoStorer)
        {
            _departamentoRepository = departamentoRepository;
            _departamentoStorer = departamentoStorer;
        }

        // GET: Departamento
        public ActionResult Index()
        {
            var departamentos = _departamentoRepository.All();
            if (departamentos.Any())
            {
                var viewModels = departamentos.Select(p => new DepartamentoViewModel { Id = p.Id, Setor = p.Setor });
                return View(viewModels);
            }
            return View();
        }

        // GET: Departamento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Departamento/Create
        public ActionResult CreateOrEdit()
        {
            return View();
        }

        // POST: Departamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrEdit(DepartamentoViewModel viewModel)
        {
            _departamentoStorer.Store(viewModel.Id, viewModel.Setor);
            return RedirectToAction("Index");
         
        }

        // GET: Departamento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Departamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Departamento/Delete/5
        public ActionResult Deletar(int id)
        {
            var departamento = _departamentoRepository.GetById(id);
            if(departamento != null)
            {
                _departamentoRepository.Delete(departamento);
                return RedirectToAction("Index");
            }

            return View();
        }

        // POST: Departamento/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}