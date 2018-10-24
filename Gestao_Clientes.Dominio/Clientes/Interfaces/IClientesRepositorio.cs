using System.Collections.Generic;

namespace Gestao_Clientes.Dominio.Clientes.Interfaces
{
    public interface IClientesRepositorio
    {
        IEnumerable<Cliente> Listar();
        Cliente BuscaPorCpf(string cpf);
        Cliente Adicionar(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        void Remover(Cliente cliente);
    }
}
