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
    public class CrearModel : PageModel
    {
        //Crear el objeto
        private readonly IRepositorioTorneo _repotorneo;
        //Constructor
        public CrearModel(IRepositorioTorneo repotorneo)
        {
            this._repotorneo = repotorneo;
        }
        //propiedad de transporte
        [BindProperty]
        public torneo Torneo { get; set; }
        public ActionResult OnGet()
        {
            return Page();
        }
        public ActionResult OnPost()
        {
            bool funciono = _repotorneo.CrearTorneo(Torneo);
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
