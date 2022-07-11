using UC12.Classes;
using UC12.Interfaces;

namespace UC12.Class
{
    public abstract class Pessoa : IPessoa
    {
        public string? Nome { get; set; }

        public float Rendimento { get; set; }

        public Endereco? Endereco { get; set; }

        public abstract float PagarImposto(float redimento);
    }
}
