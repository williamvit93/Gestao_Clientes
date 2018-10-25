using System.Collections.Generic;

namespace Gestao_Clientes.Dominio.Clientes
{
    public class TipoCliente
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public virtual ICollection<Cliente> Cliente { get; set; }


        protected TipoCliente()
        {

        }

        public TipoCliente(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
