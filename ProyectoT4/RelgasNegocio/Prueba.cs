using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoT4.RelgasNegocio
{
    public class Prueba
    {
       
        public static void EliminarLista(int idJuego, int idUsuario, string tabla)
        {
            var db = new sistemaContext();
            eliminarJuego(idJuego, idUsuario, db, tabla);
        }
        public static void AgregaLista(int idJuego, int idUsuario, string tabla)
        {
            var db = new sistemaContext();
            agregarJuego(idJuego, idUsuario, db, tabla);
        }

        private static void eliminarJuego(int idJuego, int idUsuario, sistemaContext db, string tipoLista)
        {
            try
            {
                //si son nulos que tire una expepcion con detalles
                Usuario user = buscarUsuario(idUsuario, db);
                Juego juego = BuscarJuego(idJuego, db);

                //si no existe en la lista
                if (buscarEnTabla(idJuego, idUsuario, tipoLista))
                {
                    eliminarDeTabla(idUsuario, idJuego, tipoLista);

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

        public static void agregarJuego(int idJuego, int idUsuario, sistemaContext db, string tipoLista)
        {
            try
            {
                //si son nulos que tire una expepcion con detalles
                Usuario user = buscarUsuario(idUsuario, db);
                Juego juego = BuscarJuego(idJuego, db);

                //si no existe en la lista
                if (!buscarEnTabla(idJuego, idUsuario, tipoLista))
                {
                    InsertarEnTabla(idUsuario, idJuego, tipoLista);
                }
                else
                {
                    throw new Exception("El juego ya esta en la lista!");
                }

            }
            catch (Exception e)
            {       //mostrar en algun lado el error
                Console.WriteLine(e.Message);
            }
        }

        public static bool buscarEnTabla(int idJuego, int idUsuario, string tipoLista)
        {   //busca en la tabla a ver si ese usuario tiene ese juego
            bool esta = false;
            String tabla = "";
            switch (tipoLista)
            {
                case "j":
                    tabla = "Jugados";
                    break;

                case "w":
                    tabla = "DeseosPorUsuario";
                    break;

                case "l":
                    tabla = "Biblioteca";
                    break;

                default:
                    break;
            }
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alan\Desktop\workspaceT4\Proyecto\ProyectoT4\ProyectoT4\App_Data\SistemaContext.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();
            String query = "SELECT idUsuario, idJuego FROM " + tabla;
            query += " WHERE (idUsuario='" + idUsuario + "') AND (idJuego='" + idJuego + "')";
            cmd.CommandText = query;
            //cmd.CommandText = "SELECT idUsuario, idJuego FROM " + tabla + " WHERE (idUsuario='" + idUsuario + "') AND (idJuego='" + idJuego+ "'))";
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                esta = true;
            }
            cn.Close();

            return esta;
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
        private static void InsertarEnTabla(int idUsuario, int idJuego, string tipo)
        {   //hace un insert en la respectiva tabla del idJuego y idUsuario
            String tabla = "";

            switch (tipo)
            {
                case "j":
                    tabla = "Jugados";
                    break;

                case "w":
                    tabla = "DeseosPorUsuario";
                    break;

                case "l":
                    tabla = "Biblioteca";
                    break;

                default:
                    break;
            }
            SqlConnection cn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Alan\Desktop\workspaceT4\Proyecto\ProyectoT4\ProyectoT4\App_Data\SistemaContext.mdf; Integrated Security = True; Connect Timeout = 30");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "Insert into " + tabla + " (IdUsuario, IdJuego) Values('" + idUsuario + "', '" + idJuego + "')";
            cmd.ExecuteNonQuery();
            cmd.Clone();
            cn.Close();

        }
        private static void eliminarDeTabla(int idUsuario, int idJuego, string tipo)
        {   //hace un insert en la respectiva tabla del idJuego y idUsuario
            String tabla = "";

            switch (tipo)
            {
                case "j":
                    tabla = "Jugados";
                    break;

                case "w":
                    tabla = "DeseosPorUsuario";
                    break;

                case "l":
                    tabla = "Biblioteca";
                    break;

                default:
                    break;
            }
            SqlConnection cn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Alan\Desktop\workspaceT4\Proyecto\ProyectoT4\ProyectoT4\App_Data\SistemaContext.mdf; Integrated Security = True; Connect Timeout = 30");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cn.Open();
            cmd.CommandText = "Delete from " + tabla + " where idUsuario='" + idUsuario + "'and idJuego='" + idJuego + "'";
            cmd.ExecuteNonQuery();
            cmd.Clone();
            cn.Close();

        }
    }
}