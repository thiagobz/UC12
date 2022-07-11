using UC12.Classes;

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
novoEndPF.EndComercial = true;

novaPF.Endereco = novoEndPF;


Console.WriteLine(@$"
Nome: {novaPF.Nome}
CPF: {novaPF.Cpf}
Data de Nascimento: {novaPF.DataNasc}
Maior de Idade: {(metodosPF.ValDataNasc(novaPF.DataNasc) ? "Sim" : "Não")}

Endereco: {novaPF.Endereco.Logradouro}, {novaPF.Endereco.Numero}, {novaPF.Endereco.Complemento} 
Endereço Comercial: {((novaPF.Endereco.EndComercial) ? "Sim" : "Não")}
");
