﻿string mensagemDeBoasVindas = "Bem vindo ao Screen Sound";

Dictionary<string, List<int>> bandasRegistradas = new()
{
    { "Linkin Park", new List<int> { 10, 8, 6 } },
    { "The Beatles", new List<int>() }
};

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine();
    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 0 para sair");
    Console.WriteLine();

    Console.Write("Digite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            ExibirMedia();
            break;
        case 0:
            Console.WriteLine("Até mais");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    void RegistrarBanda()
    {
        Console.Clear();

        ExibirTituloDaOpcao("Registro das bandas");

        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        bandasRegistradas.Add(nomeDaBanda, []);

        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");

        Thread.Sleep(4000);
        Console.Clear();

        ExibirOpcoesDoMenu();
    }

    void MostrarBandasRegistradas()
    {
        Console.Clear();

        ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação");

        foreach (string banda in bandasRegistradas.Keys)
        {
            Console.WriteLine($"Banda: {banda}");
        }

        Console.WriteLine();
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");

        Console.ReadKey();
        Console.Clear();

        ExibirOpcoesDoMenu();
    }

    void ExibirTituloDaOpcao(string titulo)
    {
        int quantidadeDeLetras = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');

        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos);
        Console.WriteLine();
    }

    void AvaliarUmaBanda()
    {
        Console.Clear();

        ExibirTituloDaOpcao("Avaliar banda");

        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
            int nota = int.Parse(Console.ReadLine()!);
            bandasRegistradas[nomeDaBanda].Add(nota);
            Console.WriteLine();

            Console.WriteLine($"A nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");

            Thread.Sleep(2000);
            Console.Clear();

            ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");

            Console.ReadKey();
            Console.Clear();

            ExibirOpcoesDoMenu();
        }
    }

    void ExibirMedia()
    {
        Console.Clear();

        ExibirTituloDaOpcao("Exibir média da banda");

        Console.Write("Digite o nome da banda que deseja exibir a média: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
            Console.WriteLine();
            Console.WriteLine($"A média da banda {nomeDaBanda} é {notasDaBanda.Average()}.");

            Console.WriteLine("Digite uma tecla para votar ao menu principal");
            Console.ReadKey();

            Console.Clear();

            ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");

            Console.ReadKey();
            Console.Clear();

            ExibirOpcoesDoMenu();
        }
    }
}

ExibirOpcoesDoMenu();