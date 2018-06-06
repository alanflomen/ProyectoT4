using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ProyectoT4.RelgasNegocio
{
	public class Mailer
	{
		string _sender = "";
		string _password = "";
		public Mailer(string sender, string password)
		{
			_sender = sender;
			_password = password;
		}

		public void EnviarMail(string recipient, string subject, string message) {

			SmtpClient client = new SmtpClient("smtp-mail.outlook.com");

			client.Port = 587;
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			client.UseDefaultCredentials = false;
			System.Net.NetworkCredential credentials =
				new System.Net.NetworkCredential(_sender, _password);
			client.EnableSsl = true;
			client.Credentials = credentials;

			try
			{
				var mail = new MailMessage(_sender.Trim(), recipient.Trim());
				mail.Subject = subject;
				mail.Body = message;
				client.Send(mail);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw ex;
			}


			
			
		}
	}
}