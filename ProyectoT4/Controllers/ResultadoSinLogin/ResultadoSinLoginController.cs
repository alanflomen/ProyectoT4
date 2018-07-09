using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoT4.Controllers
{
    public class ResultadoSinLoginController : Controller
    {
        // GET: ResultadoSinLogin
        public ActionResult ResultadoSinLogin(int idJuego)
        {
            ViewBag.Title = "Resultado Sin Login";

            JuegosMatch jm = AccesoDatos.ArmadorSinLogin.SinLogin(idJuego);
            modeloSinLogin msl = new modeloSinLogin();
            msl.jm = jm;
            return View(msl);
        }
        

    }
}