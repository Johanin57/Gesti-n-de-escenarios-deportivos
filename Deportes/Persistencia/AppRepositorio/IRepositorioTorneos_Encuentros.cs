using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;


namespace Persistencia
{
    interface IRepositorioTorneos_Encuentros
    {
        //Firmar metodos
        bool CrearTorneos_Encuentros(torneos_encuentros torneos_Encuentros);
        torneos_encuentros BuscarTorneos_Encuentros(int idTorneos_Encuentros);
        bool EliminarTorneos_Encuentros(int IdTorneos_Encuentros);
        bool ActualizarTorneos_Encuentros(torneos_encuentros torneos_Encuentros);

        IEnumerable<torneos_encuentros> ListarTorneos_Encuentros();
    }
}
