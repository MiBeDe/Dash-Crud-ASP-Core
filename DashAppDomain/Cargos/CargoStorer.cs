using DashAppDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAppDomain.Cargos
{
    public class CargoStorer
    {
        private readonly IRepository<Cargo> _cargoRepository;

        public CargoStorer(IRepository<Cargo> cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public void Store(int id, string atribuicao)
        {
            var cargo = _cargoRepository.GetById(id);
            if(cargo == null)
            {
                cargo = new Cargo(atribuicao);
                _cargoRepository.Save(cargo);
            }
            else
            {
                cargo.Update(atribuicao);
            }

        }
    }
}
