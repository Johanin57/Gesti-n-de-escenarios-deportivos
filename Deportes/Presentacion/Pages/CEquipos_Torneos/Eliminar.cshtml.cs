using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CEquipos_Torneos
{
    public class EliminarModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioTorneo
        private readonly IRepositorioTorneo _repotorneo;
        private readonly IRepositorioEquipo _repoequi;
        private readonly IRepositorioEquipos_Torneos _repoequitor;
        //atributo objeto transportado
        public IEnumerable<equipo> Equipos { get; set; }
        public torneo ObjTorneo { get; set; }
        public equipo ObjEquipo { get; set; }
        public List<equipos_torneos> LEquiposTor { get; set; }
        public List<EquipoTorneoView> EquiTorV = new();
        public EquipoTorneoView Fdata { get; set; }
        //Constructor de clase
        public EliminarModel(IRepositorioTorneo repotorneo, IRepositorioEquipo repoequi, IRepositorioEquipos_Torneos repoequitor)
        {
            this._repotorneo = repotorneo;
            this._repoequi = repoequi;
            this._repoequitor = repoequitor;
        }
        public ActionResult OnGet(int Id_Equipo, int Id_Torneo)
        {
            ObjTorneo = _repotorneo.BuscarTorneo(Id_Torneo);
            ObjEquipo = _repoequi.BuscarEquipo(Id_Equipo);
            return Page();
        }

        public ActionResult OnPost(int Id_Equipo, int Id_Torneo)
        {
            var Eq = _repoequi.BuscarEquipo(Id_Equipo);
            var tor = _repotorneo.BuscarTorneo(Id_Torneo);
            if (Eq != null && tor != null)
            {
                var funciono = _repoequitor.EliminarEquipoTorneos(Id_Equipo, Id_Torneo);
                if (funciono)
                {
                    return RedirectToPage("/CTorneo/Vincular");
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

        }
    }
}
