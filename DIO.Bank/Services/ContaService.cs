using DIO.Bank.Entidades;
using DIO.Bank.Enums;
using DIO.Bank.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank.Services
{
    public static class ContaService
    {
        public static void ListarContas()
        {
            List<Conta> listaContas = new List<Conta>();
          
            listaContas = ContaRepositorio.ListarContas();
            if (listaContas == null)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
            }
            else
            {               
                for (int i = 0; i < listaContas.Count; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Número da conta: {i}{listaContas[i].ToString()}");
                }
            }
        }
        
        public static void InserirConta()
        {
            int entradaTipoConta = 0;
            string saldoDigitado = string.Empty;
            double entradaSaldo = 0;
            string creditoDigitado = string.Empty;
            double entradaCredito = 0;
            bool retorno = false;

            Console.WriteLine();
            Console.WriteLine("INSERINDO NOVA CONTA....");

            while (entradaTipoConta == 0)
            {
                Console.WriteLine("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
                entradaTipoConta = Validador.ValidarTipoConta(Console.ReadLine());
            }

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            do
            {
                Console.WriteLine("Digite o saldo inicial: ");
                saldoDigitado = Console.ReadLine();
                retorno = Validador.ValidarSaldoInicial(saldoDigitado);
            } while (!retorno);
            entradaSaldo = double.Parse(saldoDigitado);
            retorno = false;

            do
            {
                Console.WriteLine("Digite o crédito inicial: ");
                creditoDigitado = Console.ReadLine();
                retorno = Validador.ValidarCreditoInicial(creditoDigitado);
            } while (!retorno);
            entradaCredito = double.Parse(creditoDigitado);
            retorno = false;

            Conta novaConta = new Conta(
                entradaNome,
                (TipoConta)entradaTipoConta,
                entradaSaldo,
                entradaCredito
                );

            if (ContaRepositorio.InserirConta(novaConta))
                Console.WriteLine(Environment.NewLine + "CONTA CADASTRADA COM SUCESSO." + Environment.NewLine);
            else
                Console.WriteLine(Environment.NewLine + "Problemas ao cadastrar conta. Tente novamente.");

        }
        
        public static void Sacar()
        {
            Console.WriteLine("Digite o número da conta: ");
            var indiceConta = Console.ReadLine();

            if (Validador.ValidarNumeroConta(indiceConta))
            {
                Console.WriteLine("Digite o valor a ser sacado: ");
                //TODO = validar valor do saque
                double valorSaque = double.Parse(Console.ReadLine());

                var conta = ContaRepositorio.RecuperarContaPorId(int.Parse(indiceConta));

                conta.Sacar(valorSaque);
                Console.WriteLine("Saque realizado com sucesso.");
            }            
            else
            {
                Console.WriteLine(Environment.NewLine+"Conta não encontrada. Verifique o número da conta digitada e tente novamente."+Environment.NewLine);
            }
        }
        
        public static void Depositar()
        {
            Console.WriteLine("Digite o número da conta: ");
            var indiceConta = Console.ReadLine();

            if (Validador.ValidarNumeroConta(indiceConta))
            {
                Console.WriteLine("Digite o valor do depósito: ");
                //TODO = validar valor do deposito
                double valorDeposito = double.Parse(Console.ReadLine());

                var conta = ContaRepositorio.RecuperarContaPorId(int.Parse(indiceConta));

                conta.Depositar(valorDeposito);
                Console.WriteLine("Depósito realizado com sucesso.");
            }
            else
            {
                Console.WriteLine(Environment.NewLine + "Conta não encontrada. Verifique o número da conta digitada e tente novamente." + Environment.NewLine);
            }

        }
        public static void Transferir()
        {
            Console.WriteLine("Digite o número da conta que irá transferir o dinheiro: ");
            var indiceContaRemetente = Console.ReadLine();

            if (Validador.ValidarNumeroConta(indiceContaRemetente))
            {
                Console.WriteLine("Digite o número da conta que irá receber o dinheiro: ");
                var indiceContaDestino = Console.ReadLine();

                if (Validador.ValidarNumeroConta(indiceContaDestino))
                {
                    Console.WriteLine("Digite o valor a ser transferido: ");
                    double valorTransferencia = double.Parse(Console.ReadLine());

                    ContaRepositorio.Transferir(valorTransferencia, int.Parse(indiceContaRemetente), int.Parse(indiceContaDestino));
                }
                else
                {
                    Console.WriteLine("Número da conta destino inexistente.");
                }
            }
            else
            {
                Console.WriteLine("Número da conta inexistente.");
            }
        }
    }
}
