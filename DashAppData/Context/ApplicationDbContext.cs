using DashAppDomain.Cargos;
using DashAppDomain.Departamentos;
using DashAppDomain.Funcionarios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAppData
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Cargo> Cargos { get; set; }
        
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
