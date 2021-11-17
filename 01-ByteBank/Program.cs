using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ByteBank
{
  class Program
  {
    static void Main(string[] args)
    {
      ContaCorrente conta = new ContaCorrente();
      conta.titular = "Isabela";
      conta.agencia = 847;
      conta.numero = 8476270;

      ContaCorrente primeiraContaCorrente = new ContaCorrente();
      primeiraContaCorrente.saldo = 200;
      Console.WriteLine(primeiraContaCorrente.saldo);

      primeiraContaCorrente.saldo += 100;
      Console.WriteLine(primeiraContaCorrente.saldo);

      ContaCorrente segundaContaCorrente = new ContaCorrente();
      segundaContaCorrente.saldo = 50;

      Console.WriteLine("primeira conta tem " + primeiraContaCorrente.saldo);
      Console.WriteLine("segunda conta tem " + segundaContaCorrente.saldo);

      primeiraContaCorrente = segundaContaCorrente;
      Console.WriteLine("mesma referência conta tem " + primeiraContaCorrente.saldo);

      Console.ReadLine();

      Console.ReadLine();
    }
  }
}
