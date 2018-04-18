using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.Models
{
    public class Juego
    {
        public int Id { get; set; }
        public String Titulo { get; set; }
        public String Categoria { get; set; }
        //public File PathFoto { get; set; }
        public float Rating { get; set; }
        public String Audio { get; set; }
        public String Subtitulos { get; set; }


        //constructor parametrizado para probar el programa
        public Juego(int id, string titulo, string categoria, float rating, string audio, string subtitulos)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Categoria = categoria;
            this.Rating = rating;
            this.Audio = audio;
            this.Subtitulos = subtitulos;
        }

        public Juego()
        {
        }
    }
}