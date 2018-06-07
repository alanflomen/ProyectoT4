using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoT4.RelgasNegocio
{
    public class Prueba
    {
       
        public static void EliminarLista(int idJuego, String idUsuario, string tabla)
        {
            var db = new sistemaContext();
            switch (tabla)
            {
                case "j":
                    Jugados j = db.Jugados.Find(idUsuario, idJuego);
                    if (j != null)
                    {
                        db.Jugados.Remove(j);
                    }
                    break;

                case "w":
                    WishList w = db.Wishlist.Find(idUsuario, idJuego);
                    if (w != null)
                    {
                        db.Wishlist.Remove(w);
                    }
                    break;

                case "l":
                    Libreria l = db.Libreria.Find(idUsuario, idJuego);
                    if (l != null)
                    {
                        db.Libreria.Remove(l);
                    }
                    break;

                default:
                    break;
            }
            db.SaveChanges();
        }
        public static void AgregaLista(int idJuego, String idUsuario, string tabla)
        {
            var db = new sistemaContext();
            
            switch (tabla)
            {
                case "j":
                    if(db.Jugados.Find(idUsuario, idJuego) == null)
                    {
                        db.Jugados.Add(new Jugados() { IdUsuario = idUsuario, IdJuego = idJuego });
                    }
                    
                    break;

                case "w":
                    if (db.Wishlist.Find(idUsuario, idJuego) == null)
                    {
                        db.Wishlist.Add(new WishList() { IdUsuario = idUsuario, IdJuego = idJuego });
                    }
                    break;

                case "l":
                    if (db.Libreria.Find(idUsuario, idJuego) == null)
                    {
                        db.Libreria.Add(new Libreria() { IdUsuario = idUsuario, IdJuego = idJuego });
                    }
                    break;

                default:
                    break;
            }
            db.SaveChanges();
        }
        private static Juego BuscarJuego(int idJuego, sistemaContext db)
        {
            var juego = db.Juegos.Where(j => j.Id == idJuego).FirstOrDefault();
            if (juego == null)
            {
                throw new Exception("El juego no existe!");
            }
            return juego;
        }

        private static Usuario buscarUsuario(int idUsuario, sistemaContext db)
        {
            var user = db.Usuarios.Where(j => j.IdUsuario.Equals(idUsuario)).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("El usuario no existe!");
            }
            return user;
        }
        

        
        public static bool viewBagJugados(String idUsuario, int idJuego)
        {
            var db = new sistemaContext();
            bool esta = false;
            if (db.Jugados.Find(idUsuario, idJuego) == null)
            {
                esta = false;
            }
            else
            {
                esta = true;
            }
            return esta;
        }
        public static bool viewBagLibreria(String idUsuario, int idJuego)
        {
            var db = new sistemaContext();
            bool esta = false;
            if (db.Libreria.Find(idUsuario, idJuego) == null)
            {
                esta = false;
            }
            else
            {
                esta = true;
            }
            return esta;
        }
        public static bool viewBagWishList(String idUsuario, int idJuego)
        {
            var db = new sistemaContext();
            bool esta = false;
            if (db.Wishlist.Find(idUsuario, idJuego) == null)
            {
                esta = false;
            }
            else
            {
                esta = true;
            }
            return esta;
        }
        public static void borrarPropuestas(String idUsuario, int idJuego)
        {
            sistemaContext db = new sistemaContext();
            //busca todas las operaciones que el usuario haya propuesto ese juego
            var enviadas = db.Operaciones.Where(o=> o.JuegoOfrecido1 == idJuego || o.JuegoOfrecido2 == idJuego || o.JuegoOfrecido3 == idJuego && (o.UsuarioEnvia.Equals(idUsuario))).Select(i => i.IdOperacion).ToList();
            var recibidas = db.Operaciones.Where(o => o.JuegoBuscado == idJuego && o.UsuarioRecibe.Equals(idUsuario)).Select(i => i.IdOperacion).ToList();
            eliminarOperaciones(enviadas);
            eliminarOperaciones(recibidas);

        }

        private static void eliminarOperaciones(List<int> oper)
        {
            Operacion opTemp;
            sistemaContext db = new sistemaContext();
            foreach (var o in oper)
            {
                opTemp = db.Operaciones.Find(o);
                opTemp.Estado = "Cancelada";
            }
            db.SaveChanges();
        }

        
       
    }
}