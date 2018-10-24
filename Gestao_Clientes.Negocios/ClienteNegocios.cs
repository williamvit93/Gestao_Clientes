using System.Collections.Generic;
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

            if (!Notifications.HasNotifications()) Commit();
            
            return clienteViewModel;
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            _clienteRepositorio.Atualizar(cliente);

            if (!Notifications.HasNotifications()) Commit();
            
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

        public void Remover(string cpf)
        {
            _clienteRepositorio.Remover(_clienteRepositorio.BuscaPorCpf(cpf));
            if (!Notifications.HasNotifications()) Commit();
        }
    }
}
