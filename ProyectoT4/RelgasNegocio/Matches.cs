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

        public static List<JuegosMatch> ListaMatch(String idUsuario, int idJuego)
        {
            var db = new sistemaContext();
            List<JuegosMatch> lista = new List<JuegosMatch>();

            //devuelve true si el usuario que busca tiene ese juego en su wishlist
            var quieroEljuego = db.Wishlist.Where(o => o.IdUsuario.Equals(idUsuario) && o.IdJuego == idJuego).Count() > 0;
            if (!quieroEljuego)
                return new List<JuegosMatch>();
            //todos los juegos del usuario
            var miBiblioteca = db.Libreria.Where(o => o.IdUsuario.Equals(idUsuario)).Select(i => i.IdJuego).ToList();
            //quienes lo tengan sin contar al usuario que lo busca
            var usuariosQueLoTienen = db.Libreria.Where(o => o.IdJuego == idJuego && o.IdUsuario != idUsuario).Select(i => i.IdUsuario).ToList();
            //usuariosMatchConLosJuegosQueLesInteresan
            var uMclJqlI = db.Wishlist.Where(o => miBiblioteca.Contains(o.IdJuego) && usuariosQueLoTienen.Contains(o.IdUsuario)).OrderBy(o => o.IdJuego).ToList();


            if (uMclJqlI.Count > 0)
            {
                Usuario u = new Usuario();
                Juego j = db.Juegos.Find(uMclJqlI.ElementAt(0).IdJuego);
                JuegosMatch uMatch = new JuegosMatch(j.Id, j.Rating, j.Titulo);
                String idUsuarioEncontrado;
                int idJuegoEncontrado= j.Id;
                

                foreach (var item in uMclJqlI)
                {
                    if (idJuegoEncontrado == item.IdJuego)
                    {
                        idUsuarioEncontrado = item.IdUsuario;
                        u = db.Usuarios.Find(idUsuarioEncontrado);
                        uMatch.UsuariosMatch.Add(u);
                    }
                    else
                    {
                        lista.Add(uMatch);
                        idUsuarioEncontrado = item.IdUsuario;
                        idJuegoEncontrado = item.IdJuego;
                        j = db.Juegos.Find(idJuegoEncontrado);
                        u = new Usuario();
                        u = db.Usuarios.Find(idUsuarioEncontrado);
                        uMatch = new JuegosMatch(j.Id, j.Rating, j.Titulo);
                        uMatch.UsuariosMatch.Add(u);

                    }
                    //si solo hay un resultado, entra aca
                    if (uMclJqlI.ElementAt(uMclJqlI.Count-1).IdJuego == idJuegoEncontrado && uMclJqlI.ElementAt(uMclJqlI.Count - 1).IdUsuario == idUsuarioEncontrado)
                    {
                        lista.Add(uMatch);
                    }
               
                }

            }

            lista = removerYaPropuestos(lista, idJuego, idUsuario);

            return lista;
        }

        private static List<JuegosMatch> removerYaPropuestos(List<JuegosMatch> lista, int idJuegoBuscado, String idUsuarioEnvia)
        {
            sistemaContext db = new sistemaContext();
            int juego;
            int op=0;
            foreach (var jm in lista)
            {
                juego = jm.IdJuego;
                foreach (var user in jm.UsuariosMatch)
                {
                    try
                    {
                        op = db.Operaciones.Where(o => o.JuegoBuscado == idJuegoBuscado && o.UsuarioRecibe.Equals(user.IdUsuario) && o.UsuarioEnvia.Equals(idUsuarioEnvia) && (o.JuegoOfrecido1 == juego || o.JuegoOfrecido2 == juego || o.JuegoOfrecido3 == juego) && o.Estado.Equals("Enviada")).Select(i => i.IdOperacion).First();
                    }
                    catch (Exception)
                    {

                        op = 0;
                    }
                    //trae el id de operacion si: el estado, el juego buscado, idRecibe, idenvia, juegos ofrecidos son iguales a los actuales del match
                    if (op != 0)
                    {
                        jm.UsuariosMatch.Remove(user);
                    }
                    if (jm.UsuariosMatch.Count() == 0)
                    {
                        lista.Remove(jm);
                        break;
                    }

                }
                if (lista.Count() == 0)
                {
                    
                    break;
                }

            }
            db.SaveChanges();
          
            {

            }
            return lista;
        }
    }
}