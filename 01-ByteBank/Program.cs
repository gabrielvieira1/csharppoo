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

      ContaCorrente conta = new ContaCorrente(123, 231123);
      conta.Titular = cliente;
      conta.Agencia = 847;
      conta.Numero = 8476270;

      Cliente cliente1 = new Cliente();
      cliente1.Nome = "Gabriel Vieira";

      ContaCorrente conta1 = new ContaCorrente(123, 231123);
      conta1.Titular = cliente1;
      conta1.Agencia = 847;
      conta1.Numero = 8476270;

      Console.WriteLine(conta.Titular.Nome);
      Console.WriteLine(conta.Agencia);
      Console.WriteLine(conta.Numero);
      Console.WriteLine(conta.Saldo);
      Console.WriteLine(conta1.Titular.Nome);
      Console.WriteLine(conta1.Agencia);
      Console.WriteLine(conta1.Numero);
      Console.WriteLine(conta1.Saldo);
      Console.WriteLine(ContaCorrente.TotalDeContasCriadas);

      Console.ReadLine();
    }
  }
}
