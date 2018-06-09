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
        [Authorize]
        public ActionResult ResultadoBusqueda(int idJuego, String idUsuario)
        {            
            var db = new sistemaContext();
            ProyectoT4.Models.ResultadoBusqueda res = new Models.ResultadoBusqueda();
            //completo el modelo a pasar
            res.JuegoBuscado = db.Juegos.Find(idJuego);
            @ViewBag.Title = res.JuegoBuscado.Titulo;
            
            res.IdUsuario = idUsuario;
            //metodo que matchea y crea los usuarios matcheados con sus juegos, y me devuelve la lista
            res.JuegosMatch = RelgasNegocio.Matches.ListaMatch(idUsuario, idJuego);

            //Con el IdUsuario, busco si ya tengo ese juego en cada una de las listas          
            res.yaLoJugue = RelgasNegocio.Prueba.viewBagJugados(idUsuario, idJuego);
            res.loTengo = RelgasNegocio.Prueba.viewBagLibreria(idUsuario, idJuego);
            res.wishList = RelgasNegocio.Prueba.viewBagWishList(idUsuario, idJuego);

            return View(res);
        }
        //action es a de agregar o q de quitar, para saber a que metodos llamar y tipo es quien lo llama
        //tipo---> j = Jugados, w = WishList , l = Libreria
        [Authorize]
        public ActionResult AgregaLista(int idJuego, String idUsuario, string tipo)
        {
            var db = new sistemaContext();
            ProyectoT4.Models.ResultadoBusqueda res = new Models.ResultadoBusqueda();
            res.JuegoBuscado = db.Juegos.Find(idJuego);
            @ViewBag.Title = res.JuegoBuscado.Titulo;
            res.IdUsuario = idUsuario;

            RelgasNegocio.Prueba.AgregaLista(idJuego, idUsuario, tipo);

            //metodo que matchea y crea los usuarios matcheados con sus juegos
            res.JuegosMatch = RelgasNegocio.Matches.ListaMatch(idUsuario, idJuego);


            //Con el IdUsuario, busco si ya tengo ese juego en cada una de las listas
            res.yaLoJugue = RelgasNegocio.Prueba.viewBagJugados(idUsuario, idJuego);
            res.loTengo = RelgasNegocio.Prueba.viewBagLibreria(idUsuario, idJuego);
            res.wishList = RelgasNegocio.Prueba.viewBagWishList(idUsuario, idJuego);

            return View("ResultadoBusqueda", res);

        }
        [Authorize]
        public ActionResult EliminarLista(int idJuego, String idUsuario, string tipo)
        {
            var db = new sistemaContext();
            ProyectoT4.Models.ResultadoBusqueda res = new Models.ResultadoBusqueda();
            res.JuegoBuscado = db.Juegos.Find(idJuego);
            @ViewBag.Title = res.JuegoBuscado.Titulo;
            res.IdUsuario = idUsuario;

            //elimina las propuestas activas que involucren ese juego
            RelgasNegocio.ManejadorOperacion.canceladorDePropuestas(idUsuario, idJuego);

            RelgasNegocio.Prueba.EliminarLista(idJuego, idUsuario, tipo);

            //metodo que matchea y crea los usuarios matcheados con sus juegos
            res.JuegosMatch = RelgasNegocio.Matches.ListaMatch(idUsuario, idJuego);

            //Con el IdUsuario, busco si ya tengo ese juego en cada una de las listas
            res.yaLoJugue = RelgasNegocio.Prueba.viewBagJugados(idUsuario, idJuego);
            res.loTengo = RelgasNegocio.Prueba.viewBagLibreria(idUsuario, idJuego);
            res.wishList = RelgasNegocio.Prueba.viewBagWishList(idUsuario, idJuego);

            return View("ResultadoBusqueda", res);

        }

    }
}