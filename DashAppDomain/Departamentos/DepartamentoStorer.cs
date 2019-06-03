using DashAppDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAppDomain.Departamentos
{
    public class DepartamentoStorer
    {
        private readonly IRepository<Departamento> _departamentoRepository;

        public DepartamentoStorer(IRepository<Departamento> departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public void Store(int id, string setor)
        {
            var departamento = _departamentoRepository.GetById(id);
            if(departamento == null)
            {
                departamento = new Departamento(setor);
                _departamentoRepository.Save(departamento);
            }
            else
            {
                departamento.Update(setor);
            }
        }
    }
}
