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
        public String IdUsuario{ get; set; }
        public String mail { get; set; }
        public String  UrlFoto { get; set; }
        public String Ubicacion { get; set; }
        public float rating { get; set; }
        // public List<Operacion> operaciones { get; set; }

        public Usuario() { }

        public Usuario(String idUsuario, String mail, String url, String ubic)
        {
            this.IdUsuario = idUsuario;
            this.mail = mail;
            this.UrlFoto = url;
            this.Ubicacion = ubic;
            this.rating = 0;
        }
    }
}