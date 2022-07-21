using UC12.Classes;


Console.Clear();
Console.WriteLine(@$"
========================================================
||          Bem vindo ao sistema de cadastro de       ||
||                Pessoa Física e Jurídica            ||
========================================================
");

Util.BarraCarregamento("Iniciando", 500, 10);

List<PessoaFisica> listaPF = new List<PessoaFisica>();
List<PessoaJuridica> listaPJ = new List<PessoaJuridica>();

string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
========================================================
||            Escolha uma das opções abaixo           ||
||____________________________________________________||
||                                                    ||                         
||                1 - Pessoa Física                   ||
||                2 - Pessoa Jurídica                 ||
||                                                    ||
||                0 - Cancelar                        ||
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

            string? opcaoPF;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
========================================================
||            Escolha uma das opções abaixo           ||
||____________________________________________________||
||                                                    ||                         
||                1 - Cadastrar Pessoa Física         ||
||                2 - Listar Pessoa Física            ||
||                                                    ||
||                0 - Voltar                          ||
========================================================

");

                opcaoPF = Console.ReadLine();
                PessoaFisica metodosPF = new PessoaFisica();

                switch (opcaoPF)
                {
                    case "1":
                        PessoaFisica novaPF = new PessoaFisica();
                        Endereco novoEndPF = new Endereco();

                        Console.WriteLine($"Digite o nome da pessoa física que deseja cadastrar.");
                        novaPF.Nome = Console.ReadLine();

                        bool dataValida;
                        do
                        {
                            Console.WriteLine($"Digite a data de nascimento. Ex: DD/MM/AAAA");
                            string? dataNasc = Console.ReadLine();

                            dataValida = metodosPF.ValDataNasc(dataNasc);

                            if (dataValida)
                            {
                                DateTime dataConvertida;
                                DateTime.TryParse(dataNasc, out dataConvertida);
                                novaPF.DataNasc = dataConvertida;

                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Data digitada inválida, por favor digite uma data válida");
                                Console.ResetColor();
                                Thread.Sleep(2000);
                            }

                        } while (dataValida == false);

                        Console.WriteLine($"Digite o número do CPF.");
                        novaPF.Cpf = Console.ReadLine();

                        Console.WriteLine($"Digite seu rendimento mensal. (DIGITE SOMENTE NUMEROS)");
                        novaPF.Rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro.");
                        novoEndPF.Logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o numero.");
                        novoEndPF.Numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento. (Aperte ENTER para vazio)");
                        novoEndPF.Complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string? endCom = Console.ReadLine().ToLower();

                        if (endCom == "s")
                        {
                            novoEndPF.EndComercial = true;
                        }
                        else
                        {
                            novoEndPF.EndComercial = false;
                        }

                        novaPF.Endereco = novoEndPF;

                        listaPF.Add(novaPF);

                        Console.WriteLine(@$"
                        Cadastro realizado com sucesso!
                        
                        Nova Pessoa Física

                        Nome: {novaPF.Nome}
                        Data Nascimento: {novaPF.DataNasc}
                        CPF: {novaPF.Cpf}
                        Rendimento: {novaPF.Rendimento}
                        Endereço: {novaPF.Endereco.Logradouro} {novaPF.Endereco.Numero}, {novaPF.Endereco.Complemento}
                        ");

                        Console.WriteLine($"Aperte 'ENTER' para concluir o cadastro");
                        Console.ReadLine();
                        break;

                    case "2":
                        Console.Clear();

                        if (listaPF.Count() > 0)
                        {
                            foreach (PessoaFisica cadaPessoa in listaPF)
                            {
                                Console.Clear();
                                Console.WriteLine(@$"
Nome: {cadaPessoa.Nome}
CPF: {cadaPessoa.Cpf}
Data de Nascimento: {cadaPessoa.DataNasc}
Maior de Idade: {(cadaPessoa.ValDataNasc(cadaPessoa.DataNasc) ? "Sim" : "Não")}
Salário: {cadaPessoa.Rendimento}
Imposto de Renda: {metodosPF.PagarImposto(cadaPessoa.Rendimento).ToString("C")}

Endereco: {cadaPessoa.Endereco.Logradouro}, {cadaPessoa.Endereco.Numero}, {cadaPessoa.Endereco.Complemento} 
Endereço Comercial: {((cadaPessoa.Endereco.EndComercial) ? "Sim" : "Não")}
            ");
                                Console.WriteLine($"Aperte 'ENTER' para continuar");
                                Console.ReadLine();
                            }

                        }
                        else
                        {
                            Console.WriteLine($"A lista está vazia");
                            Util.BarraCarregamento("Voltando ao menu", 800, 6);
                        }

                        break;

                    case "0":
                        Console.Clear();
                        Util.BarraCarregamento("Voltando", 250, 10);
                        break;

                    default:
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Opção inválida, por favor digite uma opção válida.");
                        Thread.Sleep(2000);
                        Console.ResetColor();

                        break;
                }



            } while (opcaoPF != "0");

            break;

        case "2":
            string? opcaoPJ;

            do
            {
                Console.Clear();
                Console.WriteLine(@$"
========================================================
||            Escolha uma das opções abaixo           ||
||____________________________________________________||
||                                                    ||                         
||                1 - Cadastrar Pessoa Jurídica       ||
||                2 - Listar Pessoa Jurídica          ||
||                                                    ||
||                0 - Voltar                          ||
========================================================

");

                opcaoPJ = Console.ReadLine();
                PessoaJuridica metodosPJ = new PessoaJuridica();


                switch (opcaoPJ)
                {
                    case "1":
                        Console.Clear();

                        PessoaJuridica novaPJ = new PessoaJuridica();
                        Endereco novoEndPJ = new Endereco();

                        Console.WriteLine($"Digite a razão social da empresa.");
                        novaPJ.RazaoSocial = Console.ReadLine();

                        Console.WriteLine($"Digite o CNPJ.");
                        novaPJ.Cnpj = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal da empresa.");
                        novaPJ.Rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro.");
                        novoEndPJ.Logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o numero.");

                        novoEndPJ.Numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento.");

                        novoEndPJ.Complemento = Console.ReadLine();

                        Console.WriteLine($"Endereço é comercial? S/N");
                        string? endCom = Console.ReadLine().ToLower();

                        if (endCom == "s")
                        {
                            novoEndPJ.EndComercial = true;
                        }
                        else
                        {
                            novoEndPJ.EndComercial = false;
                        }

                        novaPJ.Endereco = novoEndPJ;

                        listaPJ.Add(novaPJ);

                        Console.WriteLine(@$"
                        Cadastro realizado com sucesso!
                        
                        Nova Pessoa Física

                        Nome: {novaPJ.RazaoSocial}
                        CPF: {novaPJ.Cnpj}
                        Rendimento: {novaPJ.Rendimento}
                        Endereço: {novaPJ.Endereco.Logradouro} {novaPJ.Endereco.Numero}, {novaPJ.Endereco.Complemento}
                        ");

                        Console.WriteLine($"Aperte 'ENTER' para concluir o cadastro");
                        Console.ReadLine();
                        break;
                    case "2":

                        if (listaPJ.Count() > 0)
                        {
                            foreach (PessoaJuridica cadaPessoa in listaPJ)
                            {
                                Console.WriteLine(@$"
Razão social: {cadaPessoa.RazaoSocial}
CNPJ: {cadaPessoa.Cnpj}
CNPJ Válido: {((metodosPJ.ValidarCnpj(cadaPessoa.Cnpj)) ? "Sim" : "Não")}
Salário: {cadaPessoa.Rendimento.ToString("C")}
Imposto de Renda: {cadaPessoa.PagarImposto(cadaPessoa.Rendimento).ToString("C")}

Endereço: {cadaPessoa.Endereco.Logradouro}, {cadaPessoa.Endereco.Numero}
Complemento: {cadaPessoa.Endereco.Complemento}
Endereço Comercial: {((cadaPessoa.Endereco.EndComercial) ? "Sim" : "Não")}
            ");

                                Console.WriteLine($"Aperte ENTER para continuar");
                                Console.ReadKey();

                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"A lista está vazia");
                            Util.BarraCarregamento("Voltando ao menu", 800, 6);
                        }

                        break;
                    case "0":
                        Console.Clear();
                        Util.BarraCarregamento("Voltando", 250, 10);
                        break;
                    default:
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Opção inválida, por favor digite uma opção válida.");
                        Thread.Sleep(2000);
                        Console.ResetColor();
                        break;
                }
            } while (opcaoPJ != "0");

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