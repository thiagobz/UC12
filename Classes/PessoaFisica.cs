using System;
using UC12.Class;
using UC12.Interfaces;

namespace UC12.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? Cpf { get; set; }

        public DateTime DataNasc { get; set; }


        public bool ValDataNasc(DateTime dataNasc)
        {
            DateTime dataAtual = DateTime.Today;

            double anos = (dataAtual - dataNasc).TotalDays / 365;

            if (anos >= 18)
            {
                return true;
            }
            return false;
        }

        public bool ValDataNasc(string dataNasc)
        {
            DateTime dataConvertida;

            if (DateTime.TryParse(dataNasc, out dataConvertida))
            {
                DateTime dataAtual = DateTime.Today;

                double anos = (dataAtual - dataConvertida).TotalDays / 365;

                if (anos >= 18)
                {
                    return true;
                }
                return false;
            }

            return false;
        }

        /*
            tributação de IR para PF ->

            0 a 1500 =  0% isento
            1501 a 3000 = 2%
            3000 a 6000 = 3.5%
            > 6000 = 5%
        */
        public override float PagarImposto(float rendimento)
        {
            if (rendimento <= 1500)
            {
                return 0;
            }
            else if (rendimento > 1500 && rendimento <= 3000)
            {
                return rendimento * 0.02f;
            }
            else if (rendimento > 3000 && rendimento <= 6000)
            {
                return rendimento * 0.035f;
            }
            else
            {
                return rendimento * 0.05f;
            }
        }
    }
}
