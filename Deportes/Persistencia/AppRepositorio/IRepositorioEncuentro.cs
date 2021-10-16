using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Persistencia
{
    public interface IRepositorioEncuentro
    {
        //Firmar metodos
        bool CrearEncuentro(encuentro encuentro);
        encuentro BuscarEncuentros(int idEncuentro);
        bool EliminarEncuentro(int IdEncuentro);
        bool ActualizarEncuentro(encuentro encuentro);

        IEnumerable<encuentro> ListarEncuentros();
        List<encuentro> ListarEncuentros1();
    }
}
