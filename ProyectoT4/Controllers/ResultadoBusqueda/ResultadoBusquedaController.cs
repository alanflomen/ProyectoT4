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
                /*Este Metodo es ejecutado por el boton submit del formulario, y captura el string que el formulario carga del usuario
                 * crea una conexion con la db y busca en la tabla Juegos el juego cuyo titulo se corresponde con el recibido por parametro
                 * y manda ese modelo a la vista*/
        public ActionResult ResultadoBusqueda(int idJuego)
        {            
            var db = new sistemaContext();
            ProyectoT4.Models.ResultadoBusqueda res = new Models.ResultadoBusqueda();
            //completo el modelo a pasar
            res.JuegoBuscado = db.Juegos.Find(idJuego);
            @ViewBag.Title = res.JuegoBuscado.Titulo;
            res.IdUsuario = 1;
            //metodo que matchea y crea los usuarios matcheados con sus juegos, y me devuelve la lista
            res.UsuariosMatch = RelgasNegocio.Matches.ListaMatch(1, idJuego);

            //Con el IdUsuario, busco si ya tengo ese juego en cada una de las listas          
            ViewBag.yaLoJugue = RelgasNegocio.Prueba.viewBagJugados(1, idJuego);
            ViewBag.loTengo = RelgasNegocio.Prueba.viewBagLibreria(1, idJuego);
            ViewBag.wishList = RelgasNegocio.Prueba.viewBagWishList(1, idJuego);

            return View(res);
        }
        //action es a de agregar o q de quitar, para saber a que metodos llamar y tipo es quien lo llama
        //tipo---> j = Jugados, w = WishList , l = Libreria
        public ActionResult AgregaLista(int idJuego, int idUsuario, string tipo)
        {
            var db = new sistemaContext();
            ProyectoT4.Models.ResultadoBusqueda res = new Models.ResultadoBusqueda();
            res.JuegoBuscado = db.Juegos.Find(idJuego);
            @ViewBag.Title = res.JuegoBuscado.Titulo;
            res.IdUsuario = idUsuario;
            //metodo que matchea y crea los usuarios matcheados con sus juegos
            res.UsuariosMatch = RelgasNegocio.Matches.ListaMatch(idUsuario, idJuego);

            RelgasNegocio.Prueba.AgregaLista(idJuego, idUsuario, tipo);

            //Con el IdUsuario, busco si ya tengo ese juego en cada una de las listas
            ViewBag.yaLoJugue = RelgasNegocio.Prueba.viewBagJugados(1, idJuego);
            ViewBag.loTengo = RelgasNegocio.Prueba.viewBagLibreria(1, idJuego);
            ViewBag.wishList = RelgasNegocio.Prueba.viewBagWishList(1, idJuego);

            return View("ResultadoBusqueda", res);

        }
        public ActionResult EliminarLista(int idJuego, int idUsuario, string tipo)
        {
            var db = new sistemaContext();
            ProyectoT4.Models.ResultadoBusqueda res = new Models.ResultadoBusqueda();
            res.JuegoBuscado = db.Juegos.Find(idJuego);
            @ViewBag.Title = res.JuegoBuscado.Titulo;
            res.IdUsuario = idUsuario;
            //metodo que matchea y crea los usuarios matcheados con sus juegos
            res.UsuariosMatch = RelgasNegocio.Matches.ListaMatch (idUsuario, idJuego);

            RelgasNegocio.Prueba.EliminarLista(idJuego, idUsuario, tipo);

            //Con el IdUsuario, busco si ya tengo ese juego en cada una de las listas
            ViewBag.yaLoJugue = RelgasNegocio.Prueba.viewBagJugados(1, idJuego);
            ViewBag.loTengo = RelgasNegocio.Prueba.viewBagLibreria(1, idJuego);
            ViewBag.wishList = RelgasNegocio.Prueba.viewBagWishList(1, idJuego);

            return View("ResultadoBusqueda", res);

        }

    }
}