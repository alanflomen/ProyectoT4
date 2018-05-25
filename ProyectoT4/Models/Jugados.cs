using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoT4.Models
{
    public class Jugados
    {

        [Key, Column(Order = 0)]
        public String IdUsuario { get; set; }
        [Key, Column(Order = 1)]
        public int IdJuego { get; set; }


    }




}