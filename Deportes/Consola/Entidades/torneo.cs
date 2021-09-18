using System;
using System.Collections.Generic;

namespace Consola.Entidades
{
    public class torneo
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public string Categoria {get;set;}
        public DateTime F_Inicio {get;set;}
        public DateTime F_Fin {get;set;}
        public int N_rondas {get;set;}
        // propiedad navigacional equipos torneos
        public List<equipos_torneos> equipos_torneos  {get;set;} 
        // propiedad navigacional torneos_equipos
        public List<torneos_encuentros> equipos_encuentros {get;set;}
    }
}