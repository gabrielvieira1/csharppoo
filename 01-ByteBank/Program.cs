using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        //TestaDivisao(0);
        //TestaArgumentException();
        //TestaInnerException();
        CarregarContas();
      }
      catch (DivideByZeroException ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
        Console.WriteLine("Não é possível divisão por 0!");
      }
      catch (ArgumentException ex)
      {
        Console.WriteLine("Argumento com problema: " + ex.ParamName);
        Console.WriteLine("Ocorreu uma exceção do tipo ArgumentException.");
        Console.WriteLine(ex.Message);
      }
      catch (OperacaoFinanceiraException ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);

        Console.WriteLine("Informações da INNER EXCEPTION (exceção interna):");

        Console.WriteLine(ex.InnerException.Message);
        Console.WriteLine(ex.InnerException.StackTrace);
      }
      catch (IOException)
      {
        Console.WriteLine("Exceção do tipo IOException capturada e tratada!");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
      }
      Console.ReadLine();
    }

    private static void CarregarContas()
    {
      using (LeitorDeArquivo leitor1 = new LeitorDeArquivo("teste.txt"))
      {
        leitor1.LerProximaLinha();
        leitor1.LerProximaLinha();
        leitor1.LerProximaLinha();
      }

      LeitorDeArquivo leitor = null;
      try
      {
        leitor = new LeitorDeArquivo("contasl.txt");

        leitor.LerProximaLinha();
        leitor.LerProximaLinha();
        leitor.LerProximaLinha();
      }
      finally
      {
        if (leitor != null)
        {
          leitor.Fechar();
        }
      }
    }

    private static void TestaArgumentException()
    {
      ContaCorrente conta1 = new ContaCorrente(0, 789684);
      //ContaCorrente conta2 = new ContaCorrente(7891, 0);
    }

    private static void TestaInnerException()
    {
        ContaCorrente conta1 = new ContaCorrente(4564, 789684);
        ContaCorrente conta2 = new ContaCorrente(7891, 456794);

        conta1.Transferir(10000, conta2);
    }

    private static void TestaDivisao(int divisor)
    {
      int resultado = Dividir(10, divisor);
      Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);
    }

    private static int Dividir(int numero, int divisor)
    {
      try
      {
        return numero / divisor;
      }
      catch (DivideByZeroException)
      {
        Console.WriteLine("Exceção com numero = " + numero + " e divisor = " + divisor);
        throw;
      }
    }
  }
}