using System.Data.Entity.ModelConfiguration;
using Gestao_Clientes.Dominio.Clientes;

namespace Gestao_Clientes.Dados.EntityConfig
{
    public class ClientesConfig : EntityTypeConfiguration<Cliente>
    {
        public ClientesConfig()
        {
            HasKey(x => x.Cpf);
            HasRequired(x => x.Situacao).WithMany(x => x.Cliente).HasForeignKey(x => x.SituacaoCliente);
            HasRequired(x => x.Tipo).WithMany(x => x.Cliente).HasForeignKey(x => x.SituacaoCliente);
            Property(x => x.Cpf).HasMaxLength(14);
            Property(x => x.Nome).HasMaxLength(200).IsRequired().HasColumnType("VARCHAR");
            Property(x => x.SituacaoCliente).HasColumnName("SITUACAO_CLIENTE").IsRequired();
            Property(x => x.TipoCliente).HasColumnName("TIPO_CLIENTE").IsRequired();
            Property(x => x.Sexo).IsRequired().HasColumnType("VARCHAR").HasMaxLength(1);


            MapToStoredProcedures
                (x => x.Insert(sp => sp.HasName("NOVO_CLIENTE")
                      .Parameter(c => c.Cpf, "CPF")
                      .Parameter(c => c.Nome, "NOME")
                      .Parameter(c => c.SituacaoCliente, "SITUACAO_CLIENTE")
                      .Parameter(c => c.TipoCliente, "TIPO_CLIENTE")
                      .Parameter(c => c.Sexo, "SEXO"))

                .Update(sp => sp.HasName("ATUALIZA_CLIENTE")
                    .Parameter(c => c.Cpf, "CPF")
                    .Parameter(c => c.Nome, "NOME")
                    .Parameter(c => c.SituacaoCliente, "SITUACAO_CLIENTE")
                    .Parameter(c => c.TipoCliente, "TIPO_CLIENTE")
                    .Parameter(c => c.Sexo, "SEXO")));
            
            ToTable("TB_CLIENTES");
        }
    }
}
