using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.Models
{
    public class ContenedorPropuesta
    {
        public List<ModeloPropuesta> Enviadas { get; set; }
        public List<ModeloPropuesta> Recibidas { get; set; }

        public ContenedorPropuesta(List<ModeloPropuesta> enviadas, List<ModeloPropuesta> recibidas)
        {
            this.Enviadas = enviadas;
            this.Recibidas = recibidas;
        }

    }

}