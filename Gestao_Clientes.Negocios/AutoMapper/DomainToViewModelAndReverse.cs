using AutoMapper;
using Gestao_Clientes.Dominio.Clientes;
using Gestao_Clientes.Negocios.ViewModels;

namespace Gestao_Clientes.Negocios.AutoMapper
{
    public class DomainToViewModelAndReverse : Profile
    {
        protected override void Configure()
        {
            CreateMap<ClienteViewModel, Cliente>().ReverseMap();
            CreateMap<SituacaoClienteViewModel, SituacaoCliente>().ReverseMap();
            CreateMap<TipoClienteViewModel, TipoCliente>().ReverseMap();
        }
    }
}
