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
    public class EliminarModel : PageModel
    {

        //Objeto para utilizar el repositorio
        private readonly IRepositorioPersona _repomuni;

        // Constructor
        public EliminarModel(IRepositorioPersona repomuni)
        {
            this._repomuni = repomuni;
        }
        //Propiedad transportable
        [BindProperty]
        public persona ObjPersona { get; set; }
        public ActionResult OnGet(int N_identificacion)
        {
            ObjPersona = _repomuni.BuscarPersona(N_identificacion);
            if (ObjPersona != null)
            {
                return Page();
            }
            else
            {
                return Page();
            }
        }

        public ActionResult OnPost()
        {
            bool funciono = _repomuni.EliminarPersona(ObjPersona.N_identificacion);
            if (funciono)
            {
                ViewData["funciono"] = "La Persona se elimino satisfactoriamente";
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"] = "La Persona no se pudo eliminar";
                return Page();
            }
        }




    }
}
