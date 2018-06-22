using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoT4.RelgasNegocio;
using Microsoft.AspNet.Identity;

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
			var operacion = new Operacion(UsuarioEnvia, UsuarioRecibe, IdJuegoBuscado, IdjuegoOfrecido1, IdjuegoOfrecido2, IdjuegoOfrecido3, "enviada", null);
            String texto = "El usuario xxxx te envía la siguiente propuesta:" + "\n" + "Quiero cambiar tu: " + db.Juegos.Find(IdJuegoBuscado).Titulo + "\n" + "Por mi: " + db.Juegos.Find(IdjuegoOfrecido1).Titulo + "\n";
            if (operacion.Mensajes != null && !textoOpcional.Equals("undefined") && !operacion.Mensajes.Equals(""))
            {
                texto = texto + "Y dice: " + textoOpcional;
            }
            string mail = db.Usuarios.Find(UsuarioRecibe).mail;
            mail = "alanflomen@gmail.com";

            if (operacionValida)
			{
				//Llamar a la regla de Negocio que envía mail saliente con el aviso de la propuesta
				Mailer mailer = new Mailer("insert-coin@outlook.es", "proyectot4");
				mailer.EnviarMail(mail, "Tenés una nueva propuesta!", texto);

				//Guardar en la DB
				db.Operaciones.Add(operacion);
				db.SaveChanges();

				resPropuesta = "Propuesta realizada y enviada!";
			}
			else
			{
				resPropuesta = "Propuesta Invalida";
			}
			@ViewBag.Mensaje = resPropuesta;
			
			return RedirectToAction("ResultadoBusqueda", "ResultadoBusqueda", new { idJuego = IdJuegoBuscado, idUsuario = UsuarioEnvia, RealizarPropuesta_result = resPropuesta });

		}


		public ActionResult AnalizarPropuesta(string UsuarioEnvia, string UsuarioRecibe, int IdJuegoBuscado, int IdjuegoOfrecido1)
		{
			//Llegan 2 usuarios y dos juegos
			ModeloPropuesta mp = new ModeloPropuesta(UsuarioEnvia, UsuarioRecibe, IdJuegoBuscado, IdjuegoOfrecido1);
			return View(mp);
		}        
        public ActionResult AnalizarPropuestaGestionador(int idOperacion, string idUsuario)
        {
            ModeloPropuesta mp = new ModeloPropuesta(idOperacion);
            //si el usuario que recibe la propuesta, ya hizo contra oferta
            if (mp.oper.Estado.Equals("contraOfertaRecibe") && mp.usuarioRecibe.IdUsuario.Equals(idUsuario))
            {
                mp.BtnContraOferta = false;
            }
            //si el usuario que envia la propuesta, ya hizo contra oferta
            if (mp.oper.Estado.Equals("contraOfertaEnvia") && mp.usuarioEnvia.IdUsuario.Equals(idUsuario))
            {
                mp.BtnContraOferta = false;
            }
            if (mp.oper.Estado.Equals("enviada") && mp.usuarioEnvia.IdUsuario.Equals(idUsuario))
            {
                mp.BtnAceptar = false;
                mp.BtnContraOferta = false;

            }

            return View("AnalizarPropuesta", mp);
        }

        public ActionResult AceptarPropuesta(int idOperacion, String idUsuarioActual)
        {
            //busco los usuarios y saco de sus wishlist los juegos de la operacion y de su libreria
            sistemaContext db = new sistemaContext();
            Operacion ope = db.Operaciones.Find(idOperacion);
            //cambio el estado a aceptada
            ope.Estado = "aceptada";
            //los saco de la wishlist
            int idJuegoBuscado = ope.JuegoBuscado;
            String idUsuarioBusca = ope.UsuarioEnvia;
            WishList w = db.Wishlist.Find(idUsuarioBusca, idJuegoBuscado);
            db.Wishlist.Remove(w);
            int idjuegoOfrecido = ope.JuegoOfrecido1;
            String idUsuarioRecibe = ope.UsuarioRecibe;
            w = db.Wishlist.Find(idUsuarioRecibe, idjuegoOfrecido);
            db.Wishlist.Remove(w);
            if (ope.JuegoOfrecido2 != -1)
            {
                idjuegoOfrecido = ope.JuegoOfrecido2;
                w = db.Wishlist.Find(idUsuarioRecibe, idjuegoOfrecido);
                db.Wishlist.Remove(w);
            }
            if (ope.JuegoOfrecido3 != -1)
            {
                idjuegoOfrecido = ope.JuegoOfrecido2;
                w = db.Wishlist.Find(idUsuarioRecibe, idjuegoOfrecido);
                db.Wishlist.Remove(w);
            }
            //ahora los saco de la libreria

            Libreria l = db.Libreria.Find(idUsuarioRecibe, ope.JuegoBuscado);
            db.Libreria.Remove(l);

            l = db.Libreria.Find(idUsuarioBusca, ope.JuegoOfrecido1);
            db.Libreria.Remove(l);

            if (ope.JuegoOfrecido2 != -1)
            {
                l = db.Libreria.Find(idUsuarioBusca, ope.JuegoOfrecido2);
                db.Libreria.Remove(l);
            }
            if (ope.JuegoOfrecido3 != -1)
            {
                l = db.Libreria.Find(idUsuarioBusca, ope.JuegoOfrecido3);
                db.Libreria.Remove(l);
            }

            db.SaveChanges();
            //mando el mail     
            String texto = "Propuesta aceptada!" + "\n" + "Detalles:" + "\n" + "Juego a cambiar: " + db.Juegos.Find(ope.JuegoBuscado).Titulo + "\n" + "Por: " + db.Juegos.Find(ope.JuegoOfrecido1).Titulo;
            string mail;
            if (idUsuarioActual.Equals(ope.UsuarioEnvia))
            {
                mail = db.Usuarios.Find(idUsuarioRecibe).mail;
            }
            else
            {
                mail = db.Usuarios.Find(idUsuarioBusca).mail;
            }
            mail = "alanflomen@gmail.com";
            Mailer mailer = new Mailer("insert-coin@outlook.es", "proyectot4");
            mailer.EnviarMail(mail, "Propuesta Aceptada!", texto);
            return RedirectToAction("VerPropuestas","VerPropuestas", new { idUsuario = idUsuarioActual, msj = "Propuesta aceptada!" });
        }

        public ActionResult RealizarContraOferta(string idUsuarioActual , int idOperacion, string textoOpcional)
        {
            //estado-previo: el usuario de la sesión analiza una propuesta y decide agregar texto y enviarla como contra-oferta
            //llega por parametros una operación y un texto adicional
            String resultado = "";
            //buscar la operación
            sistemaContext sc = new sistemaContext();
            Operacion op = sc.Operaciones.Find(idOperacion);
			//cambiarle el estado según quien sea el que hace la contraoferta
			if (idUsuarioActual == op.UsuarioRecibe)
			{
				op.Estado = "contraOfertaRecibe";
			}
			else
			{
				op.Estado = "contraOfertaEnvia";
			}

            //agregarle el texto incrementado
            if (op.Mensajes != null && !textoOpcional.Equals("undefined") && !op.Mensajes.Equals(""))
            {
                op.Mensajes = op.Mensajes + ">" + textoOpcional;
            }
            else if (!textoOpcional.Equals("") && !textoOpcional.Equals("undefined"))
            {
                op.Mensajes = textoOpcional;
            }

            //mando el mail     
            String texto = "Contra-Oferta!" + "\n" + "Detalles:" + "\n" + "Juego a cambiar: " + sc.Juegos.Find(op.JuegoBuscado).Titulo + "\n" + "Por: " + sc.Juegos.Find(op.JuegoOfrecido1).Titulo;
            if (op.Mensajes != null && !textoOpcional.Equals("undefined") && !op.Mensajes.Equals(""))
            {
                texto = texto + "\n" + "Y dice: " + textoOpcional;
            }
            string mail;
            if (idUsuarioActual.Equals(op.UsuarioEnvia))
            {
                mail = sc.Usuarios.Find(op.UsuarioRecibe).mail;
            }
            else
            {
                mail = sc.Usuarios.Find(op.UsuarioEnvia).mail;
            }
            mail = "alanflomen@gmail.com";
            //Llamar a la regla de Negocio que envía mail saliente con el aviso del rechazo de la propuesta
            Mailer mailer = new Mailer("insert-coin@outlook.es", "proyectot4");
			mailer.EnviarMail(mail, "Contra-Oferta!", texto);
			sc.SaveChanges();


			//resultado de la operación
			resultado = "Contra-Oferta enviada";
			
            //guardar los cambios
            sc.SaveChanges();

            //volver a la pantalla de analizar propuesta con un resultado de la acción
            return RedirectToAction("VerPropuestas", "VerPropuestas", new { idUsuario = idUsuarioActual, msj = resultado });
        }

        public ActionResult RechazarPropuesta(string usuarioActual, int idOperacion, string textoOpcional)
        {
            //Resultado de la acción
            String resultado = "";
            //Verificar que la propuesta a rechazar aun exista (es posible esto?)
            //Buscar la Operacion en la db
            sistemaContext sc = new sistemaContext();
            Operacion op = sc.Operaciones.Find(idOperacion);

            //si existe	
            if (op != null && !op.Estado.Equals("cancelada") && !op.Estado.Equals("aceptada"))
            {
                //cambiarle el estado a rechazada
                op.Estado = "rechazada";
                if (op.Mensajes != null && !textoOpcional.Equals("undefined") && !op.Mensajes.Equals(""))
                {
                    op.Mensajes = op.Mensajes + ">" + textoOpcional;
                }
                else if(!textoOpcional.Equals("") && !textoOpcional.Equals("undefined"))
                {
                    op.Mensajes = textoOpcional;
                }

                //mando el mail     
                String texto = "Propuesta Rechazada!" + "\n" + "Detalles:" + "\n" + "Juego a cambiar: " + sc.Juegos.Find(op.JuegoBuscado).Titulo + "\n" + "Por: " + sc.Juegos.Find(op.JuegoOfrecido1).Titulo;
                if (op.Mensajes != null && !textoOpcional.Equals("undefined") && !op.Mensajes.Equals(""))
                {
                    texto = texto + "\n" + "Y dice: " + textoOpcional;
                }
                string mail;
                if (usuarioActual.Equals(op.UsuarioEnvia))
                {
                    mail = sc.Usuarios.Find(op.UsuarioRecibe).mail;
                }
                else
                {
                    mail = sc.Usuarios.Find(op.UsuarioEnvia).mail;
                }
                mail = "alanflomen@gmail.com";
                //Llamar a la regla de Negocio que envía mail saliente con el aviso del rechazo de la propuesta
                Mailer mailer = new Mailer("insert-coin@outlook.es", "proyectot4");
				mailer.EnviarMail(mail, "Propuesta Rechazada!", texto);
				sc.SaveChanges();

                resultado = "Operacion #: " + idOperacion + " Rechazada";
            }
            else //no existe
            {
                //avisar que la operacion ya fue anulada
                resultado = "La operacion #" + idOperacion + " ya fue previamente cancelada.";
            }
            //creo vector con mensajes


            //volver a la vista
            return RedirectToAction("VerPropuestas", "VerPropuestas", new { idUsuario = usuarioActual, msj = resultado });

        }


    }
}