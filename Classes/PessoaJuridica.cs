using System.Text.RegularExpressions;
using UC12.Class;
using UC12.Interfaces;

namespace UC12.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string? Cnpj { get; set; }

        public string? RazaoSocial { get; set; }

        // xx.xxx.xxx/0001-xx | xxxxxxxxxxxxxx
        public bool ValidarCnpj(string cnpj)
        {
            //Regular Expression
            bool cnpjValido = Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)");

            if (cnpjValido)
            {
                if (cnpj.Length == 18)
                {
                    string subCnpj = cnpj.Substring(11, 4);
                    if (subCnpj == "0001")
                    {
                        return true;
                    }
                }
                else if (cnpj.Length == 14)
                {
                    string subCnpj = cnpj.Substring(8, 4);
                    if (subCnpj == "0001")
                    {
                        return true;
                    }
                }
            }
            return false;

            /* Regex implicito dentro do if
                if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
                {
                    return true;
                } 
            */
        }

        /* 
            tributação de IR para PJ ->


        */
        public override float PagarImposto(float redimento)
        {
            throw new NotImplementedException();
        }
    }
}
