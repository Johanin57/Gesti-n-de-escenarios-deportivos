using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioEquipo
    {
        //Firmar metodos
        bool CrearEquipo(equipo equipo);
        equipo BuscarEquipo(int idEquipo);

        equipo BuscarEquipoPorNombre(string Nombre_equipo);
        bool EliminarEquipo(int IdEquipo);
        bool ActualizarEquipo(equipo equipo);

        IEnumerable<equipo> ListarEquipo();
        List<equipo> ListarEquipo1();

    }
}
