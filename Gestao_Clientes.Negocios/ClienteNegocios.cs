using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Gestao_Clientes.Dados.Interfaces;
using Gestao_Clientes.Dominio.Clientes;
using Gestao_Clientes.Dominio.Clientes.Interfaces;
using Gestao_Clientes.Negocios.Interfaces;
using Gestao_Clientes.Negocios.ViewModels;

namespace Gestao_Clientes.Negocios
{
    public class ClienteNegocios : ApplicationService, IClienteNegocios
    {
        private readonly IClientesRepositorio _clienteRepositorio;

        public ClienteNegocios(IClientesRepositorio clienteRepositorio, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public ClienteViewModel Adicionar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            _clienteRepositorio.Adicionar(cliente);

            if (!Notifications.HasNotifications())
            {
                Commit();
            }
            else
            {
                clienteViewModel.Erros = Notifications.GetValues().Select(x => x.Value).ToList();
            }
            return clienteViewModel;
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            _clienteRepositorio.Atualizar(cliente);

            if (!Notifications.HasNotifications())
            {
                Commit();
            }
            else
            {
                clienteViewModel.Erros = Notifications.GetValues().Select(x => x.Value).ToList();
            }

            return clienteViewModel;
        }

        public ClienteViewModel BuscaPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepositorio.BuscaPorCpf(cpf));
        }

        public IEnumerable<ClienteViewModel> Listar()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepositorio.Listar());
        }

        public ClienteViewModel Remover(string cpf)
        {
            var cliente = _clienteRepositorio.BuscaPorCpf(cpf);
            var clienteViewModel = Mapper.Map<ClienteViewModel>(cliente);

            _clienteRepositorio.Remover(cliente);

            if (!Notifications.HasNotifications())
            {
                Commit();
            }
            else
            {
                clienteViewModel.Erros = Notifications.GetValues().Select(x => x.Value).ToList();
            }

            return clienteViewModel;
        }
    }
}
