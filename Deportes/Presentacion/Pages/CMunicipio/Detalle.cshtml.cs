using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CMunicipio
{
    public class DetalleModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioMunicipio _repomuni;

        // Constructor
        public DetalleModel(IRepositorioMunicipio repomuni) 
        { 
            this._repomuni = repomuni; }

        //Propiedad transportable
        [BindProperty]
        public municipio ObjMunicipio { get; set; }

        public ActionResult OnGet(int Id)
        {
            municipio mun = _repomuni.BuscarMunicipio(Id);
            return Page();

        }
    }
}
