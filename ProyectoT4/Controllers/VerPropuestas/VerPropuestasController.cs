using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoT4.Controllers
{
    public class VerPropuestasController : Controller
    {
        // GET: VerPropuestas
        public ActionResult VerPropuestas(String idUsuario)
        {
            @ViewBag.Title = "Ver Propuestas";

            ContenedorPropuesta listado;
            List<ModeloPropuesta> enviadas;
            List<ModeloPropuesta> recibidas;
            enviadas = AccesoDatos.ArmadorDePropuestas.generarEnviadas(idUsuario);
            recibidas = AccesoDatos.ArmadorDePropuestas.generarRecibidas(idUsuario);
            listado = new ContenedorPropuesta(enviadas, recibidas);

            return View(listado);
        }
    }
}