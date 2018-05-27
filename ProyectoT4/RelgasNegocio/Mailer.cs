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
			SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

			smtpClient.Credentials = new System.Net.NetworkCredential("insertcoin.proyectot4@gmail.com", "proyectot4");
	
			smtpClient.UseDefaultCredentials = true;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.EnableSsl = true;
			MailMessage mail = new MailMessage() ;
			
			
			//Setting From , To and CC
			mail.From = new MailAddress("insertcoin.proyectot4@gmail.com", "InsertCoin");
			mail.To.Add(new MailAddress("insertcoin.proyectot4@gmail.com"));
			//mail.CC.Add(new MailAddress("vicentini.nicolas@gmail.com"));


			smtpClient.Send(mail);

			//try
			//{
			//	smtpClient.Send(mail);
			//}
			//catch (Exception ex)
			//{
			//	throw new Exception("No se ha podido enviar el email", ex.InnerException);
			//}
			//finally
			//{
			//	smtpClient.Dispose();
			//}
			
		}
	}
}