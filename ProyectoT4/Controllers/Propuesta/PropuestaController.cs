﻿using ProyectoT4.Models;
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
        public ActionResult RealizarPropuesta(int Idjuego1, int Idjuego2, string IdUsuario1,string IdUsuario2, string textoOpcional)
        {
			//Mensaje de resultado de Realizar propueta
			string resPropuesta = "";

			//Realizamos Validaciones en RN
			ValidacionOperacion validacion = new ValidacionOperacion();
			bool operacionValida = validacion.ValidarOperacion(Idjuego1, Idjuego2, IdUsuario1, IdUsuario2, textoOpcional);


			//Contruir la Operacion

			sistemaContext db = new sistemaContext();
			Usuario jugador1 = db.Usuarios.Find(IdUsuario1);
			Usuario jugador2 = db.Usuarios.Find(IdUsuario2);
			Juego juego1 = db.Juegos.Find(Idjuego1);
			Juego juego2 = db.Juegos.Find(Idjuego2);

			var operacion = new Operacion(jugador1, jugador2, juego1, juego2);
			

			

			if (operacionValida)
			{
				
				//Llamar a la regla de Negocio que envía mail saliente con el aviso de la propuesta

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