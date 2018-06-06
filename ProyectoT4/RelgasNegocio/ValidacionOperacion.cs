using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.RelgasNegocio
{
    public class ValidacionOperacion
    {
        public static bool ValidarOperacion(int juegoBuscado, int juegoOfrecido1, int juegoOfrecido2, int juegoOfrecido3, string usuarioEnvia, string UsuarioRecibe, string textoOpcional)
        {
            bool OpValida = false;
            sistemaContext db = new sistemaContext();

            //validar usuario envia todavia quiere ese juego
            WishList wl1 = db.Wishlist.Find(usuarioEnvia, juegoBuscado);
            //validar usuario envia todavia tiene esos juegos en su libreria
            Libreria lb1 = db.Libreria.Find(usuarioEnvia, juegoOfrecido1);
            Libreria lb1B = db.Libreria.Find(usuarioEnvia, juegoOfrecido2);
            Libreria lb1C = db.Libreria.Find(usuarioEnvia, juegoOfrecido3);

            //validar que usuariorecibe aún tenga el juegoBuscado en su biblioteca y el juegoOfrecido1 en su Wishlist
            WishList wl2 = db.Wishlist.Find(UsuarioRecibe, juegoOfrecido1);
            Libreria lb2 = db.Libreria.Find(UsuarioRecibe, juegoBuscado);

            //si todas las validaciones son positivas
            if (wl1 != null && lb1 != null && wl2 != null && lb2 != null)
            {
                   //pregunto si hay mas juegos y valido que los tenga
                if (juegoOfrecido2 != -1 && lb1B != null)
                {
                    if (juegoOfrecido3 != -1 && lb1C != null)
                    {
                        return true;
                    }
                    else if (juegoOfrecido3 == -1 && lb1C == null)
                    {
                        OpValida = true;
                    }


                } else if (juegoOfrecido2 == -1 && lb1B == null)
                {
                    if (juegoOfrecido3 != -1 && lb1C != null)
                    {
                        OpValida = true;
                    }
                    else if (juegoOfrecido3 == -1 && lb1C == null)
                    {
                        OpValida = true;
                    }
                }
            }

            return OpValida;
        }

    }
}