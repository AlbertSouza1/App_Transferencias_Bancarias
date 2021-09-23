using DIO.Bank.Entidades;
using DIO.Bank.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank.Repositorios
{
    public static class ContaRepositorio
    {
        static List<Conta> listaContas = new List<Conta>();
        public static void ListarContas()
        {
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            else
            {
                for(int i =0; i<listaContas.Count; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Número da conta: {i}{listaContas[i].ToString()}");
                }
            }
        }

        public static void InserirConta()
        {
            Console.WriteLine();
            Console.WriteLine("Inserindo nova conta....");
            Console.WriteLine("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();
            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o crédito inicial: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                entradaNome,
                (TipoConta)entradaTipoConta,
                entradaSaldo,
                entradaCredito
                );

            listaContas.Add(novaConta);
        }

        public static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            if (indiceConta >= listaContas.Count)
            {
                throw new ArgumentOutOfRangeException("Número de conta digitado inexistente.");
            }

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());
          
            listaContas[indiceConta].Sacar(valorSaque);
            Console.WriteLine("Saque realizado com sucesso.");
        }
        public static void Depositar()
        {
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            if (indiceConta >= listaContas.Count)
            {
                throw new ArgumentOutOfRangeException("Número de conta digitado inexistente.");
            }

            Console.WriteLine("Digite o valor do depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
            Console.WriteLine("Depósito realizado com sucesso.");
        }

        public static void Transferir()
        {
            Console.WriteLine("Digite o número da conta que irá transferir o dinheiro: ");
            int indiceContaRemetente = int.Parse(Console.ReadLine());
            if (indiceContaRemetente >= listaContas.Count)
            {
                throw new ArgumentOutOfRangeException("Número da conta remetente inexistente.");
            }

            Console.WriteLine("Digite o número da conta que irá receber o dinheiro: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            if (indiceContaDestino >= listaContas.Count)
            {
                throw new ArgumentOutOfRangeException("Número da conta destino inexistente.");
            }

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaRemetente].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
        }
    }
}
