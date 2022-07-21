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
    }
}