using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.Models
{
    public class ModeloPropuesta
    {
        public Operacion oper { get; set; }
        public Usuario usuario1 { get; set; }
        public Usuario usuario2 { get; set; }
        public Juego[] Juegos { get; set; }

        public ModeloPropuesta(int idoperacion)
        {
            Juegos = new Juego[4];
            var db = new sistemaContext();
            this.oper = db.Operaciones.Find(idoperacion);
            this.usuario1 = db.Usuarios.Find(oper.UsuarioEnvia);
            this.usuario2 = db.Usuarios.Find(oper.UsuarioRecibe);
            this.Juegos[0] = db.Juegos.Find(oper.JuegoBuscado);
            this.Juegos[1] = db.Juegos.Find(oper.JuegoOfrecido1);
            if (oper.JuegoOfrecido2 != -1)
            {
                this.Juegos[2] = db.Juegos.Find(oper.JuegoOfrecido2);

            }
            if (oper.JuegoOfrecido3 != -1)
            {
                this.Juegos[3] = db.Juegos.Find(oper.JuegoOfrecido3);

            }


        }
    }
}