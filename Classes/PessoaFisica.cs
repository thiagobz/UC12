using System;
using UC12.Class;
using UC12.Interfaces;

namespace UC12.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? Cpf { get; set; }

        public DateTime DataNasc { get; set; }

        public override float PagarImposto(float redimento)
        {
            throw new NotImplementedException();
        }

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
    }
}
