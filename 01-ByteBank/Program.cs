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
      Cliente cliente = new Cliente();
      cliente.Nome = "Gabriel";

      ContaCorrente conta = new ContaCorrente();
      conta.Titular = cliente;
      conta.Agencia = 847;
      conta.Numero = 8476270;

      Console.WriteLine(conta.Saldo);
      Console.WriteLine(conta.Titular.Nome);

      Console.ReadLine();
    }
  }
}
