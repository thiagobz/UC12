using System.Text.RegularExpressions;
using UC12.Class;
using UC12.Interfaces;

namespace UC12.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string? Cnpj { get; set; }

        public string? RazaoSocial { get; set; }

        public string? Caminho { get; private set; } = "Database/pessoaJuridica.csv";



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

            0 a 3000 = 3%
            3001 a 6000 =   5%
            6001 a 10000 = 7%
            > 10000 = 9%
        */
        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 3000)
            {
                return rendimento * 0.03f;
            }
            else if (rendimento <= 6000)
            {
                return rendimento * 0.05f;
            }
            else if (rendimento <= 10000)
            {
                return rendimento * 0.07f;
            }
            else
            {
                return rendimento * 0.09f;
            }
        }


        public void Inserir(PessoaJuridica pj)
        {
            Util.VerificarPastaArquivo(Caminho);

            string[] PjStrings = { $"{pj.Nome}, {pj.Cnpj}, {pj.RazaoSocial}, {pj.Rendimento}, {pj.Endereco.Logradouro}, {pj.Endereco.Numero}, {pj.Endereco.Complemento}, {pj.Endereco.EndComercial}" };

            File.AppendAllLines(Caminho, PjStrings);
        }

        public List<PessoaJuridica> lerArquivo()
        {
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(Caminho);

            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");
                PessoaJuridica atrPJ = new PessoaJuridica();

                atrPJ.Nome = atributos[0];
                atrPJ.RazaoSocial = atributos[1];
                atrPJ.Cnpj = atributos[2];
                atrPJ.Rendimento = float.Parse(atributos[3]);
                
                atrPJ.Endereco.Logradouro = atributos[4];
                atrPJ.Endereco.Numero = int.Parse(atributos[5]);
                atrPJ.Endereco.Complemento = atributos[6];
                atrPJ.Endereco.EndComercial = bool.Parse(atributos[7]);


                listaPj.Add(atrPJ);
            }
            return listaPj;
        }
    }
}
