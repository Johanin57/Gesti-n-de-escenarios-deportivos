using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioEquipos_Torneos
    {
        //Firmar metodos
        bool CrearEquipos_Torneos(equipos_torneos equipos_torneos);
        equipos_torneos BuscarEquipos_Torneos(int idEquipos_Torneos);
        bool EliminarEquipos_Torneos(int IdEquipos_Torneos);
        bool ActualizarEquipos_Torneos(equipos_torneos equipos_Torneos);

        IEnumerable<equipos_torneos> ListarEquipos_Torneos();
    }
}
