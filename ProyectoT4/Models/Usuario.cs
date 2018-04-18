using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoT4.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
       // public Jugado Jugados { get; set; }
       // public WishList Wishlist { get; set; }
       // public Libreria Librerias { get; set; }
       // public List<Operacion> operaciones { get; set; }
    }
}