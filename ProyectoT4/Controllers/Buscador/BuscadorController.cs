using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProyectoT4.Controllers.Buscador
{
    public class BuscadorController : Controller
    {
        // GET: Buscador
        public ActionResult Buscador()
        {
            //sistemaContext sc = new sistemaContext();
            //sc.Juegos.Add(new Juego() { Titulo = "Spider-Man", Audio = "Ingles", Categoria = "Aventura", Rating = 9, Subtitulos = "Español", PathFoto = "https://i.pinimg.com/originals/14/e2/fc/14e2fc8f881a66aeccef812fa28bb1c0.png", Plataforma = "PS4" });
            //sc.Juegos.Add(new Juego() { Titulo = "God of War", Audio = "Ingles", Categoria = "Fantasia", Rating = 10, Subtitulos = "Español", PathFoto = "https://i.ebayimg.com/images/g/mzgAAOSwwWJau7rM/s-l300.jpg", Plataforma = "PS4" });
            //sc.Juegos.Add(new Juego() { Titulo = "Far Cry 5", Audio = "Ingles", Categoria = "Accion", Rating = 8, Subtitulos = "Español", PathFoto = "https://images-na.ssl-images-amazon.com/images/I/91q2-WeJxBL._SX342_.jpg", Plataforma = "PS4" });
            //sc.Juegos.Add(new Juego() { Titulo = "Uncharted", Audio = "Español", Categoria = "Aventura", Rating = 9, Subtitulos = "Español", PathFoto = "https://images-na.ssl-images-amazon.com/images/I/71FH9Ghks5L._SX342_.jpg", Plataforma = "PS4" });
            //sc.Juegos.Add(new Juego() { Titulo = "Assassins Creed", Audio = "Ingles", Categoria = "Aventura", Rating = 10, Subtitulos = "Español", PathFoto = "https://images-na.ssl-images-amazon.com/images/I/91g0-r7lZ3L._SX342_.jpg", Plataforma = "PS4" });            
            //sc.SaveChanges();



            ViewBag.Lista = CrearList();            
            @ViewBag.Title = "Buscador";
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
