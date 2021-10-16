using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CPersona
{
    public class CrearModel : PageModel
    {
        //Crear el objeto
        private readonly IRepositorioPersona _repoperso;
        //Constructor
        public CrearModel(IRepositorioPersona repoperso)
        {
            this._repoperso = repoperso;
        }
        //propiedad de transporte
        [BindProperty]
        public persona Persona { get; set; }
        public ActionResult OnGet()
        {
            return Page();
        }
        public ActionResult OnPost()
        {
            bool funciono = _repoperso.CrearPersona(Persona);
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
