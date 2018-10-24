using Gestao_Clientes.Dados.Contexto;
using Gestao_Clientes.Dados.Repositorio;
using Gestao_Clientes.Dominio.Clientes.Interfaces;
using Gestao_Clientes.Negocios;
using Gestao_Clientes.Negocios.Interfaces;
using SimpleInjector;

namespace Gestao_Clientes.Infra
{
    public class BootStrapperGestaoClientes
    {
        public static Container MyContainer { get; set; }

        public static void Register(Container container)
        {
            MyContainer = container;

            //Repositorio
            container.Register<IClientesRepositorio, ClienteRepositorio>(Lifestyle.Scoped);
            
            //Negocios
            container.Register<IClienteNegocios, ClienteNegocios>(Lifestyle.Scoped);

            //Data
            container.Register<Gestao_ClientesContext>(Lifestyle.Scoped);

        }
    }
}
