using BancoReis.Models;

namespace BancoReis.Utils
{
    public interface IBancoReis
    {
        public bool Login(Conta conta);
        public bool Logout();
        public bool AbrirConta(Conta contaBancaria);
        public bool GerenciarConta(string titular);
        public double Saque(double valor);
        public double Deposito(double valor);
        public double SaldoDaConta();
        public double Emprestimo(double valorEmprestimo);
        public double PagarEmprestimo(double valorEmprestimo);
    }
}
