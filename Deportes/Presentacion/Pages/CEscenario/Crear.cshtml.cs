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
    public class CrearModel : PageModel
    {
        //Crear el objeto
        private readonly IRepositorioMunicipio _repomuni;
        private readonly IRepositorioEscenario _repoesce;
        //Constructor
        public CrearModel(IRepositorioMunicipio repomuni, IRepositorioEscenario repoesce)
        {
            _repomuni = repomuni;
            _repoesce = repoesce;
        }

        //propiedad de transporte
        [BindProperty]
        public Escenario Escenario { get; set; }
        public List<municipio> mun = new();


        public ActionResult OnGet()
        {
            mun = _repomuni.ListarMunicipios1();
            
            return Page();

        }
        public ActionResult OnPost()
        {
            
            bool funciono = _repoesce.CrearEscenario(Escenario);
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