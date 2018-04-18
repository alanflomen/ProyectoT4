using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.Models
{
    public class Operacion
    {
        public int IdOperacion { get; set; }
        public Usuario[] Usuarios { get; set; }
        public DateTime Fecha { get; set; }
        public Juego[] Juegos { get; set; }
        //Tipo = Canje o Venta
        public String Tipo { get; set; }

        //constructor parametrizado
        Operacion(Usuario jugador1, Usuario jugador2, Juego juego1, Juego juego2, String tipo)
        {
            this.Usuarios = new Usuario[] { jugador1, jugador2 };
            this.Fecha = DateTime.Now;
            this.Juegos = new Juego[] { juego1, juego2 };
            this.Tipo = tipo;
            this.IdOperacion = asignarId();
        }
        //devuelve un valor del Id incrementado en 1, respecto al ultimo creado
        private int asignarId()
        {
            return 0;
        }
    }
}