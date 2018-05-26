using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoT4.Models
{
    public class sistemaContext : DbContext
    {
        public DbSet<Juego> Juegos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<WishList> Wishlist { get; set; }
        public DbSet<Libreria> Libreria { get; set; }
        public DbSet<Jugados> Jugados { get; set; }
		public DbSet<Operacion> Operaciones { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().Property(s => s.IdUsuario).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }


}