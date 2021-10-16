using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CPersonas_Equipos
{
    public class EliminarModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioEquipo
        private readonly IRepositorioEquipo _repoequi;
        private readonly IRepositorioPersona _repoperso;
        private readonly IRepositorioPersona_Equipo _repopersoequi;
        //atributo objeto transportado
        public IEnumerable<persona> Personas { get; set; }
        public equipo ObjEquipo { get; set; }
        public persona ObjPersona { get; set; }
        public List<personas_equipos> LMiembros { get; set; }
        public List<PersonaEquipoView> persoEquiV = new();
        public PersonaEquipoView Fdata { get; set; }
        //Constructor de clase
        public EliminarModel(IRepositorioEquipo repoequi, IRepositorioPersona repoperso, IRepositorioPersona_Equipo repopersoequi)
        {
            this._repoequi = repoequi;
            this._repoperso = repoperso;
            this._repopersoequi = repopersoequi;
        }
        public ActionResult OnGet(int Id_persona, int Id_equipo)
        {
            ObjEquipo = _repoequi.BuscarEquipo(Id_equipo);
            ObjPersona = _repoperso.BuscarPersonaId(Id_persona);
            return Page();
        }

        public ActionResult OnPost(int Id_persona, int Id_equipo)
        {
            var per = _repoperso.BuscarPersonaId(Id_persona);
            var equ = _repoequi.BuscarEquipo(Id_equipo);
            if (per != null && equ != null)
            {
                var funciono = _repopersoequi.EliminarPersonaEquipo(Id_persona, Id_equipo);
                if (funciono)
                {
                    return RedirectToPage("/CEquipo/Miembros");
                }
                else {
                    ViewData["Error"] = "No fue posible eliminar el equipo...";
                    return Page();
                }
            }
            else {
                ViewData["Error"] = "No fue posible eliminar el equipo.";
                return Page();
                }
            
        }
    }
}
