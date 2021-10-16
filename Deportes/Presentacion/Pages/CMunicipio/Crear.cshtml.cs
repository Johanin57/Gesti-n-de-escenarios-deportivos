using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.Cmunicipio
{
    public class CrearModel : PageModel
    {
        //Crear el objeto
        private readonly IRepositorioMunicipio _repomuni;
        //Constructor
        public CrearModel(IRepositorioMunicipio repomuni)
        {
            this._repomuni = repomuni;
        }
        //propiedad de transporte
        [BindProperty]
        public municipio Municipio { get; set; }
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            bool funciono = _repomuni.CrearMunicipio(Municipio);
            if (funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"] = "El municipio ya existe";
                return Page();
            }
        }
    }
}
