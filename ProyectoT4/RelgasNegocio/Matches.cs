using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoT4.RelgasNegocio
{
    public class Matches
    {

        public static List<UsuarioMatch> ListaMatch(int idUsuario, int idJuego)
        {
            var db = new sistemaContext();
            List<UsuarioMatch> lista = new List<UsuarioMatch>();

            //var miBiblioteca = (from libreria in db.Libreria
            //             join wl in db.Wishlist on libreria.IdJuego equals wl.IdJuego
            //             where wl.IdJuego == idJuego && libreria.IdUsuario == idUsuario
            //             select new { idjuego = libreria.IdJuego }).Select(o => o.idjuego).ToList();
            var quieroEljuego = db.Wishlist.Where(o => o.IdUsuario == idUsuario && o.IdJuego == idJuego).Count() > 0;
            if (!quieroEljuego)
                return new List<UsuarioMatch>();

            var miBiblioteca = db.Libreria.Where(o => o.IdUsuario == idUsuario).Select(i => i.IdJuego).ToList();
            var usuariosQueLoTienen = db.Libreria.Where(o => o.IdJuego == idJuego).Select(i => i.IdUsuario).ToList();
            var wlist = db.Wishlist.ToList();
            //usuariosMatchConLosJuegosQueLesInteresan
            var uMclJqlI = db.Wishlist.Where(o => miBiblioteca.Contains(o.IdJuego) && usuariosQueLoTienen.Contains(o.IdUsuario)).ToList();


            if (uMclJqlI.Count > 0)
            {
                Usuario u = new Usuario();
                UsuarioMatch uMatch = new UsuarioMatch();
                int idUsuarioEncontrado;
                int idJuegoEncontrado=0;
                idUsuarioEncontrado = uMclJqlI.ElementAt(0).IdUsuario;
                u = db.Usuarios.Find(idUsuarioEncontrado);
                uMatch.IdUsuario = idUsuarioEncontrado;

                foreach (var item in uMclJqlI)
                {
                    if (idUsuarioEncontrado == item.IdUsuario)
                    {
                        idJuegoEncontrado = item.IdJuego;                        
                        //uMatch.rating = u.rating;
                        //uMatch.url = u.url;
                        uMatch.JuegosMatch.Add(idJuegoEncontrado);
                    }
                    else
                    {
                        lista.Add(uMatch);
                        idUsuarioEncontrado = item.IdUsuario;
                        idJuegoEncontrado = item.IdJuego;
                        u = new Usuario();
                        u = db.Usuarios.Find(idUsuarioEncontrado);
                        uMatch = new UsuarioMatch();                        
                        uMatch.IdUsuario = idUsuarioEncontrado;
                        //uMatch.rating = u.rating;
                        //uMatch.url = u.url;
                        uMatch.JuegosMatch.Add(idJuegoEncontrado);

                    }
                    //si solo hay un resultado, entra aca
                    if (uMclJqlI.ElementAt(uMclJqlI.Count-1).IdJuego == idJuegoEncontrado && uMclJqlI.ElementAt(uMclJqlI.Count - 1).IdUsuario == idUsuarioEncontrado)
                    {
                        lista.Add(uMatch);
                    }
               
                }

            }


            return lista;
        }
    }
}