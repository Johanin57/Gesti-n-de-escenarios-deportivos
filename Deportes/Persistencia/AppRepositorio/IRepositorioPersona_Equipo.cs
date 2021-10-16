using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioPersona_Equipo
    {
        bool CrearPersonaEquipo(personas_equipos Personas_Equipos);
        personas_equipos BuscarPersonasEquipos(int IdPersona, int IdEquipo);
        List<personas_equipos> BuscarPersonasPorEquipo(int IdEquipo);
        bool EliminarPersonaEquipo(int IdPersona,int IdEquipo);
        bool ActualizarPersonaEquipo(personas_equipos Personas_Equipos);
        IEnumerable<personas_equipos> ListarPersonasEquipos();
        List<personas_equipos> ListarPersonasEquipos1();
    }
}
