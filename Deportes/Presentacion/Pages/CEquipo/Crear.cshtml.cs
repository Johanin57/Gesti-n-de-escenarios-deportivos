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
    public class CrearModel : PageModel
    {
        //Crear el objeto
        private readonly IRepositorioEquipo _repoequi;
        //Constructor
        public CrearModel(IRepositorioEquipo repoequi)
        {
            this._repoequi = repoequi;
        }
        //propiedad de transporte
        [BindProperty]
        public equipo Equipo { get; set; }
        public ActionResult OnGet()
        {
            return Page();
        }
        public ActionResult OnPost()
        {
            bool funciono = _repoequi.CrearEquipo(Equipo);
            if (funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"] = "El municipio ya exixse";
                return Page();
            }
        }
    }
}
