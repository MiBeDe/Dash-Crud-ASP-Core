using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DashApp.ViewsModels;
using DashAppDomain.Cargos;
using DashAppDomain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DashApp.Controllers
{
    public class CargoController : Controller
    {

        private readonly CargoStorer _cargoStorer;
        private readonly IRepository<Cargo> _cargoRepository;

        public CargoController( CargoStorer cargoStorer, IRepository<Cargo> cargoRepository)
        {
            _cargoStorer= cargoStorer;
            _cargoRepository = cargoRepository;

        }

        // GET: Cargo
        public ActionResult Index()
        {
            var cargo = _cargoRepository.All();
            if (cargo.Any())
            {
                var viewModel = cargo.Select(p => new CargoViewModel { Id = p.Id, Atribuicao = p.Atribuicao });
                return View(viewModel);
            }
            return View();
        }

        // GET: Cargo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateOrEdit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrEdit(CargoViewModel viewModel)
        {

            _cargoStorer.Store(viewModel.Id, viewModel.Atribuicao);
            return RedirectToAction("Index");
           
        }

        // GET: Cargo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cargo/Edit/5
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

        // GET: Cargo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cargo/Delete/5
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