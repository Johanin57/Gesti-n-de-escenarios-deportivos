using System;
using System.Collections.Generic;

namespace Dominio
{
    public class encuentro
    {
        public int Id {get;set;}
        public int Id_torneo {get;set;}
        public int Id_cancha {get;set;}
        public DateTime Fecha {get;set;} 
        public int Id_persona {get;set;}
        public List<torneos_encuentros> torneos_encuentros {get;set;}
        
    }
}