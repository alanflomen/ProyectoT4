using ProyectoT4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.RelgasNegocio
{
	public class ValidacionOperacion
	{
		public bool ValidarOperacion(int Idjuego1, int Idjuego2, string IdUsuario1, string IdUsuario2, string textoOpcional)
		{
			bool OpValida = false;
			//sistemaContext db = new sistemaContext();

			//validar que usuario 1 aún tenga el juego1 en su Wishlist y el Juego2 en su biblioteca
			

			//validar que usuario 2 aún tenga el juego1 en su biblioteca y el Juego2 en su Wishlist
			

			//Validar que en el textoOpcional no se utilicen palabrotas
			if (!textoOpcional.Contains("Puto"))
			{
				OpValida = true;
			}
			
			return OpValida;
		}

	}
}