using System.Collections.Generic;
using Gestao_Clientes.Negocios.ViewModels;

namespace Gestao_Clientes.Negocios.Interfaces
{
    public interface IClienteDAO
    {
        IEnumerable<ClienteViewModel> Listar();
        ClienteViewModel BuscaPorCpf(string cpf);
        ClienteViewModel Adicionar(ClienteViewModel cliente);
        ClienteViewModel Atualizar(ClienteViewModel cliente);
        void Remover(ClienteViewModel cliente);
    }
}
