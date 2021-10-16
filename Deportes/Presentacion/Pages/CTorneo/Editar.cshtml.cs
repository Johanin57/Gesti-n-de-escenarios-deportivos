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
    public class EditarModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioTorneos
        private readonly IRepositorioTorneo _repotorneo;
        //Constructor de clase
        public EditarModel(IRepositorioTorneo repotorneo)
        {
            this._repotorneo = repotorneo;
        }
        //atributo objeto transportado
        [BindProperty]
        public torneo ObjTorneo { get; set; }
        public ActionResult OnGet(int id)
        {
            ObjTorneo = _repotorneo.BuscarTorneo(id);
            if (ObjTorneo != null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }

        public ActionResult OnPost()
        {
            bool funciono = _repotorneo.ActualizarTorneo(ObjTorneo);
            if (funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"] = "La Torneo ya existe";
                return Page();
            }
        }
    }
}
