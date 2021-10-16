using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class EncuentroView
    {
        public int Id { get; set; }
        public int Id_torneo { get; set; }

        public string TorneoNombre { get; set; }
        public int Id_cancha { get; set; }
        public string CanchaNombre { get; set; }
        public DateTime Fecha { get; set; }
        public int Id_persona { get; set; }

        public string Arbitro { get; set; }
        public List<torneos_encuentros> torneos_encuentros { get; set; }


    }
}
