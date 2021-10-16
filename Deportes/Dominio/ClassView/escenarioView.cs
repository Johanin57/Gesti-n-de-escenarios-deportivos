using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class escenarioView
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Id_municipio { get; set; }
        public List<cancha> canchas { get; set; }
        public string minucipioNombre { get; set; }

        public static implicit operator escenarioView((int Id, string Nombre, string Direccion, string Telefono, int Id_municipio) v)
        {
            throw new NotImplementedException();
        }
    }
}
