using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoT4.Controllers.Buscador
{
    public class BuscadorController : Controller
    {
        // GET: Buscador
        public ActionResult Buscador()
        {
          //  sistemaContext sc = new sistemaContext();
           //   sc.Juegos.Add(new Juego() { Id = 1, Titulo = "Spider-Man" });
          //  sc.Juegos.Add(new Juego() { Id = 2, Titulo = "Uncharted" });
          //   sc.Juegos.Add(new Juego() { Id = 3, Titulo = "Far Cry 5" });
          //   sc.Juegos.Add(new Juego() { Id = 4, Titulo = "God of War" });
         //    sc.Juegos.Add(new Juego() { Id = 5, Titulo = "Assassin's Creed" });

           // sc.SaveChanges();
            ViewBag.Lista = CrearList();
            return View();
        }

       

        public List<Tuple<int, string>> CrearList() {
            Tuple<int, string> tupla;
            List<Tuple<int,string>> lista = new List<Tuple<int, string>>();
            sistemaContext sc = new sistemaContext();
            var query = from b in sc.Juegos
                        orderby b.Titulo
                        select b;
            foreach (var item in query)
            {
                tupla = new Tuple<int, String>(item.Id, item.Titulo);
                lista.Add(tupla);

            }
            return lista;
        }

    }

   
}
