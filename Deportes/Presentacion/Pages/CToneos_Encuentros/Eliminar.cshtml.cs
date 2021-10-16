using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CToneos_Encuentros
{
    public class EliminarModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioEncuentro
        private readonly IRepositorioEncuentro _repoencu;
        private readonly IRepositorioEquipo _repoequi;
        private readonly IRepositorioTorneo _repotor;
        private readonly IRepositorioTorneos_Encuentros _repotorencu;
        //atributo objeto transportado
        public IEnumerable<equipo> Equipos { get; set; }
        public encuentro ObjEncuentro { get; set; }
        public equipo ObjEquipo { get; set; }
        public torneo ObjTorneo { get; set; }
        public List<torneos_encuentros> LTor { get; set; }
        public List<TorneoEncuentroView> EquiTorV = new();
        public TorneoEncuentroView Fdata { get; set; }
        //Constructor de clase
        public EliminarModel(IRepositorioEncuentro repoencu, IRepositorioEquipo repoequi, IRepositorioTorneos_Encuentros repotorencu, IRepositorioTorneo repotor)
        {
            this._repoencu = repoencu;
            this._repoequi = repoequi;
            this._repotorencu = repotorencu;
            this._repotor = repotor;
        }
        public ActionResult OnGet(int Id_Torneo, int Id_Encuentro, int Id_Equipo)
        {
            ObjTorneo = _repotor.BuscarTorneo(Id_Torneo);
            ObjEncuentro = _repoencu.BuscarEncuentros(Id_Encuentro);
            ObjEquipo = _repoequi.BuscarEquipo(Id_Equipo);
            return Page();
        }
        /*
        public ActionResult OnPost(int Id_Torneo, int Id_Encuentro, int Id_Equipo)
        {
            var Tor  = _repotor.BuscarTorneo(Id_Torneo);
            var Encu = _repoencu.BuscarEncuentros(Id_Encuentro);
            var Eq = _repoequi.BuscarEquipo(Id_Equipo);
            if (Tor != null %% Encu != null && Eq != null )
            {
                var funciono = _repotorencu.EliminarTorneos_Encuentros(Id_Torneo, Id_Encuentro, Id_Equipo);
                if (funciono)
                {
                    return RedirectToPage("/CEncuentro/Vincular");
                }
                else
                {
                    ViewData["Error"] = "No fue posible eliminar el Equipo...";
                    return Page();
                }
            }
            else
            {
                ViewData["Error"] = "No fue posible eliminar el Equipo.";
                return Page();
            }

        }*/
    }
}
