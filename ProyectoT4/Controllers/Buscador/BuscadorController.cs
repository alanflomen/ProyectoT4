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
            //sc.Juegos.Add(new Juego() { Titulo = "God of War", Audio = "Ingles", Categoria = "Fantasia", Rating = 10, Subtitulos = "Español", PathFoto = "https://www.jbhifi.com.au/FileLibrary/ProductResources/Images/237590-L-LO.jpg", Plataforma = "PS4" });
            //sc.Juegos.Add(new Juego() { Titulo = "Far Cry 5", Audio = "Ingles", Categoria = "Accion", Rating = 8, Subtitulos = "Español", PathFoto = "https://images-na.ssl-images-amazon.com/images/I/91q2-WeJxBL._SX342_.jpg", Plataforma = "PS4" });
            //sc.Juegos.Add(new Juego() { Titulo = "Uncharted", Audio = "Español", Categoria = "Aventura", Rating = 9, Subtitulos = "Español", PathFoto = "https://images-na.ssl-images-amazon.com/images/I/71FH9Ghks5L._SX342_.jpg", Plataforma = "PS4" });
            //sc.Juegos.Add(new Juego() { Titulo = "Assassins Creed", Audio = "Ingles", Categoria = "Aventura", Rating = 10, Subtitulos = "Español", PathFoto = "https://images-na.ssl-images-amazon.com/images/I/91g0-r7lZ3L._SX342_.jpg", Plataforma = "PS4" });
            //// para testear: los usuarios hay que agregarlos a mano porque el ID cambia 
            //// cada vez que se registra uno nuevo                       
            //sc.Operaciones.Add(new Operacion("UsuarioEnvia", "UsuarioRecibe", 2, 1, "Enviada"));
            //sc.Operaciones.Add(new Operacion("UsuarioEnvia", "UsuarioRecibe", 3, 4, "Enviada"));
            //sc.Operaciones.Add(new Operacion("UsuarioEnvia", "UsuarioRecibe", 4, 2, "Recibida"));
            //sc.SaveChanges();

            //sistemaContext sc = new sistemaContext();
            //Operacion o = new Operacion("544b282e-c392-4a50-99b9-15622bef7965", "a7261203-c3bf-4b66-a191-ca4882e7901a", 2, 1, -1, -1, "Enviada");
            //sc.Operaciones.Add(o);
            //o = new Operacion("a7261203-c3bf-4b66-a191-ca4882e7901a", "544b282e-c392-4a50-99b9-15622bef7965", 2, 1, -1, -1, "Enviada");
            //sc.Operaciones.Add(o);
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
