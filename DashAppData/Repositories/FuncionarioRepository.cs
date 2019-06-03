using DashAppDomain.Funcionarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DashAppData.Repositories
{
    public class FuncionarioRepository : Repository<Funcionario>
    {
        public FuncionarioRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override Funcionario GetById(int id)
        {
            var query = _context.Set<Funcionario>()
                .Include(p => p.Cargo).Where(e => e.Id == id)
                .Include(p => p.Departamento).Where(e => e.Id == id);
            if (query.Any())
            {
                return query.First();
            }
            return null;
        }

        public override IEnumerable<Funcionario> All()
        {
            var query = _context.Set<Funcionario>()
                .Include(p => p.Cargo)
                .Include(p => p.Departamento);
            return query.Any() ? query.ToList() : new List<Funcionario>();
        }
    }
}
