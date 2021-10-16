using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioCancha
    {
        //Firmar metodos
        bool CrearCancha(cancha cancha);
        cancha BuscarCancha(int IdCancha);
        bool EliminarCancha(int IdCancha);
        bool ActualizarCancha(cancha cancha);

        IEnumerable<cancha> ListarCancha();
        List<cancha> ListarCancha1();

    }
}
