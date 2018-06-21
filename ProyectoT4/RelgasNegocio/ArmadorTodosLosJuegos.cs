using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.RelgasNegocio
{
    public class ArmadorTodosLosJuegos
    {
        public static List<JuegosMatch> armadorJuegos(String idUsuario)
        {
            var db = new sistemaContext();
            List<JuegosMatch> atlj=null;
            List<Libreria> librerias = db.Libreria.Where(o => !o.IdUsuario.Equals(idUsuario)).OrderBy(i=> i.IdJuego).ToList();
            if (librerias.Count() != 0)
            {
                atlj = hacerLista(librerias);
            }
            return atlj;
        }

        private static List<JuegosMatch> hacerLista(List<Libreria> librerias)
        {
            var db = new sistemaContext();
            JuegosMatch jm;
            List<JuegosMatch> lista = new List<JuegosMatch>();
            Juego juego = db.Juegos.Find(librerias.ElementAt(0).IdJuego);
            jm = new JuegosMatch(juego.Id, juego.Rating, juego.Titulo, juego.PathFoto);
            Usuario user;
            foreach (var item in librerias)
            {
                if (item.IdJuego==juego.Id)
                {
                    user = db.Usuarios.Find(item.IdUsuario);
                    jm.UsuariosMatch.Add(user);
                } else
                {
                    lista.Add(jm);
                    juego = db.Juegos.Find(item.IdJuego);
                    jm = new JuegosMatch(juego.Id, juego.Rating, juego.Titulo, juego.PathFoto);
                    user = db.Usuarios.Find(item.IdUsuario);
                    jm.UsuariosMatch.Add(user);
                }
            }
            lista.Add(jm);
            return lista;
        }
        public static List<JuegosMatch> armadorJuegosSinLogin()
        {
            var db = new sistemaContext();
            List<JuegosMatch> atlj = null;
            List<Libreria> librerias = db.Libreria.ToList();
            if (librerias.Count() != 0)
            {
                atlj = hacerLista(librerias);
            }
            return atlj;
        }
    }
}