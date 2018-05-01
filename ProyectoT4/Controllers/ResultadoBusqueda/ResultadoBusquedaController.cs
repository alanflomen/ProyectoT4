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
            @ViewBag.Title = "Resultado de la búsqueda";
            return View();

        }

        /*Este Metodo es ejecutado por el boton submit del formulario, y captura el string que el formulario carga del usuario
                 * crea una conexion con la db y busca en la tabla Juegos el juego cuyo titulo se corresponde con el recibido por parametro
                 * y manda ese modelo a la vista*/
        [HttpGet]
        public ActionResult ResultadoBusqueda(int idJuego)
        {
            var db = new sistemaContext();
            var juego = db.Juegos.Where(j => j.Id == idJuego).FirstOrDefault();
            @ViewBag.Title = juego.Titulo;
            //Con el IdUsuario, busco si ya tengo ese juego en cada una de las listas
            //ViewBag.yaLoJugue = metodoConParametros();
            //ViewBag.wishList = metodoConParametros();
            //ViewBag.loQuiero = metodoConParametros();
            ViewBag.yaLoJugue = false;

            return View(juego);
        }
        //action es a de agregar o q de quitar, para saber a que metodos llamar y tipo es quien lo llama
        //tipo---> j = Jugados, w = WishList , l = Libreria
        public ActionResult ResultadoBusqueda(int idJuego, int idUsuario, char action, char tipo)
        {
            var db = new sistemaContext();
            var juego = db.Juegos.Where(j => j.Id == idJuego).FirstOrDefault();
            @ViewBag.Title = juego.Titulo;

            switch (tipo)
            {
                case 'j':

                    break;

                case 'w':
                        RelgasNegocio.Prueba.ModificarWishList(idJuego, idUsuario, action);
                      break;

                case 'l':

                    break;

                default:
                    break;
            }


            //Con el IdUsuario, busco si ya tengo ese juego en cada una de las listas
            //ViewBag.yaLoJugue = metodoConParametros();
            //ViewBag.wishList = metodoConParametros();
            //ViewBag.loQuiero = metodoConParametros();
            ViewBag.yaLoJugue = true;

            return View(juego);

        }


    }
}