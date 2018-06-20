using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoT4.Models
{
    public class Operacion
    {
		[Key]
        public int IdOperacion { get; set; }
        public String UsuarioEnvia { get; set; }
        public String UsuarioRecibe { get; set; }
        public DateTime Fecha { get; set; }
        public int JuegoBuscado { get; set; }
        public int JuegoOfrecido1 { get; set; }
        public int JuegoOfrecido2 { get; set; }
        public int JuegoOfrecido3 { get; set; }
        //Estados posibles: = enviada, aceptada, cancelada, contraOfertaEnvia, contraOfertaRecibe
        public String Estado { get; set; }
		//Mensajes entre los usuarios separados por ""
		public string Mensajes { get; set; }

		//constructor parametrizado
		public Operacion(String usuarioEnvia, String usuarioRecibe, int juegoBuscado, int juegoOfrecido1, int juegoOfrecido2, int juegoOfrecido3, String estado, string textoOpcional)
        {
            this.UsuarioEnvia = usuarioEnvia;
            this.UsuarioRecibe = usuarioRecibe;
            this.Fecha = DateTime.Now;
            this.JuegoBuscado = juegoBuscado;
            this.JuegoOfrecido1 = juegoOfrecido1;
            this.JuegoOfrecido2 = juegoOfrecido2;
            this.JuegoOfrecido3 = juegoOfrecido3;       
            this.Estado = estado;
			//para mi esto no va, lo autogenera la bd
			//this.IdOperacion = AsignarId();
			this.Mensajes = textoOpcional;
        }
        public Operacion()
        {
            this.Fecha = DateTime.Now;
        }
        
    }
}