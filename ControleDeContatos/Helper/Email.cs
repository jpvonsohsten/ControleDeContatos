using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.Extensions.Configuration;
using Microsoft.Web.Services3.Addressing;
using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace ControleDeContatos.Helper
{
    public class Email : IEmail
    {
        // Variáveis de configuração de e-mail (modifique conforme necessário)
        private const string Host = "smtp-mail.outlook.com";
        private const int Porta = 465;
        private const string Username = "jpvonsohsten@hotmail.com"; // Seu e-mail de envio
        private const string Senha = "lkawsydevmfbkaqm";    // Sua senha
        private const string Nome = "Sistema de Contatos"; // Nome que será exibido como remetente

        public bool Enviar(string email, string assunto, string mensagem)
        {
            try
            {
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(Username, Nome)
                };

                mail.To.Add(email);
                mail.Subject = assunto;
                mail.Body = mensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(Host, Porta))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(Username, Senha);
                    smtp.EnableSsl = true;
                    smtp.TargetName = "STARTTLS/smtp.office365.com";

                    smtp.Send(mail);

                    return true;
                }
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"Erro SMTP: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar o e-mail: {ex.Message}");
                return false;
            }
        }
    }
}
