using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.Models
{
	public class ModeloPropuesta
	{
		public Operacion oper { get; set; }
		public Usuario usuarioEnvia { get; set; }
		public Usuario usuarioRecibe { get; set; }
		public Juego[] Juegos { get; set; }
        //true = mostrar aceptar
        public Boolean BtnAceptar { get; set; }
        public Boolean BtnRealizarPropuesta { get; set; }
        //true = mostrar Rechazar
        public Boolean BtnRechazar { get; set; }
         //true = mostrar Contra Oferta
        public Boolean BtnContraOferta { get; set; }

        public ModeloPropuesta(int idoperacion)
		{
			Juegos = new Juego[4];
			var db = new sistemaContext();
			this.oper = db.Operaciones.Find(idoperacion);
			this.usuarioEnvia = db.Usuarios.Find(oper.UsuarioEnvia);
			this.usuarioRecibe = db.Usuarios.Find(oper.UsuarioRecibe);
			this.Juegos[0] = db.Juegos.Find(oper.JuegoBuscado);
			this.Juegos[1] = db.Juegos.Find(oper.JuegoOfrecido1);
            this.BtnAceptar = true;
            this.BtnRechazar = true;
            this.BtnContraOferta = true;
			if (oper.JuegoOfrecido2 != -1)
			{
				this.Juegos[2] = db.Juegos.Find(oper.JuegoOfrecido2);

			}
			if (oper.JuegoOfrecido3 != -1)
			{
				this.Juegos[3] = db.Juegos.Find(oper.JuegoOfrecido3);

			}


		}


		public ModeloPropuesta(string IdUsuarioEnvia, string IdUsuarioRecibe, int juegoBuscado, int juegoOfrecido1)
		{
			Juegos = new Juego[4];
			var db = new sistemaContext();
			this.usuarioEnvia = db.Usuarios.Find(IdUsuarioEnvia);
			this.usuarioRecibe = db.Usuarios.Find(IdUsuarioRecibe);
			this.Juegos[0] = db.Juegos.Find(juegoBuscado);
			this.Juegos[1] = db.Juegos.Find(juegoOfrecido1);
            this.BtnRealizarPropuesta = true;
		}
	}
}