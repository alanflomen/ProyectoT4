using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProyectoT4.Models
{
    public class sistemaContext : DbContext
    {
        public DbSet<Juego> Juegos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}