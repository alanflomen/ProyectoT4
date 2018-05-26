using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ProyectoT4.RelgasNegocio
{
	public class Mailer
	{

		public void EnviarMail() {
			SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 465);

			smtpClient.Credentials = new System.Net.NetworkCredential("insertCoin@gmail.com", "myIDPassword");
	
			smtpClient.UseDefaultCredentials = true;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.EnableSsl = true;
			MailMessage mail = new MailMessage();

			//Setting From , To and CC
			mail.From = new MailAddress("insertCoin@gmail.com", "MyWeb Site");
			mail.To.Add(new MailAddress("insertCoin@gmail.com"));
			mail.CC.Add(new MailAddress("vicentini.nicolas@gmail.com"));

			smtpClient.Send(mail);
		}
	}
}