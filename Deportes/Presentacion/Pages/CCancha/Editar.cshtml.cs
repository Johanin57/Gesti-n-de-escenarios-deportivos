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
    public class EditarModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioCancha _repocancha;
        private readonly IRepositorioEscenario _repoesce;
        // Constructor
        public EditarModel(IRepositorioCancha repocancha, IRepositorioEscenario repoesce)
        {
            this._repocancha = repocancha;
            this._repoesce = repoesce;
        }
        //Propiedad transportable
        [BindProperty]
        public cancha ObjCancha { get; set; }
        public List<Escenario> Esce = new();

        public ActionResult OnGet(int Id)
        {
            ObjCancha = _repocancha.BuscarCancha(Id);
            Esce = _repoesce.ListarEscenario1();
            if (ObjCancha != null)
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
            bool funciono = _repocancha.ActualizarCancha(ObjCancha);
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
