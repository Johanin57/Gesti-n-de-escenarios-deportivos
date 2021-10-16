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
    public class DetalleModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioEscenarios
        private readonly IRepositorioEscenario _repoesce;
        private readonly IRepositorioMunicipio _repomuni;
        //Constructor de clase
        public DetalleModel(IRepositorioEscenario repoesce, IRepositorioMunicipio repomuni)
        {
            this._repoesce = repoesce;
            this._repomuni = repomuni;
        }
        //atributo objeto transportado
        [BindProperty]
        public Escenario ObjEscenario { get; set; }
        public List<municipio> Muni = new();
        public ActionResult OnGet(int id)
        {
            ObjEscenario = _repoesce.BuscarEscenario(id);
            Muni = _repomuni.ListarMunicipios1();
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
            return RedirectToPage("./Index");
        }

    }
}
