using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Persistencia
{
    public interface IRepositorioTorneos_Encuentros
    {
        //Firmar metodos
        bool CrearTorneos_Encuentros(torneos_encuentros torneos_Encuentros);
        List<torneos_encuentros> BuscarEncuentroPorTorneo(int Id_Torneo);
        torneos_encuentros BuscarTorneosEncuentrosEquipos(int Id_torneo, int Id_encuentro, int Id_equipo);
        bool EliminarTorneos_Encuentros(int IdTorneos_Encuentros);
        bool ActualizarTorneos_Encuentros(torneos_encuentros torneos_Encuentros);

        IEnumerable<torneos_encuentros> ListarTorneos_Encuentros();
    }
}
