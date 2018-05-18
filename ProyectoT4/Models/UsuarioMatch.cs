using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.Models
{
    public class UsuarioMatch
    {
        public int IdUsuario { get; set; }
        public List<int> JuegosMatch { get; set; }
        public double rating { get; set; }
        public string url { get; set; }
        public UsuarioMatch()
        {
            this.JuegosMatch = new List<int>();
        }
    }
}