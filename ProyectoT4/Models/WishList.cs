using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoT4.Models
{
    public class WishList
    {
        [Key, Column(Order = 0)]
        public int IdUsuario { get; set; }
        [Key, Column(Order = 1)]
        public int IdJuego { get; set; }
    }
}