using UC12.Classes;

PessoaFisica novaPF = new PessoaFisica();

novaPF.Nome = "Thiago Bazani";

Console.WriteLine(novaPF.Nome);

Console.WriteLine($"nome: {novaPF.Nome}");

Console.WriteLine($"nome :" + novaPF.Nome + "nome: " + novaPF.Nome);

Console.WriteLine(@$"
nome: {novaPF.Nome}
");