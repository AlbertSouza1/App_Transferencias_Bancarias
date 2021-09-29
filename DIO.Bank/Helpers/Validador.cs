using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank.Helpers
{
    public static class Validador
    {
        public static int ValidarTipoConta(string entradaTipoConta)
        {
            if (int.TryParse(entradaTipoConta, out int tipoConta) && (tipoConta == 1 || tipoConta == 2))
            {
                return tipoConta;
            }
            else
            {
               Console.WriteLine("Só existem contas de tipo 1 e 2. Certifique-se de digitar um tipo existente.");
                return 0;
            }
        }

        public static bool ValidarSaldoInicial(string entradaSaldo)
        {
            
            if (double.TryParse(entradaSaldo, out double saldo))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Para inidicar o saldo é necessário digitar apenas números.");
                return false;
            }
        }

        public static bool ValidarCreditoInicial(string entradaCredito)
        {

            if (double.TryParse(entradaCredito, out double credito))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Para inidicar o crédito é necessário digitar apenas números.");
                return false;
            }
        }
    }
}
