using MimeKit;
using MailKit;
using MailKit.Security;
using MailKit.Net.Smtp;

namespace SmtpClientExample {
	public static class Program
	{
		public static void Main ()
		{
			var message = new MimeMessage();
			const string sender = "from@gmail.com";
			
			message.From.Add(InternetAddress.Parse(sender));
			message.To.Add(InternetAddress.Parse("to@gmail.com"));
			message.Subject = "Test Email";
			message.Body = new TextPart("plain") {Text = "This is what a body looks like."};
			
			using (var client = new SmtpClient (new ProtocolLogger ("smtp.log"))) {
				client.Connect ("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);

				client.Authenticate (sender, "password");

				client.Send (message);

				client.Disconnect (true);
			}
		}
	}
}