using Gestao_Clientes.Negocios.Interfaces;
using Gestao_Clientes.Negocios.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gestao_Clientes.API.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClienteNegocios _clienteNegocios;

        public ClientesController(IClienteNegocios clienteNegocios)
        {
            _clienteNegocios = clienteNegocios;
        }

        [HttpGet]
        public IHttpActionResult Listar()
        {
            var listaClientes = _clienteNegocios.Listar();

            var httpResult = listaClientes.Count() > 0 
                ? ResponseMessage(Request.CreateResponse<IEnumerable<ClienteViewModel>>(HttpStatusCode.OK, listaClientes))
                : ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NoContent, "Não existem clientes cadastrados"));

            return httpResult;
        }

        [HttpGet]
        public IHttpActionResult BuscaPorCpf(string cpf)
        {
            var cliente = _clienteNegocios.BuscaPorCpf(cpf);

            var httpResult = cliente != null 
                ? ResponseMessage(Request.CreateResponse<ClienteViewModel>(HttpStatusCode.OK, cliente))
                : ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NoContent, "Cliente não Encontrado"));

            return httpResult;
        }

        [HttpPost]
        public IHttpActionResult Adicionar([FromBody]ClienteViewModel clienteViewModel)
        {
            var clienteAdicionado = _clienteNegocios.Adicionar(clienteViewModel);

            var httpResult = clienteAdicionado.Erros == null 
                ? ResponseMessage(Request.CreateResponse<ClienteViewModel>(HttpStatusCode.OK, clienteAdicionado))
                : ResponseMessage(Request.CreateResponse<IEnumerable<string>>(HttpStatusCode.NonAuthoritativeInformation, clienteAdicionado.Erros));

            return httpResult;
        }

        [HttpPut]
        public IHttpActionResult Atualizar([FromBody]ClienteViewModel clienteViewModel)
        {
            var clienteAtualizado = _clienteNegocios.Atualizar(clienteViewModel);

            var httpResult = clienteAtualizado.Erros == null 
                ? ResponseMessage(Request.CreateResponse<ClienteViewModel>(HttpStatusCode.OK, clienteAtualizado))
                : ResponseMessage(Request.CreateResponse<IEnumerable<string>>(HttpStatusCode.NonAuthoritativeInformation, clienteAtualizado.Erros));

            return httpResult;
        }

        [HttpDelete]
        public IHttpActionResult Remover(string cpf)
        {
            var clienteRemovido = _clienteNegocios.Remover(cpf);

            var httpResult = clienteRemovido != null 
                ? ResponseMessage(Request.CreateResponse<ClienteViewModel>(HttpStatusCode.OK, clienteRemovido))
                : ResponseMessage(Request.CreateResponse<string>(HttpStatusCode.NoContent, "Cliente não Encontrado"));

            return httpResult;
        }
    }
}
