using System.Collections.Generic;

namespace ProyectoT4.Models
{
    public  class Libreria
    {
        public List<Juego> Juegos { get; set; }

        //constructor
        public Libreria()
        {
            this.Juegos = new List<Juego>();
        }

        public void AgregarJuego(Juego juego)
        {
            this.Juegos.Add(juego);
        }
    }
}