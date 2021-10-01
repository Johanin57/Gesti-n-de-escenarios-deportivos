using System;
using System.Collections.Generic;

namespace Dominio
{
    public class equipo
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public string Deporte {get;set;}
        public DateTime F_creacion {get;set;}
        // propiedad navigacional personas equipos
        public List<personas_equipos> personas_equipos {get;set;}
        // propiedad navigacional equipos torneos
        public List<equipos_torneos> equipos_torneos {get;set;}
        // propiedad navigacional torneos encuentros
        public List<torneos_encuentros> torneos_encuentros { get; set; }
    }
}