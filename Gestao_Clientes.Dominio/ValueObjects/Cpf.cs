using Gestao_Clientes.Dominio.Helpers;

namespace Gestao_Clientes.Dominio.ValueObjects
{
    public class Cpf
    {
        public const int ValorMaxCpf = 11;
        public string Codigo { get; private set; }

        protected Cpf()
        {

        }

        public Cpf(string Cpf)
        {
            Codigo = Cpf;
        }

        public static string CpfLimpo(string Cpf)
        {
            Cpf = TextoHelper.GetNumeros(Cpf);

            if (string.IsNullOrEmpty(Cpf))
                return "";

            //while (cnpj.StartsWith("0"))
            //    cnpj = cnpj.Substring(1);

            return Cpf;
        }

        public static bool Validar(string Cpf)
        {

            if (Cpf == null) return false;

            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            Cpf = Cpf.Trim();
            Cpf = Cpf.Replace(".", "").Replace("-", "");

            if (Cpf.Length != 11 || Cpf != TextoHelper.GetNumeros(Cpf))
                return false;

            tempCpf = Cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            return Cpf.EndsWith(digito);
        }
    }
}
