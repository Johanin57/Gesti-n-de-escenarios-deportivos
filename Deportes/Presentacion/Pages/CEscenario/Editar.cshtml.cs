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
    public class EditarModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioEscenario _repoesce;
        private readonly IRepositorioMunicipio _repomun;
        // Constructor
        public EditarModel(IRepositorioEscenario repoesce, IRepositorioMunicipio repomun)
        {
            this._repoesce = repoesce;
            this._repomun = repomun;
        }
        //Propiedad transportable
        [BindProperty]
        public Escenario ObjEscenario { get; set; }
        public List<municipio> Muni = new();

        public ActionResult OnGet(int Id)
        {
            ObjEscenario = _repoesce.BuscarEscenario(Id);
            Muni = _repomun.ListarMunicipios1();
            if (ObjEscenario != null)
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
            bool funciono = _repoesce.ActualizarEscenario(ObjEscenario);
            if (funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"] = "El Escenario ya existe";
                return Page();
            }
        }
        
    }
}
