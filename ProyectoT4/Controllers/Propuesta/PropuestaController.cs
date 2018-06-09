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
            bool operacionValida = RelgasNegocio.ValidacionOperacion.ValidarOperacion(IdJuegoBuscado, IdjuegoOfrecido1, IdjuegoOfrecido2, IdjuegoOfrecido3, UsuarioEnvia, UsuarioRecibe, textoOpcional);
			
			//Contruir la Operacion
			sistemaContext db = new sistemaContext();
			var operacion = new Operacion(UsuarioEnvia, UsuarioRecibe, IdJuegoBuscado, IdjuegoOfrecido1, IdjuegoOfrecido2, IdjuegoOfrecido3, "enviada");
            String texto = "UsuarioEnvia: " + UsuarioEnvia + "\n" +  "UsuarioRecibe: " + UsuarioRecibe + "\n" + "JuegoBuscado: " + db.Juegos.Find(IdJuegoBuscado).Titulo + "\n" + "JuegoOfrecido: " + db.Juegos.Find(IdjuegoOfrecido1).Titulo;



            if (operacionValida)
			{

				//Llamar a la regla de Negocio que envía mail saliente con el aviso de la propuesta
				Mailer mailer = new Mailer("insert-coin@outlook.es", "proyectot4");
				mailer.EnviarMail("alanflomen@gmail.com", "TEST", texto);

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