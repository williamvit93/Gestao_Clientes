using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Gestao_Clientes.Dados.EntityConfig;
using Gestao_Clientes.Dominio.Clientes;

namespace Gestao_Clientes.Dados.Contexto
{
    public class Gestao_ClientesContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public Gestao_ClientesContext() : base("Gestao_Clientes")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new ClientesConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}

