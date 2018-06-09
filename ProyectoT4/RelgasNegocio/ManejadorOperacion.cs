using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.RelgasNegocio
{
    public class ManejadorOperacion
    {
        public static void canceladorDePropuestas(String idUsuario, int idJuego)
        {
            sistemaContext db = new sistemaContext();
            //busca todas las operaciones que el usuario haya propuesto ese juego
            var enviadas = db.Operaciones.Where(o => o.JuegoOfrecido1 == idJuego || o.JuegoOfrecido2 == idJuego || o.JuegoOfrecido3 == idJuego && (o.UsuarioEnvia.Equals(idUsuario))).Select(i => i.IdOperacion).ToList();
            var recibidas = db.Operaciones.Where(o => o.JuegoBuscado == idJuego && o.UsuarioRecibe.Equals(idUsuario)).Select(i => i.IdOperacion).ToList();
            cancelarOperaciones(enviadas);
            cancelarOperaciones(recibidas);

        }

        private static void cancelarOperaciones(List<int> oper)
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
        public static Boolean agregarJuegoPropuesto(int idOperacion, int IdJuego, int posicion)
        {
            bool ok = false;
            Operacion ope;
            sistemaContext db = new sistemaContext();
            //busco que exista la operacion            
            ope = db.Operaciones.Find(idOperacion);            
            ///si existe, busco en que lugar poner el juego
            if (ope != null) 
            {
                switch (posicion)
                {
                    case 2:
                        ope.JuegoOfrecido2 = IdJuego;
                        break;
                    case 3:
                        ope.JuegoOfrecido3 = IdJuego;
                        break;
                    default:
                        break;
                }
                ok = true;
                db.SaveChanges();
            }

            return ok;
        }
    }
}