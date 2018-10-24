using System.Linq;
using System.Collections.Generic;
using Gestao_Clientes.Dados.Contexto;
using Gestao_Clientes.Dominio.Clientes;
using Gestao_Clientes.Dominio.Clientes.Interfaces;
using System.Data.Entity.Migrations;

namespace Gestao_Clientes.Dados.Repositorio
{
    public class ClienteRepositorio : IClientesRepositorio
    {
        private readonly Gestao_ClientesContext _contexto;

        public ClienteRepositorio(Gestao_ClientesContext contexto)
        {
            _contexto = contexto;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            return _contexto.Clientes.Add(cliente);
        }

        public Cliente Atualizar(Cliente cliente)
        {
            _contexto.Clientes.AddOrUpdate(cliente);

            return cliente;
        }

        public Cliente BuscaPorCpf(string cpf)
        {
            return _contexto.Database.SqlQuery<Cliente>($"exec BUSCA_CLIENTE_POR_CPF {cpf}").FirstOrDefault();
        }

        public IEnumerable<Cliente> Listar()
        {
            return _contexto.Database.SqlQuery<Cliente>($"exec LISTAR_CLIENTES").ToList();
        }

        public void Remover(Cliente cliente)
        {
            _contexto.Clientes.Remove(cliente);
        }
    }
}
