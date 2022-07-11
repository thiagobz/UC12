using System;
using UC12.Class;
using UC12.Interfaces;

namespace UC12.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string? Cpf { get; set; }

        public DateTime Nasc { get; set; }

        public override float PagarImposto(float redimento)
        {
            throw new NotImplementedException();
        }

        public bool ValDataNasc(DateTime dataNasc)
        {
            throw new NotImplementedException();
        }
    }
}
