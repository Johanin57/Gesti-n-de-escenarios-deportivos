using System;
using System.Collections.Generic;

namespace Dominio
{
    public class personas_equipos
    {
        public int Id_persona {get;set;}
        public int Id_equipo {get;set;}
        public persona personas {get;set;}
        public equipo equipos {get;set;}
    }
}