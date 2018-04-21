using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoT4.Controllers.ResultadoBusqueda
{
    public class ResultadoBusquedaController : Controller
    {
        // GET: ResultadoBusqueda
        public ActionResult ResultadoBusqueda()
        {
            return View();

        }

        /*Este Metodo es ejecutado por el boton submit del formulario, y captura el string que el formulario carga del usuario
                 * crea una conexion con la db y busca en la tabla Juegos el juego cuyo titulo se corresponde con el recibido por parametro
                 * y manda ese modelo a la vista*/
        [HttpGet]
        public ActionResult ResultadoBusqueda(int id)
        {
            var db = new sistemaContext();
            var juego = db.Juegos.Where(j => j.Id == id).FirstOrDefault();
            
            return View(juego);
        }

    }
}