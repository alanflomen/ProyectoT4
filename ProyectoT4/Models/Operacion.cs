﻿using System;
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
        //Estado = propuesta enviada, aceptada o rechazada...etc
        public String Estado { get; set; }

        //constructor parametrizado
        public Operacion(String usuarioEnvia, String usuarioRecibe, int juegoBuscado, int juegoOfrecido1, int juegoOfrecido2, int juegoOfrecido3, String estado)
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
        }
        public Operacion()
        {
            this.Fecha = DateTime.Now;
        }
        //devuelve un valor del Id incrementado en 1, respecto al ultimo creado
        private int AsignarId()
        {
            return 0;
        }
    }
}