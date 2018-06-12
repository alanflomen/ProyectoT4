using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoT4.Models
{
    public class modeloTodosLosJuegos
    {
       public List<JuegosMatch> lista;
    
    public modeloTodosLosJuegos (List<JuegosMatch> lista)
    {
            this.lista = lista;
    }
}}
