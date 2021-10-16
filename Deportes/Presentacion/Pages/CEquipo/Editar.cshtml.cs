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
    public class EditarModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioEquipos
        private readonly IRepositorioEquipo _repoequi;
        //Constructor de clase
        public EditarModel(IRepositorioEquipo repoequi)
        {
            this._repoequi = repoequi;
        }
        //atributo objeto transportado
        [BindProperty]
        public equipo ObjEquipo { get; set; }
        public ActionResult OnGet(int id)
        {
            ObjEquipo = _repoequi.BuscarEquipo(id);
            if (ObjEquipo != null)
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
            bool funciono = _repoequi.ActualizarEquipo(ObjEquipo);
            if (funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"] = "La Equipo ya existe";
                return Page();
            }
        }
    }
}
