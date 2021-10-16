using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class canchaView
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Deporte { get; set; }
        public string N_Espectadores { get; set; }
        public string Medidas { get; set; }
        public int Id_escenario { get; set; }
        public List<encuentro> encuentros { get; set; }

        public string escenarioNombre { get; set; }


    }
}
