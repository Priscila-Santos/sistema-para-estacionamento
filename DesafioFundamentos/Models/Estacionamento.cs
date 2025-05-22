using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().Trim().ToUpper();

            List<string> placasRegistradas = File.Exists("data.csv")
                ? File.ReadAllLines("data.csv").Select(l => l.Trim().ToUpper()).ToList()
                : new List<string>();

            if (veiculos.Any(x => x.ToUpper() == placa) || placasRegistradas.Contains(placa))
            {
                Console.WriteLine("Desculpe, esse veículo já está estacionado.");
            }
            else
            {
                veiculos.Add(placa);
                Console.WriteLine($"O veículo {placa} foi estacionado com sucesso!");

                using (StreamWriter sw = new StreamWriter("data.csv", true))
                {
                    sw.WriteLine(placa);
                }
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().Trim().ToUpper();

            List<string> placasRegistradas = File.Exists("data.csv")
                ? File.ReadAllLines("data.csv").Select(l => l.Trim().ToUpper()).ToList()
                : new List<string>();

            if (placasRegistradas.Contains(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());

                decimal valorTotal = precoInicial + (precoPorHora * horas);
                veiculos.Remove(placa); // Caso ainda esteja na lista temporária

                // Exibir comprovante formatado
                Console.Clear();
                Console.WriteLine("╔═══════════════════════════════════════╗");
                Console.WriteLine("║       COMPROVANTE DE PAGAMENTO       ║");
                Console.WriteLine("╠═══════════════════════════════════════╣");
                Console.WriteLine($"║ Placa do veículo: {placa,-22}║");
                Console.WriteLine($"║ Horas estacionado: {horas,-20}║");
                Console.WriteLine($"║ Preço inicial:     R$ {precoInicial,-14:N2}║");
                Console.WriteLine($"║ Preço por hora:    R$ {precoPorHora,-14:N2}║");
                Console.WriteLine("╠═══════════════════════════════════════╣");
                Console.WriteLine($"║ TOTAL A PAGAR:     R$ {valorTotal,-14:N2}║");
                Console.WriteLine("╚═══════════════════════════════════════╝");

                // Atualiza o arquivo CSV
                placasRegistradas = placasRegistradas.Where(p => p != placa).ToList();
                File.WriteAllLines("data.csv", placasRegistradas);
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            if (File.Exists("data.csv"))
            {
                var linhas = File.ReadAllLines("data.csv").Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
                if (linhas.Count > 0)
                {
                    Console.WriteLine("╔══════════════════════════════════════╗");
                    Console.WriteLine("║    VEÍCULOS ESTACIONADOS ATUALMENTE ║");
                    Console.WriteLine("╠══════════════════════════════════════╣");
                    foreach (string linha in linhas)
                    {
                        Console.WriteLine($"║ {linha,-36}║");
                    }
                    Console.WriteLine("╚══════════════════════════════════════╝");
                }
                else
                {
                    Console.WriteLine("Não há veículos estacionados no momento.");
                }
            }
            else
            {
                Console.WriteLine("Nenhum veículo registrado até o momento.");
            }
        }
    }
}
