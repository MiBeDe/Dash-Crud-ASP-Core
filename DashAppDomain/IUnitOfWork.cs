using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DashAppDomain
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
