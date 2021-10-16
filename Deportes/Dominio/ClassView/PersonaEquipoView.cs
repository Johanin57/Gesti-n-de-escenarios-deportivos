using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PersonaEquipoView
    {
        public int Id_persona { get; set; }
        public string NomPersona { get; set; }
        public int Id_equipo { get; set; }
        public string NomEquipo { get; set; }
        public int MiembroID  { get; set; }
        public persona PPersona { get; set; }
        public int EquipoID { get; set; }

    }
}
