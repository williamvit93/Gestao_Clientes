using AutoMapper;

namespace Gestao_Clientes.Negocios.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelAndReverse>();
            });
        }
    }
}
