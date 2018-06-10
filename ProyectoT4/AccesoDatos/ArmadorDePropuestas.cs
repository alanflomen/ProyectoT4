using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.AccesoDatos
{
    public class ArmadorDePropuestas
    {
        public static List<ModeloPropuesta> generarEnviadas(String idUsuario)
        {
            List<ModeloPropuesta> lista = new List<ModeloPropuesta>();
            var db = new sistemaContext();
            ModeloPropuesta modelo;
            var propuestas = db.Operaciones.Where(o => o.UsuarioEnvia.Equals(idUsuario) && !o.Estado.Equals("Cancelada")).Select(i => i.IdOperacion).ToList();
            foreach (var oper in propuestas)
            {
                modelo = new ModeloPropuesta(oper);
                lista.Add(modelo);
            }

            return lista;
        }
        public static List<ModeloPropuesta> generarRecibidas(String idUsuario)
        {
            List<ModeloPropuesta> lista = new List<ModeloPropuesta>();
            var db = new sistemaContext();
            ModeloPropuesta modelo;
            var propuestas = db.Operaciones.Where(o => o.UsuarioRecibe.Equals(idUsuario)).Select(i => i.IdOperacion).ToList();
            foreach (var oper in propuestas)
            {
                modelo = new ModeloPropuesta(oper);
                lista.Add(modelo);
            }
            return lista;
        }
    }
}