using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class municipio
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public List<escenario> escenarios {get;set;}
    }
}