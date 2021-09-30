using DIO.Bank.Entidades;
using DIO.Bank.Enums;
using DIO.Bank.Services;
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
        public static List<Conta> ListarContas()
        {
            
            if (listaContas.Count == 0)
            {
                return null;
            }
            else
            {              
                return listaContas;
            }
        }
        public static Conta RecuperarContaPorId(int idConta)
        {
            return listaContas[idConta];
        }
        public static bool InserirConta(Conta conta)
        {
            try
            {
                listaContas.Add(conta);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
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

        public static void Transferir(double valorTransferencia, int indiceRementente, int indiceDestino)
        {
            try
            {
                listaContas[indiceRementente].Transferir(valorTransferencia, listaContas[indiceDestino]);

            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
