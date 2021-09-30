using DIO.Bank.Entidades;
using DIO.Bank.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIO.Bank.Services;

namespace DIO.Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario = string.Empty;
            do
            {
                try { 
                    opcaoUsuario = pegarOpcaoUsuario();
                
                    switch (opcaoUsuario)
                    {
                        case "1":
                           ContaService.ListarContas();
                            break;
                        case "2":
                            ContaService.InserirConta();
                            break;
                        case "3":
                            ContaRepositorio.Transferir();
                            break;
                        case "4":
                            ContaService.Sacar();
                            break;
                        case "5":
                            ContaService.Depositar();
                            break;
                        case "C":
                            Console.Clear();
                            break;                  
                    }
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (!opcaoUsuario.Equals("X"));
        }

        private static string pegarOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!");
            Console.WriteLine("Escolha uma opção no menu abaixo: ");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Cadastrar nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
