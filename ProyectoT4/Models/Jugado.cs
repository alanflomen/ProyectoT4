using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.Models
{
    public class Jugado
    {
        public List<Juego> Juegos { get; set; }

        //constructor
        public Jugado()
        {
            this.Juegos = new List<Juego>();
        }

        public void AgregarJuego(Juego juego)
        {
            this.Juegos.Add(juego);
        }
    }




}