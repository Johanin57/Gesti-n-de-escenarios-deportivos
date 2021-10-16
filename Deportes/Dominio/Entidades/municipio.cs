using System;
using System.Collections.Generic;

namespace Dominio
{
    public class municipio
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public List<Escenario> escenarios {get;set;}
    }
}