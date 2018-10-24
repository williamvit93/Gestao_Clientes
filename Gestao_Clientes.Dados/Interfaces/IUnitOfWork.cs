using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Clientes.Dados.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
