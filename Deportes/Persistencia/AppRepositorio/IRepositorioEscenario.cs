using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioEscenario
    {
        //Firmar metodos
        bool CrearEscenario(Escenario escenario);
        Escenario BuscarEscenario(int IdEscenario);
        bool EliminarEscenario(int IdEscenario);
        bool ActualizarEscenario(Escenario escenario);

        IEnumerable<Escenario> ListarEscenario();

        List<Escenario> ListarEscenario1();
    }
}
