using UC12.Classes;


Console.Clear();
Console.WriteLine(@$"
========================================================
||          Bem vindo ao sistema de cadastro de       ||
||                Pessoa Física e Jurídica            ||
========================================================
");

Util.BarraCarregamento("Iniciando", 500, 10);

string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
========================================================
||            Escolha uma das opções abaixo           ||
||____________________________________________________||
||                                                    ||                         
||                  1 - Pessoa Física                 ||
||                  2 - Pessoa Jurídica               ||
||                                                    ||
||                  0 - Cancelar                      ||
========================================================

");

    opcao = Console.ReadLine();
    switch (opcao)
    {
        case "0":
            Console.Clear();
            Console.WriteLine($"Obrigado por utilizar o nosso sistema.");

            Util.BarraCarregamento("Encerrando", 250, 20);

            break;

        case "1":
            Console.Clear();

            PessoaFisica novaPF = new PessoaFisica();
            PessoaFisica metodosPF = new PessoaFisica();
            Endereco novoEndPF = new Endereco();

            novaPF.Nome = "Thiago Bazani";
            novaPF.DataNasc = new DateTime(1992, 02, 01);
            novaPF.Cpf = "123.345.567.89";
            novaPF.Rendimento = 3500.5f;

            novoEndPF.Logradouro = "Rua Roma";
            novoEndPF.Numero = 3;
            novoEndPF.Complemento = "Minha casa";
            novoEndPF.EndComercial = false;

            novaPF.Endereco = novoEndPF;


            Console.WriteLine(@$"
Nome: {novaPF.Nome}
CPF: {novaPF.Cpf}
Data de Nascimento: {novaPF.DataNasc}
Maior de Idade: {(metodosPF.ValDataNasc(novaPF.DataNasc) ? "Sim" : "Não")}

Endereco: {novaPF.Endereco.Logradouro}, {novaPF.Endereco.Numero}, {novaPF.Endereco.Complemento} 
Endereço Comercial: {((novaPF.Endereco.EndComercial) ? "Sim" : "Não")}
            ");

            Console.WriteLine($"Aperte ENTER para continuar");
            Console.ReadKey();
            break;

        case "2":
            Console.Clear();

            PessoaJuridica novaPJ = new PessoaJuridica();
            PessoaJuridica metodosPJ = new PessoaJuridica();
            Endereco novoEndPJ = new Endereco();

            novaPJ.RazaoSocial = "Senai São Paulo";
            novaPJ.Cnpj = "00111222000133";
            novaPJ.Rendimento = 10000.5f;

            novoEndPJ.Logradouro = "Rua ABC";
            novoEndPJ.Numero = 133;
            novoEndPJ.Complemento = "Curso Senai";
            novoEndPJ.EndComercial = true;

            novaPJ.Endereco = novoEndPJ;

            Console.WriteLine(@$"
Razão social: {novaPJ.RazaoSocial}
CNPJ: {novaPJ.Cnpj}
CNPJ Válido: {((metodosPJ.ValidarCnpj(novaPJ.Cnpj)) ? "Sim" : "Não")}

Endereço: {novaPJ.Endereco.Logradouro}, {novaPJ.Endereco.Numero}
Complemento {novaPJ.Endereco.Complemento}
Endereço Comercial: {((novaPJ.Endereco.EndComercial) ? "Sim" : "Não")}
            ");

            Console.WriteLine($"Aperte ENTER para continuar");
            Console.ReadKey();
            break;


        default:
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"Opção inválida, por favor digite uma opção válida.");
            Thread.Sleep(2000);
            Console.ResetColor();

            break;
    }
} while (opcao != "0");
Console.Clear();

/* static void BarraCarregamento(string mensagem, int timer, int quantidade)
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
 */