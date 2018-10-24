using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Clientes.Dominio.Clientes
{
    public class TipoCliente
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }

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
