using discovercars_email.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

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


            var mail = new MailMessage();

            mail.From = new MailAddress(email);
            mail.To.Add("discover.cars.br@gmail.com");
            mail.Subject = string.Format("Novo Cadastro - {0}", nome);
            mail.Body = string.Format("Interesse: {0} \r\nNome: {1} \r\nEndereço: {2} \r\nBairro: {3} \r\nTelefone: {4} \r\nCelular: {5}",
                interesse, nome, endereco, bairro, telefone, celular);

            using (var smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential("xpto@gmail.com", "xpto");

                try
                {
                    smtp.Send(mail);
                }
                catch (Exception ex)
                {
                }
            }

            return View("Index", new SucessViewModel { Mensagem = "E-mail gravado com sucesso" });
        }
    }
}
