using System.Collections.Generic;

namespace Gestao_Clientes.Negocios.ViewModels
{
    public class ClienteViewModel
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public int TipoCliente { get; set; }
        public int SituacaoCliente { get; set; }
        public char Sexo { get; set; }
        public SituacaoClienteViewModel Situacao { get; set; }
        public TipoClienteViewModel Tipo { get; set; }
        public IEnumerable<string> Erros { get; set; }
    }
}
