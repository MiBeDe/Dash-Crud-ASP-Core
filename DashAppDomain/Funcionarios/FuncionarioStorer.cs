using DashAppDomain.Cargos;
using DashAppDomain.Departamentos;
using DashAppDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAppDomain.Funcionarios
{
    public class FuncionarioStorer
    {
        private readonly IRepository<Funcionario> _funcionarioRepository;
        private readonly IRepository<Cargo> _cargoRepository;
        private readonly IRepository<Departamento> _departamentoRepository;

        public FuncionarioStorer(IRepository<Funcionario> funcionarioRepository, IRepository<Cargo> cargoRepository, IRepository<Departamento> departamentoRepository)
        {
            _funcionarioRepository = funcionarioRepository;
            _cargoRepository = cargoRepository;
            _departamentoRepository = departamentoRepository;
        }

        public void Store(int id, string nome, string cpf, string rg, string endereco, string cep, string cidade, string estado, string pais, int cargoId, int departamentoId)
        {
            var cargo = _cargoRepository.GetById(cargoId);
            DomainException.When(cargo == null, "Cargo é obrigatório");

            var departamento = _departamentoRepository.GetById(departamentoId);
            DomainException.When(departamento == null, "Departamento é obrigatório");

            var funcionario = _funcionarioRepository.GetById(id);
            if (funcionario == null)
            {
                funcionario = new Funcionario(nome, cpf, rg, endereco, cep, cidade, estado, pais, cargo, departamento);
                _funcionarioRepository.Save(funcionario);
            }
            else
            {
                funcionario.Update(nome, cpf, rg, endereco, cep, cidade, estado, pais, cargo, departamento);
            }
        }
    }
}
