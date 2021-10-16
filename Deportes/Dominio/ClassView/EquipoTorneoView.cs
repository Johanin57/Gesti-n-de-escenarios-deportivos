using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EquipoTorneoView
    {

        public int Id_Equipo { get; set; }
        public string NomEquipo { get; set; }
        public int Id_Torneo { get; set; }
        public string NomTorneo { get; set; }
        public equipo EEquipo { get; set; }
        public int TorneoID { get; set; }
    }
}
