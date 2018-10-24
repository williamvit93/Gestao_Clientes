using Gestao_Clientes.Negocios.Interfaces;
using Gestao_Clientes.Negocios.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace Gestao_Clientes.WebApi.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClienteNegocios _clienteNegocios;

        public ClientesController(IClienteNegocios clienteNegocios)
        {
            _clienteNegocios = clienteNegocios;
        }

        [HttpGet]
        public IEnumerable<ClienteViewModel> Listar()
        {
            return _clienteNegocios.Listar();
        }

        [HttpGet]
        public ClienteViewModel BuscaPorCpf(string cpf)
        {
            return _clienteNegocios.BuscaPorCpf(cpf);
        }

        [HttpPost]
        public ClienteViewModel Adicionar(ClienteViewModel clienteViewModel)
        {
            return _clienteNegocios.Adicionar(clienteViewModel);
        }

        [HttpPut]
        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            return _clienteNegocios.Atualizar(clienteViewModel);
        }

        [HttpGet]
        public ClienteViewModel Remover(string cpf)
        {
            return _clienteNegocios.BuscaPorCpf(cpf);
        }

        [HttpDelete]
        public ClienteViewModel ConfirmarRemocao(string cpf)
        {
            return _clienteNegocios.Remover(cpf);
        }
    }
}
