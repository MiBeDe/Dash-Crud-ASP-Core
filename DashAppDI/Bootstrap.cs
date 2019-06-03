using DashAppData;
using DashAppData.Repositories;
using DashAppDomain;
using DashAppDomain.Cargos;
using DashAppDomain.Departamentos;
using DashAppDomain.Funcionarios;
using DashAppDomain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DashAppDI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string conection)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(conection));

            services.AddSingleton(typeof(IRepository<Funcionario>), typeof(FuncionarioRepository));
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton(typeof(CargoStorer));
            services.AddSingleton(typeof(FuncionarioStorer));
            services.AddSingleton(typeof(DepartamentoStorer));
            services.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork));

        }
    }
}
