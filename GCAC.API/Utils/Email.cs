using System.Net;
using System.Net.Mail;

namespace GCAC.API.Utils
{
    public static class Email
    {
        public static void EnviarLinkAtivacaoUsuario(string email, string tokenAtivacao)
        {
            var client = new SmtpClient()
            {
                Host = "smtp.zoho.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("silvio.silva@swftecnologia.com.br", "17OuTu15"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };

            MailMessage mail = new MailMessage("silvio.silva@swftecnologia.com.br", email);
            mail.Subject = "GCAC - Ativação de Cadastro";
            mail.IsBodyHtml = true;
            mail.Body = "Seja bem-vindo(a)! <br />Você realizou seu cadastro no sistema GCAC.<br />Por motivos de segurança seu cadastro deve ser confirmado. <br /><br /><a href='https://sistemagcac.azurewebsites.net/pages/usuario/conta/ativacao.html?email=" + email + "&tokenAtivacao=" + tokenAtivacao + "'>Clique aqui ou copie e cole este link no navegador para ativar o seu cadastro.</a><br /><br />Caso não tenha realizado este cadastro, favor desconsiderar este e-mail.<br /><br />Atenciosamente, <br />Equipe GCAC";

            client.Send(mail);
        }
    }
}
