using System;
using System.Collections.Generic;

namespace Consola.Entidades
{
    public class escenario
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public string Direccion {get;set;}
        public string Telefono {get;set;}
        public int Id_municipio {get;set;}
        public List<cancha> canchas {get;set;}
    }
}