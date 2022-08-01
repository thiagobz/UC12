namespace UC12.Classes
{
    public class Util
    {
        public static void BarraCarregamento(string mensagem, int timer, int quantidade)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write(mensagem);
            for (var i = 0; i < quantidade; i++)
            {
                Console.Write(".");
                Thread.Sleep(timer);
            }
            Console.ResetColor();
        }

        public static void VerificarPastaArquivo(string caminhoArquivo)
        {
            string pasta = caminhoArquivo.Split("/")[0];
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(caminhoArquivo))
            {
                using (File.Create(caminhoArquivo)){}
            }
        }
    }
}