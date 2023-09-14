using BancoReis.Models;

namespace BancoReis.Utils
{
    public class Banco : IBancoReis
    {
        public bool AbrirConta(Conta contaBancaria)
        {
            ContaBancaria.NomeTitular = contaBancaria.NomeTitular;
            ContaBancaria.NumeroConta = contaBancaria.NumeroConta;

            if (contaBancaria.Saldo > 0)
            {
                ContaBancaria.Saldo = contaBancaria.Saldo;
            }

            return true;
        }

        public bool GerenciarConta(string titular)
        {
            ContaBancaria.NomeTitular = titular;

            return true;
        }

        public double SaldoDaConta()
        {
            return ContaBancaria.Saldo;
        }

        public double Emprestimo(double valorEmprestimo)
        {
            ContaBancaria.Saldo += valorEmprestimo;

            return ContaBancaria.EmprestimoRestante = valorEmprestimo + valorEmprestimo * 0.95;
        }

        public double PagarEmprestimo(double valorEmprestimo)
        {
            ContaBancaria.EmprestimoRestante = 0;
            ContaBancaria.ValorEmprestimo = new Random().Next(500, 500000);
            ContaBancaria.Saldo -= valorEmprestimo;

            return ContaBancaria.Saldo;
        }

        public double Deposito(double valor)
        {
            if (valor == 0)
            {
                return ContaBancaria.Saldo;
            }

            ContaBancaria.Saldo += valor;

            return ContaBancaria.Saldo;
        }

        public double Saque(double valor)
        {
            if (valor == 0)
            {
                return ContaBancaria.Saldo;
            }

            ContaBancaria.Saldo = ContaBancaria.Saldo - valor - 5;

            return ContaBancaria.Saldo;
        }

        public bool Login(Conta conta)
        {
            if (ContaBancaria.NumeroConta == conta.NumeroConta)
            {
                ContaBancaria.NomeTitular = conta.NomeTitular;
                ContaBancaria.Saldo = conta.Saldo;

                return true;
            }

            return false;
        }

        public bool Logout()
        {
            ContaBancaria.NomeTitular = null;

            return true;
        }
    }
}
