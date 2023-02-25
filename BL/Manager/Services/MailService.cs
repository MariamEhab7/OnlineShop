using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace BL;

public class MailService : IMailService
{
    public void SendEmail(string userMail, string userName)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse("testjust971@gmail.com"));
        email.To.Add(MailboxAddress.Parse(userMail));
        email.Subject = "You have successfully registered";
        var body = "Hello "+userName + "! Welcome To our website";
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
        smtp.Authenticate("testjust971@gmail.com", "sndnssvqyfeicrud");

        smtp.Send(email);
        smtp.Disconnect(true);
    }
}
