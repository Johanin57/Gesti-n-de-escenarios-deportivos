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
    public class CrearModel : PageModel
    {
        //Crear el objeto
        private readonly IRepositorioCancha _repocancha;
        private readonly IRepositorioEscenario _repoesce;
        //Constructor
        public CrearModel(IRepositorioCancha repocancha, IRepositorioEscenario repoesce)
        {
            this._repocancha = repocancha;
            this._repoesce = repoesce;
        }
        //propiedad de transporte
        [BindProperty]
        public cancha Cancha { get; set; }
        public List<Escenario> Esc = new();
        public ActionResult OnGet()
        {
            Esc = _repoesce.ListarEscenario1();
            return Page();
        }
        public ActionResult OnPost()
        {
            bool funciono = _repocancha.CrearCancha(Cancha);
            if (funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"] = "El Cancha ya existe";
                return Page();
            }
        }

    }
}
