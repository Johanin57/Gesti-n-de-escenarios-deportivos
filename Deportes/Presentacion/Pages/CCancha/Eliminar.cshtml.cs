using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CCancha
{
    public class EliminarModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioCancha _repocancha;
        // Constructor
        public EliminarModel(IRepositorioCancha repocancha)
        {
            this._repocancha = repocancha;
        }
        //Propiedad transportable
        [BindProperty]
        public cancha ObjCancha { get; set; }
        public ActionResult OnGet(int Id)
        {
            ObjCancha = _repocancha.BuscarCancha(Id);
            if (ObjCancha != null)
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
            bool funciono = _repocancha.EliminarCancha(ObjCancha.Id);
            if (funciono)
            {
                ViewData["funciono"] = "La Cancha se elimino satisfactoriamente";
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"] = "La Cancha no se pudo eliminar";
                return Page();
            }
        }
    }
}
