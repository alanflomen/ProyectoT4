using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.Models
{
    public class JuegosMatch
    {
        public int IdJuego { get; set; }
        public List<Usuario> UsuariosMatch { get; set; }
        public float rating { get; set; }
        public string Titulo { get; set; }
        public String PathFoto { get; set; }

        public JuegosMatch(int idJuego, float rating, String titulo, String urlFoto)
        {
            this.IdJuego = idJuego;
            this.rating = rating;
            this.Titulo = titulo;
            this.PathFoto = urlFoto;
            this.UsuariosMatch = new List<Usuario>();
        }
    }
}