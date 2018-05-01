using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.RelgasNegocio
{
    public class Prueba
    {
        public static void ModificarWishList(int idJuego, int idUsuario, char action)
        {
            var db = new sistemaContext();
            var usuario = db.Usuarios.Where(j => j.Id == idUsuario).FirstOrDefault();
            if (action.Equals('a'))
            {
               agregarJuego(idJuego, idUsuario, db, 'w');
            }
            else if (action.Equals('q'))
            {
                eliminarJuego(idJuego, idUsuario, db, 'w');
            }

        }

        private static void eliminarJuego(int idJuego, int idUsuario, sistemaContext db, char tipoLista)
        {
            try
            {
                //si son nulos que tire una expepcion con detalles
                Usuario user = buscarUsuario(idUsuario, db);
                Juego juego = BuscarJuego(idJuego, db);

                //si no existe en la lista
                if (user.buscarEnLista(idJuego, tipoLista))
                {
                    //actualiza esto la bd? o no es necesaria ahora la lista??
                    user.Wishlist.Remove(idJuego);
                }
                else
                {
                    throw new Exception("El juego no esta en la lista!");
                }

            }
            catch (Exception e)
            {       //mostrar en algun lado el error
                Console.WriteLine(e.Message);
            }
        }

        public static void agregarJuego(int idJuego, int idUsuario, sistemaContext db, char tipoLista)
        {
            try
            {
                //si son nulos que tire una expepcion con detalles
                Usuario user = buscarUsuario(idUsuario, db);
                Juego juego = BuscarJuego(idJuego, db);
                
                //si no existe en la lista
                if (!user.buscarEnLista(idJuego, tipoLista))
                {
                    //actualiza esto la bd? o no es necesaria ahora la lista??
                    user.Wishlist.Add(idJuego);
                } else
                {
                    throw new Exception("El juego ya esta en la lista!");
                }

            }
            catch (Exception e)
            {       //mostrar en algun lado el error
                    Console.WriteLine( e.Message);
            }         
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
            var user = db.Usuarios.Where(j => j.Id == idUsuario).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("El usuario no existe!");
            }
            return user;
        }
    }
}