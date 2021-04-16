using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBCP.Domains.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
