using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoT4.RelgasNegocio;

namespace ProyectoT4.Controllers.Propuesta
{
    public class PropuestaController : Controller
    {
        // GET: Propuesta
        public ActionResult RealizarPropuesta(int IdJuegoBuscado, int IdjuegoOfrecido1, int IdjuegoOfrecido2, int IdjuegoOfrecido3, string UsuarioEnvia,string UsuarioRecibe, string textoOpcional)
        {
			//Mensaje de resultado de Realizar propueta
			string resPropuesta = "";

			//Realizamos Validaciones en RN
			//ValidacionOperacion validacion = new ValidacionOperacion();
			//bool operacionValida = validacion.ValidarOperacion(Idjuego1, Idjuego2, IdUsuario1, IdUsuario2, textoOpcional);
			bool operacionValida = true;


			//Contruir la Operacion
			sistemaContext db = new sistemaContext();
			var operacion = new Operacion(UsuarioEnvia, UsuarioRecibe, IdJuegoBuscado, IdjuegoOfrecido1, IdjuegoOfrecido2, IdjuegoOfrecido3, "enviada");

			//String jugador1 = db.Usuarios.Find(IdUsuario1).IdUsuario;
			//String jugador2 = db.Usuarios.Find(IdUsuario2).IdUsuario;
			//int juegoBuscado = db.Juegos.Find(IdJuegoBuscado).Id;
			//int juegoOfrecido1 = db.Juegos.Find(IdjuegoOfrecido1).Id;
			//int juegoOfrecido2 = IdjuegoOfrecido2;

			//if (IdjuegoOfrecido2 != -1)
			//{
			//	 = db.Juegos.Find(IdjuegoOfrecido1).Id;
			//}

			//if (IdjuegoOfrecido3 != -1)
			//{
			//	int juegoOfrecido3 = db.Juegos.Find(IdjuegoOfrecido1).Id;
			//}




			if (operacionValida)
			{

				//Llamar a la regla de Negocio que envía mail saliente con el aviso de la propuesta
				Mailer mailer = new Mailer("insert-coin@outlook.es", "proyectot4");
				mailer.EnviarMail("alanflomen@gmail.com", "TEST", "Esta es una prueba de envío automatico desde InserCoin");

				//Guardar en la DB
				db.Operaciones.Add(operacion);
				db.SaveChanges();

				resPropuesta = "Propuesta Realizada y enviada OK";
			}
			else
			{
				resPropuesta = "Propuesta Invalida";
			}
			@ViewBag.Mensaje = resPropuesta;
            return View(operacion);
        }
    }
}