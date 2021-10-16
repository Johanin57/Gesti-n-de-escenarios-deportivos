using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioTorneo
    {
        //Firmar metodos
        bool CrearTorneo(torneo Torneo);
        torneo BuscarTorneo(int idTorneo);
        bool EliminarTorneo(int IdTorneo);
        bool ActualizarTorneo(torneo Torneo);

        IEnumerable<torneo> ListarTorneos();
        List<torneo> ListarTorneos1();
    }
}
