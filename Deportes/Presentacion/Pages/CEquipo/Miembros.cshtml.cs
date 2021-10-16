using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CEquipo
{
    public class MiembrosModel : PageModel
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
        public MiembrosModel(IRepositorioEquipo repoequi, IRepositorioPersona repoperso, IRepositorioPersona_Equipo repopersoequi)
        {
            this._repoequi = repoequi;
            this._repoperso = repoperso;
            this._repopersoequi = repopersoequi;
        }
        public ActionResult OnGet(int Id)
        {
            ObjEquipo = _repoequi.BuscarEquipo(Id);
            if (ObjEquipo != null)
            {
                LMiembros = _repopersoequi.BuscarPersonasPorEquipo(Id);
                if (LMiembros != null)
                {
                    foreach (var m in LMiembros)
                    {
                        persoEquiV.Add(new PersonaEquipoView
                        {
                            Id_equipo = m.Id_equipo,
                            Id_persona = m.Id_persona,
                            NomEquipo = ObjEquipo.Nombre,
                            PPersona = _repoperso.BuscarPersonaId(m.Id_persona),
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


        public ActionResult OnPost(int N_identificacion, int Id)
        {
            var Mie = _repoperso.BuscarPersona(N_identificacion);
            if (Mie != null)
            {
                var funciono = _repopersoequi.BuscarPersonasEquipos(Mie.Id, Id);
                if (funciono == null)
                {
                    personas_equipos PE = new();
                    PE.Id_persona = Mie.Id;
                    PE.Id_equipo = Id;
                    var validar = _repopersoequi.CrearPersonaEquipo(PE);
                    if (validar)
                    {
                        var K = "./Miembros?id=" + Id;
                        return RedirectToPage("Miembros",new{ Id} );
                    }
                    else { ViewData["Error"] = "No fue posible Vincular la persona al equipo "; return Page(); }
                }
                else
                {
                    ViewData["Error"] = "El Persona ya existe en el equipo";
                    var K = "/CEquipo/Miembros?id=" + Id;
                    return RedirectToPage(K);
                }
            }
            else { ViewData["Error"] = "Identificacion no encontrada"; return Page(); }
        }
    }
}
