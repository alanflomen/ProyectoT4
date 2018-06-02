using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.AccesoDatos
{
    public class ArmadorSinLogin
    {
        public static JuegosMatch SinLogin(int idJuego)
        {
            JuegosMatch jm;
            var db = new sistemaContext();
            Juego j = db.Juegos.Find(idJuego);
            jm = new JuegosMatch(idJuego, j.Rating, j.Titulo);
            List<String> usuarios = db.Libreria.Where(o => o.IdJuego == idJuego).Select(i => i.IdUsuario).ToList();

            if (usuarios.Count != 0)
            {
                jm.UsuariosMatch = listaUsuarios(usuarios);
            }

            return jm;

        }
        public static List<Usuario> listaUsuarios(List<String> lista)
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            var db = new sistemaContext();
            Usuario u;
            foreach (var us in lista)
            {
                u = db.Usuarios.Find(us);
                listaUsuarios.Add(u);
            }
            return listaUsuarios;
        }
    }
}