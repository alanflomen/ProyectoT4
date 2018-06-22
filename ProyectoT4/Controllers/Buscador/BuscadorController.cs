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
                     
            // instancio la BD
            AccesoDatos.Instanciador.instanciarBD();

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
