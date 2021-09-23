using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIO.Bank.Enums;

namespace DIO.Bank.Entidades
{
    public class Conta
    {
        public Conta(string nome, TipoConta tipoConta, double saldo, double credito)
        {
            this.Nome = nome;
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
        }
        public string Nome { get; private set; }
        public TipoConta TipoConta { get; private set; }
        public double Saldo { get; private set; }
        public double Credito { get; private set; }

        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito*-1))
            {
                Console.WriteLine("Saldo insuficiente.");
                return false;
            } 
            
            this.Saldo -= valorSaque;
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
           
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
                Console.WriteLine($"Transferência realizada com sucesso.");
            }
        }

        public override string ToString()
        {
            string retorno = Environment.NewLine+"Nome: "+this.Nome;
            retorno += Environment.NewLine + "Tipo da conta: " + Enum.GetName(typeof(TipoConta), this.TipoConta);
            retorno += Environment.NewLine + "Saldo: R$" + this.Saldo;
            retorno += Environment.NewLine + "Crédito: R$" + this.Credito;
            return retorno;
        }
    }
}
