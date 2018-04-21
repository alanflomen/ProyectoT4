using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoT4.Models
{
    public class Usuario
    {
        public int Id{ get; set; }
        public List<int> Jugados { get; set; }
        public List<int> Wishlist { get; set; }
        public List<int> Libreria { get; set; }
        // public List<Operacion> operaciones { get; set; }
    }
}