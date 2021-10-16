using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CEncuentro
{
    public class EliminarModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioEncuentro _repoEncuentro;

        // Constructor
        public EliminarModel(IRepositorioEncuentro repoEncuentro)
        {
            this._repoEncuentro = repoEncuentro;
        }
        //Propiedad transportable
        [BindProperty]
        public encuentro ObjEncuentro { get; set; }
        public ActionResult OnGet(int Id)
        {
            ObjEncuentro = _repoEncuentro.BuscarEncuentros(Id);
            if (ObjEncuentro != null)
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
            bool funciono = _repoEncuentro.EliminarEncuentro(ObjEncuentro.Id);
            if (funciono)
            {
                ViewData["funciono"] = "La Encuentro se elimino satisfactoriamente";
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"] = "La Encuentro no se pudo eliminar";
                return Page();
            }
        }
    }
}
