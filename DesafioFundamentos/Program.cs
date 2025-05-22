using DesafioFundamentos.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Seja bem-vindo ao sistema de estacionamento!\n");

Console.Write("Digite o preço inicial: R$ ");
precoInicial = Convert.ToDecimal(Console.ReadLine());

Console.Write("Digite o preço por hora: R$ ");
precoPorHora = Convert.ToDecimal(Console.ReadLine());

Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("╔══════════════════════════════════════════════╗");
    Console.WriteLine("║      SISTEMA DE ESTACIONAMENTO - MENU        ║");
    Console.WriteLine("╠══════════════════════════════════════════════╣");
    Console.WriteLine("║  1 - Cadastrar veículo                       ║");
    Console.WriteLine("║  2 - Remover veículo                         ║");
    Console.WriteLine("║  3 - Listar veículos                         ║");
    Console.WriteLine("║  4 - Encerrar                                ║");
    Console.WriteLine("╚══════════════════════════════════════════════╝");
    Console.Write("Escolha uma opção: ");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    Console.WriteLine("\nPressione ENTER para continuar...");
    Console.ReadLine();
}

Console.WriteLine("\nO programa se encerrou...");
