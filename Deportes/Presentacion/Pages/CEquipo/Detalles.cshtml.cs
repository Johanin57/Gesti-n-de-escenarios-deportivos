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
    public class DetallesModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioEquipos
        private readonly IRepositorioEquipo _repoequi;
        //Constructor de clase
        public DetallesModel(IRepositorioEquipo repoequi)
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
    }
}
