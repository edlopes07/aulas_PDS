//using Escola.Models;

//Console.WriteLine("Hello, World!");

//Console.WriteLine("Digite o nome");
//var nome = Console.ReadLine();

//Console.WriteLine("Digite o email");
//var email = Console.ReadLine();

//Console.WriteLine("Digite o codigo");
//var codigo = Console.ReadLine();

//Console.WriteLine("Digite o data de nascimento");
//var data = DateTime.Parse(Console.ReadLine());

//var aluno = new Aluno();

////aluno.setNome(nome);
//aluno.Nome = nome;
//aluno.Email = email;
//aluno.DataNascimento = data;
//aluno.Codigo = codigo;

//Console.WriteLine(aluno.Idade);

//aluno.PrintDados();
//// object-initializer
//var bolsista = new Bolsista
//{
//    Nome = "Aluno bolsista",
//    Codigo = "9876",
//    PorcentagemDesconto = 50,
//    DataNascimento = new DateTime(2000, 1, 1)
//};
//bolsista.PrintDados();

//var intercambio = new AlunoIntercambio();

//Aluno a;

//a = aluno;
//a = bolsista;
//a = intercambio;

//var lista = new List<Aluno>();

//lista.Add(aluno);
//lista.Add(bolsista);
//lista.Add(intercambio);

//foreach (var item in lista)
//{
//    item.PrintDados();
//}
using Escola.Models;
using Escola.Services;

var service = new AlunoService();
while (true)
{
    Console.WriteLine("1 - Consultar alunos");
    Console.WriteLine("2 - Cadastrar aluno");

    Console.Write("Digite a opcao: ");
    var opcao = int.Parse(Console.ReadLine());

    if (opcao == 1)
    {
        var alunos = service.Consultar();
        Console.WriteLine("==========================");

        foreach (var aluno in alunos)
        {
            aluno.PrintDados();
            Console.WriteLine("==========================");
        }
    }
    else if (opcao == 2)
    {
        Console.WriteLine("Digite o nome: ");
        var nome = Console.ReadLine();
        Console.WriteLine("Digite o email: ");
        var email = Console.ReadLine();
        Console.WriteLine("Digite o codigo: ");
        var codigo = Console.ReadLine();
        Console.WriteLine("Digite o data de nascimento: ");
        var data = DateTime.Parse(Console.ReadLine());

        var aluno = new Aluno();
        aluno.Nome = nome;
        aluno.Email = email;
        aluno.DataNascimento = data;
        aluno.Codigo = codigo;

        var sucesso = service.Criar(aluno, out _);
        if (sucesso)
        {
            Console.WriteLine("Aluno cadastrado com sucesso!");
            aluno.PrintDados();
        }
        else
        {
            Console.WriteLine("Falha na criação do aluno");
        }
    }
}

