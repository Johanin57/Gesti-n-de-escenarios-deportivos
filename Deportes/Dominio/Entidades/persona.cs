using System;
using System.Collections.Generic;


namespace Dominio
{
    public class persona
    {
        public int Id {get;set;}
        public int N_identificacion {get;set;}
        public string tipo_persona {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}
        public string Genero {get;set;}
        public string Direccion {get;set;}
        public string Celular {get;set;}
        public string Correo {get;set;}
        public string RH {get;set;}
        public string EPS {get;set;}
        public DateTime F_nacimiento {get;set;}
        public string Rol {get;set;}
        //propiedad Navigacional personas torneos
        public List<personas_equipos> personas_equipos {get;set;}
        public List<encuentro> encuentros { get; set;}

    }
}
