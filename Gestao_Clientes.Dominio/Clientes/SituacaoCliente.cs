using System.Collections.Generic;

namespace Gestao_Clientes.Dominio.Clientes
{
    public class SituacaoCliente
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public virtual ICollection<Cliente> Cliente { get; set; }

        protected SituacaoCliente()
        {

        }

        public SituacaoCliente(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
