using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CTorneo
{
    public class EliminarModel : PageModel
    {

        //Objeto para utilizar el repositorio
        private readonly IRepositorioTorneo _repotorneo;

        // Constructor
        public EliminarModel(IRepositorioTorneo repotorneo)
        {
            this._repotorneo = repotorneo;
        }
        //Propiedad transportable
        [BindProperty]
        public torneo ObjTorneo { get; set; }
        public ActionResult OnGet(int Id)
        {
            ObjTorneo = _repotorneo.BuscarTorneo(Id);
            if (ObjTorneo != null)
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
            bool funciono = _repotorneo.EliminarTorneo(ObjTorneo.Id);
            if (funciono)
            {
                ViewData["funciono"] = "La Torneo se elimino satisfactoriamente";
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"] = "La Torneo no se pudo eliminar";
                return Page();
            }
        }


    }
}
