using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CEscenario
{
    public class EliminarModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioEscenario _repoesce;

        // Constructor
        public EliminarModel(IRepositorioEscenario repoesce)
        {
            this._repoesce = repoesce;
        }
        //Propiedad transportable
        [BindProperty]
        public Escenario ObjEscenario { get; set; }
        public ActionResult OnGet(int Id)
        {
            ObjEscenario = _repoesce.BuscarEscenario(Id);
            if (ObjEscenario != null)
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
            bool funciono = _repoesce.EliminarEscenario(ObjEscenario.Id);
            if (funciono)
            {
                ViewData["funciono"] = "La Escenario se elimino satisfactoriamente";
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"] = "La Escenario no se pudo eliminar";
                return Page();
            }
        }

    }
}
