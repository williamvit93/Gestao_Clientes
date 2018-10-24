using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestao_Clientes.Negocios.Interfaces;
using Gestao_Clientes.Negocios.ViewModels;

namespace Gestao_Clientes.Negocios
{
    public class ClienteDAO : IClienteDAO
    {
        public ClienteViewModel Adicionar(ClienteViewModel cliente)
        {
            throw new NotImplementedException();
        }

        public ClienteViewModel Atualizar(ClienteViewModel cliente)
        {
            throw new NotImplementedException();
        }

        public ClienteViewModel BuscaPorCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClienteViewModel> Listar()
        {
            throw new NotImplementedException();
        }

        public void Remover(string cpf)
        {
            throw new NotImplementedException();
        }
    }
}
