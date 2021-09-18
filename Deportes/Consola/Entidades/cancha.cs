using System;
using System.Collections.Generic;

namespace Consola.Entidades
{
    public class cancha
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public string Deporte {get;set;}
        public string N_Espectadores {get;set;}
        public string Medidas {get;set;}
        public int Id_escenario {get;set;}
        public List<encuentro> encuentros{get;set;}

    }
}