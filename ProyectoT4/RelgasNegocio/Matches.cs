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
                JuegosMatch uMatch = new JuegosMatch(j.Id, j.Rating, j.Titulo, j.PathFoto);
                String idUsuarioEncontrado;
                int idJuegoEncontrado= j.Id;
                
                //recorro y armo el modelo
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
                        uMatch = new JuegosMatch(j.Id, j.Rating, j.Titulo, j.PathFoto);
                        uMatch.UsuariosMatch.Add(u);

                    }
                    //si solo hay un resultado, entra aca
                    if (uMclJqlI.ElementAt(uMclJqlI.Count-1).IdJuego == idJuegoEncontrado && uMclJqlI.ElementAt(uMclJqlI.Count - 1).IdUsuario == idUsuarioEncontrado)
                    {
                        lista.Add(uMatch);
                    }
               
                }

            }
            //saco los usuarios que tienen propuestas activas con ese juego
            lista = removerYaPropuestos(lista, idJuego, idUsuario);

            return lista;
        }

        private static List<JuegosMatch> removerYaPropuestos(List<JuegosMatch> lista, int idJuegoBuscado, String idUsuarioEnvia)
        {
            sistemaContext db = new sistemaContext();
            int juego;
            int op=0;
            //guardo las posiciones de la lista a borrar
            List<int> temp = new List<int>();
            int contador = 0;
            for (int i = 0; i < lista.Count(); i++)
            {
                juego = lista[i].IdJuego;
                for (int j = 0; j < lista[i].UsuariosMatch.Count() ; j++) 

                {
                    Usuario user = lista[i].UsuariosMatch[j];
                    try
                    {
                        //trae el id de operacion si: el estado, el juego buscado, idRecibe,
                        //idenvia, juegos ofrecidos son iguales a los actuales del match
                        op = db.Operaciones.Where(o => o.JuegoBuscado == idJuegoBuscado && o.UsuarioRecibe.Equals(user.IdUsuario) && o.UsuarioEnvia.Equals(idUsuarioEnvia) && (o.JuegoOfrecido1 == juego || o.JuegoOfrecido2 == juego || o.JuegoOfrecido3 == juego) && o.Estado.Equals("Enviada")).Select(n => n.IdOperacion).First();
                    }
                    catch (Exception)
                    {
                        op = 0;
                    }
                    //si existe una operacion activa, elimina al usuario de los resultados 
                    //para ese juego
                    if (op != 0)
                    {
                        temp.Add(j);
                        contador++;
                    }                    

                }
                //si hay usuarios para borrar
                if (temp.Count() != 0)
                {
                    borrarDelArray(temp, lista[i].UsuariosMatch);
                    temp = new List<int>();
                    contador = 0;
                }
                
                
                if (lista[i].UsuariosMatch.Count() == 0)
                {
                    lista.RemoveAt(i);
                    
                }
                if (lista.Count() == 0)
                {
                    
                    break;
                }

            }
            db.SaveChanges();
          
            
            return lista;
        }

        private static void borrarDelArray(List<int> temp, List<Usuario> usuariosMatch)
        {
            if (temp.Count() == 1)
            {
                usuariosMatch.RemoveAt(temp.ElementAt(0));
            }
            else
            {
                for (int i = temp.Count() - 1; i >= 0; i--)
                {
                    usuariosMatch.RemoveAt(i);
                }
            }
        }
    }
}