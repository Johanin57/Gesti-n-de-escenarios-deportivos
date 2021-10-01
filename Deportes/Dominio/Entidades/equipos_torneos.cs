using System;
using System.Collections.Generic;

namespace Dominio
{
    public class equipos_torneos
    {
     public int Id_equipo {get;set;}
     public int Id_torneo {get;set;}
     public equipo equipos {get;set;}
     public torneo torneos {get;set;}

    }
}