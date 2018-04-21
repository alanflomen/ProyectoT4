using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoT4.Models
{
    public class Usuario
    {
        public int Id{ get; set; }
        public List<int> Jugados { get; set; }
        public List<int> Wishlist { get; set; }
        public List<int> Libreria { get; set; }
        // public List<Operacion> operaciones { get; set; }


        public bool buscarEnLista(int idJuego, char tipoLista)
        {    bool esta = false;
            switch (tipoLista)
            {   //busca en cada lista y si lo encuentra pone esta=true
                case 'w':

                    break;

                case 'j':
                    break;

                case 'l':
                    break;

                default:
                    break;
            }

            return esta;
        }
        
    }
}