using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioMunicipio
    {
        //Firmar metodos
        bool CrearMunicipio(municipio municipio);
        municipio BuscarMunicipio(int idMunicipio);
        bool EliminarMunicipio(int IdMunicipio);
        bool ActualizarMunicipio(municipio municipio);

        IEnumerable<municipio> ListarMunicipios();
        List<municipio> ListarMunicipios1();

    }
}
