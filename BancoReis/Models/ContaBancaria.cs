using System.ComponentModel.DataAnnotations;

namespace BancoReis.Models
{
    public class ContaBancaria
    {
        public static int NumeroConta { get; set; }
        public static string NomeTitular { get; set; } = null!;
        public static double Saldo { get; set; } = 0;
        public static double EmprestimoRestante { get; set; } = 0;
        public static double ValorEmprestimo { get; set; } = new Random().Next(500, 20000);
    }

    public class Conta
    {
        [Display(Name = "Número da sua conta (Salve esse número por que ele só aparece uma vez aqui)")]
        public int NumeroConta { get; set; } = new Random().Next(100000, 999999);

        [Display(Name = "Nome do titular")]
        [Required]
        public string NomeTitular { get; set; } = null!;

        [Display(Name = "Insira o valor do depósito (R$)")]
        public double Saldo { get; set; } = 0;

    }
}