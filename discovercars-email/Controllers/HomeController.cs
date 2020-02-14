using discovercars_email.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace discovercars_email.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult EnviarDadosCadastro(IFormCollection form)
        {
            var interesse = form["interesse"];
            var nome = form["nome"];
            var email = form["email-usu"];
            var endereco = form["endereco"];
            var bairro = form["bairro"];
            var telefone = form["telefone"];
            var celular = form["celular"];
            
            return new EmptyResult();
        }
    }
}
