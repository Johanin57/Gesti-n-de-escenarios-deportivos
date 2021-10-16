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
    public class EliminarModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioEquipo _repoEquipo;

        // Constructor
        public EliminarModel(IRepositorioEquipo repoEquipo)
        {
            this._repoEquipo = repoEquipo;
        }
        //Propiedad transportable
        [BindProperty]
        public equipo ObjEquipo { get; set; }
        public ActionResult OnGet(int Id)
        {
            ObjEquipo = _repoEquipo.BuscarEquipo(Id);
            if (ObjEquipo != null)
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
            bool funciono = _repoEquipo.EliminarEquipo(ObjEquipo.Id);
            if (funciono)
            {
                ViewData["funciono"] = "La Equipo se elimino satisfactoriamente";
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"] = "La Equipo no se pudo eliminar";
                return Page();
            }
        }
    }
}
