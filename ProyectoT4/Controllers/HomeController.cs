using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoT4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //sistemaContext sc = new sistemaContext();
          //  sc.Juegos.Add(new Juego() { Id = 1, Titulo = "Spider-Man" });
            //sc.Juegos.Add(new Juego() { Id = 2, Titulo = "Uncharted" });
           // sc.Juegos.Add(new Juego() { Id = 3, Titulo = "Far Cry 5" });
           // sc.Juegos.Add(new Juego() { Id = 4, Titulo = "God of War" });
           // sc.Juegos.Add(new Juego() { Id = 5, Titulo = "Assassin's Creed" });

           // sc.SaveChanges();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}