using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CMunicipio
{
    public class EliminarModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioMunicipio _repomuni;

        // Constructor
        public EliminarModel(IRepositorioMunicipio repomuni)
        {
            this._repomuni = repomuni;
        }
        //Propiedad transportable
        [BindProperty]
        public municipio ObjMunicipio { get; set; }
        public ActionResult OnGet(int Id)
        {
            ObjMunicipio = _repomuni.BuscarMunicipio(Id);
            if (ObjMunicipio != null)
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
            bool funciono = _repomuni.EliminarMunicipio(ObjMunicipio.Id);
            if (funciono)
            {
                ViewData["funciono"] = "El municipio se elimino satisfactoriamente";
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"] = "El municipio no se pudo eliminar";
                return Page();
            }
        }




    }
}
