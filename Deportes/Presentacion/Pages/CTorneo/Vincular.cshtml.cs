using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CTorneo
{
    public class VincularModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioTorneo
        private readonly IRepositorioTorneo _repotorneo;
        private readonly IRepositorioEquipo _repoequi;
        private readonly IRepositorioEquipos_Torneos _repoequitor;
        //atributo objeto transportado
        public IEnumerable<equipo> Equipos { get; set; }
        public torneo ObjTorneo { get; set; }
        public equipo ObjEquipo { get; set; }
        public List<equipos_torneos> LEquiposVin { get; set; }
        public List<EquipoTorneoView> EquiTorV = new();
        public EquipoTorneoView Fdata { get; set; }
        //Constructor de clase
        public VincularModel(IRepositorioTorneo repotorneo, IRepositorioEquipo repoequi, IRepositorioEquipos_Torneos repoequitor)
        {
            this._repotorneo = repotorneo;
            this._repoequi = repoequi;
            this._repoequitor = repoequitor;
        }
        public ActionResult OnGet(int Id)
        {
            ObjTorneo = _repotorneo.BuscarTorneo(Id);
            if (ObjTorneo != null)
            {
                LEquiposVin = _repoequitor.BuscarEquiposPorTorneo(Id);
                if (LEquiposVin != null)
                {
                    foreach (var m in LEquiposVin)
                    {
                        EquiTorV.Add(new EquipoTorneoView
                        {
                            Id_Torneo = m.Id_torneo,
                            Id_Equipo = m.Id_equipo,
                            NomTorneo = ObjTorneo.Nombre,
                            EEquipo = _repoequi.BuscarEquipo(m.Id_equipo),
                        });
                    }
                    return Page();
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("./Index");
            }

            //return Page();
        }


        public ActionResult OnPost(string Nombre_equipo, int Id_torneo)
        {
            var Eq = _repoequi.BuscarEquipoPorNombre(Nombre_equipo);
            if (Eq != null)
            {
                var funciono = _repoequitor.BuscarEquiposTorneos(Eq.Id, Id_torneo);
                if (funciono == null)
                {
                    equipos_torneos ET = new();
                    ET.Id_equipo = Eq.Id;
                    ET.Id_torneo = Id_torneo;
                    var validar = _repoequitor.CrearEquipos_Torneos(ET);
                    if (validar)
                    {                        
                        return RedirectToPage("Vincular", new { Id_torneo });
                    }
                    else { ViewData["Error"] = "No fue posible Vincular la Equipo al Torneo "; return Page(); }
                }
                else
                {
                    ViewData["Error"] = "El Equipo ya existe en el Torneo";

                    return RedirectToPage("Vincular", new { Id_torneo });
                }
            }
            else { ViewData["Error"] = "Nombre no encontrado"; return Page(); }
        }
    }
}
