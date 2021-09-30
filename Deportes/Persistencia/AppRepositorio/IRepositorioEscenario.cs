using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Persistencia
{
    interface IRepositorioEscenario
    {
        //Firmar metodos
        bool CrearEscenario(escenario escenario);
        escenario BuscarEscenario(int IdEscenario);
        bool EliminarEscenario(int IdEscenario);
        bool ActualizarEscenario(escenario escenario);

        IEnumerable<escenario> ListarEscenario();
    }
}
