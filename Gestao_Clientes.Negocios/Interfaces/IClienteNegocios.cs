using System.Collections.Generic;
using Gestao_Clientes.Negocios.ViewModels;

namespace Gestao_Clientes.Negocios.Interfaces
{
    public interface IClienteNegocios
    {
        IEnumerable<ClienteViewModel> Listar();
        ClienteViewModel BuscaPorCpf(string cpf);
        ClienteViewModel Adicionar(ClienteViewModel cliente);
        ClienteViewModel Atualizar(ClienteViewModel cliente);
        void Remover(string cpf);
    }
}
