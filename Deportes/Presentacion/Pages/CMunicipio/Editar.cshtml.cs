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
    public class EditModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioMunicipio _repomuni;
        // Constructor
        public EditModel(IRepositorioMunicipio repomuni) 
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
                return RedirectToPage("./Index");
            }
        }

        public ActionResult OnPost()
        {
            bool funciono =_repomuni.ActualizarMunicipio(ObjMunicipio);
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
