﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.Models
{
    public class ResultadoBusqueda
    {
        public Juego JuegoBuscado { get; set; }
        public int IdUsuario { get; set; }
        public List<UsuarioMatch> UsuariosMatch { get; set; }
    }
}