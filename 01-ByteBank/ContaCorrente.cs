using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
  public class ContaCorrente
  {
    private static int TaxaOperacao;

    public static int TotalDeContasCriadas { get; private set; }

    public Cliente Titular { get; set; }

    public int ContadorTransferenciasNaoPermitidas { get; private set; }

    private readonly int _numero;
    public int Numero2
    {
      get
      {
        return _numero;
      }
    }

    public int Numero { get; }
    public int Agencia { get; }
    public int ContadorSaquesNaoPermitidos { get; private set; }

    private double _saldo = 100;
    public double Saldo
    {
      get
      {
        return _saldo;
      }
      set
      {
        if (value < 0)
        {
          return;
        }

        _saldo = value;
      }
    }

    public ContaCorrente(int agencia, int numero)
    {
      if (agencia <= 0)
      {
        throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
      }

      if (numero <= 0)
      {
        throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
      }

      Agencia = agencia;
      Numero = numero;

      TotalDeContasCriadas++;
      TaxaOperacao = 30 / TotalDeContasCriadas;
    }

    public void Depositar(double valor)
    {
      _saldo += valor;
    }

    public void Sacar(double valor)
    {
      if (valor < 0)
      {
        throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
      }

      if (_saldo < valor)
      {
        ContadorSaquesNaoPermitidos++;
        throw new SaldoInsuficienteException(Saldo, valor);
      }

      _saldo -= valor;
    }

    public void Transferir(double valor, ContaCorrente contaDestino)
    {
      if (valor < 0)
      {
        throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
      }

      try
      {
        Sacar(valor);
      }
      catch (SaldoInsuficienteException ex)
      {
        ContadorTransferenciasNaoPermitidas++;
        throw new OperacaoFinanceiraException("Operação não realizada.", ex);
      }

      contaDestino.Depositar(valor);
    }
  }
}