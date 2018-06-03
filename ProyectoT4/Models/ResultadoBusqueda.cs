using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.Models
{
    public class ResultadoBusqueda
    {
        public Juego JuegoBuscado { get; set; }
        public String IdUsuario { get; set; }
        public List<JuegosMatch> JuegosMatch { get; set; }
        public Boolean yaLoJugue { get; set; }
        public Boolean loTengo { get; set; }
        public Boolean wishList { get; set; }

    }
}