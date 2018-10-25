using Gestao_Clientes.Dominio.Helpers;
using Gestao_Clientes.Dominio.ValueObjects;

namespace Gestao_Clientes.Dominio.Clientes.Scopes
{
    public static class ClienteScopes
    {
        public static bool DefinirCpfClienteScopeIsValid(this Cliente cliente, Cpf cpf)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertFixedLength(Cpf.CpfLimpo(cpf.Codigo), Cpf.ValorMaxCpf, "CPF em tamanho incorreto"),
                AssertionConcern.AssertNotNullOrEmpty(cpf.Codigo, "O CPF é obrigatório"),
                AssertionConcern.AssertTrue(Cpf.Validar(cpf.Codigo), "CPF em formato inválido")
            );
        }

        public static bool DefinirNomeClienteScopeIsValid(this Cliente cliente, string nome)
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNullOrEmpty(nome, "O Nome é obrigatório"),
                AssertionConcern.AssertTrue(!TextoHelper.ContemNumeros(nome), "Nome inválido")
            );
        }
    }
}
