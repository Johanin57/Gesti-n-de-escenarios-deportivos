using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Persistencia
{
    interface IRepositorioMunicipio
    {
        //Firmar metodos
        bool CrearMunicipio(municipio municipio);
        municipio BuscarMunicipio(int idMunicipio);
        bool EliminarMunicipio(int IdMunicipio);
        bool ActualizarMunicipio(municipio municipio);

        IEnumerable<municipio> ListarMunicipios();

    }
}
