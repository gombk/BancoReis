using BancoReis.Models;
using BancoReis.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BancoReis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBancoReis _bancoReis;

        public HomeController(ILogger<HomeController> logger, IBancoReis bancoReis)
        {
            _logger = logger;
            _bancoReis = bancoReis;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AbrirConta()
        {
            var conta = new Conta();
            return View(conta);
        }

        public IActionResult Entrar()
        {
            return View();
        }

        public IActionResult Gerenciar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Gerenciar(Conta conta)
        {
            _bancoReis.GerenciarConta(conta.NomeTitular);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Emprestimo(double valor)
        {
            double novoSaldoEmprestimo = _bancoReis.Emprestimo(valor);

            return Json(new { success = true, message = $"Empréstimo realizado com sucesso. Saldo restante para pagamento do empréstimo: {novoSaldoEmprestimo}" });
        }
        
        [HttpGet]
        public IActionResult PagarEmprestimo(double valor)
        {
            double novoSaldo = _bancoReis.PagarEmprestimo(valor);

            return Json(new { success = true, message = $"Empréstimo pago com sucesso. Saldo atual {novoSaldo}" });
        }

        [HttpGet]
        public IActionResult Depositar(double valor)
        {
            if (valor <= 0)
            {
                return Json(new { success = false, message = "Valor inválido" });
            }

            double novoSaldo = _bancoReis.Deposito(valor);

            return Json(new { success = true, message = $"Valor depositado com sucesso. Saldo atual: {novoSaldo}" });
        }

        [HttpGet]
        public IActionResult Saque(double valor)
        {
            if (valor > ContaBancaria.Saldo)
            {
                return Json(new { success = false, message = "Você não possui esse valor na sua conta!" });
            }

            double novoSaldo = _bancoReis.Saque(valor);

            return Json(new { success = true, message = $"Valor sacado com sucesso, taxa de 5 reais aplicada. Saldo atual: {novoSaldo}" });
        }

        [HttpPost]
        public IActionResult Entrar(Conta conta)
        {
            if (_bancoReis.Login(conta))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Entrar");
        }

        public IActionResult Sair()
        {
            _bancoReis.Logout();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AbrirConta(Conta contaBancaria)
        {
            _bancoReis.AbrirConta(contaBancaria);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}