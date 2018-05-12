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
            UsuarioMatch uMatch = new UsuarioMatch();

            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alan\Desktop\workspaceT4\Proyecto\ProyectoT4\ProyectoT4\App_Data\SistemaContext.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();
            //dame todos los usuarios y juegos que tengan el juego que quiere el usuario y quieran uno de su libreria
            String query = "SELECT wi.IDUsuario, wi.IDJuego FROM Wishlists wi WHERE wi.IDJuego in (SELECT bi.IDJuego FROM Librerias bi WHERE IDUsuario = 1) AND wi.IDUsuario in (SELECT bi.IDUsuario FROM Librerias bi WHERE IDJuego = 2) ORDER BY 1,2 asc";
            cmd.CommandText = query;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();


            //recorro el recordset
            if (dr.HasRows)
            {
                //creo el primer usuario
                Usuario u = new Usuario();
                dr.Read();
                u = db.Usuarios.Find(dr.GetInt32(0));
                uMatch.IdUsuario = dr.GetInt32(0);
                //uMatch.rating = u.rating;
                //uMatch.url = u.url;
                uMatch.JuegosMatch.Add(dr.GetInt32(1));
                while (dr.Read())
                {
                    if (uMatch.IdUsuario == dr.GetInt32(0))
                    {
                        uMatch.JuegosMatch.Add(dr.GetInt32(1));
                    }
                    else
                    {
                        lista.Add(uMatch);
                        uMatch = new UsuarioMatch();
                        u = db.Usuarios.Find(dr.GetInt32(0));
                        uMatch.IdUsuario = dr.GetInt32(0);
                        //uMatch.rating = u.rating;
                        //uMatch.url = u.url;
                        uMatch.JuegosMatch.Add(dr.GetInt32(1));
                    }
                }


            }
                       
            return lista;
        }
    }
}