using Gestao_Clientes.Dominio.Clientes.Scopes;
using Gestao_Clientes.Dominio.ValueObjects;

namespace Gestao_Clientes.Dominio.Clientes
{
    public class Cliente
    {
        public string Cpf { get; private set; }
        public string Nome { get; private set; }
        public int TipoCliente { get; private set; }
        public int SituacaoCliente { get; private set; }
        public char Sexo { get; private set; }
        private Cpf _cpf;

        protected Cliente()
        {

        }

        public Cliente(string cpf, string nome, int tipoCliente, int situacaoCliente, char sexo)
        {
            DefinirCpf(cpf);
            Cpf = cpf;
            Nome = nome;
            TipoCliente = tipoCliente;
            SituacaoCliente = situacaoCliente;
            Sexo = sexo;
        }

        private void DefinirCpf(string cpf)
        {
            var cpfCliente = new Cpf(cpf);
            if (this.DefinirCpfClienteScopeIsValid(cpfCliente))
                _cpf = cpfCliente;
        }
    }
}
