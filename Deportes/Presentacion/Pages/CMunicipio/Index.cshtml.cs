using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistencia;
using Dominio;

namespace Presentacion.Pages.Cmunicipio
{
    public class IndexModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioMunicipio
        private readonly IRepositorioMunicipio _repomuni;
        //atributo objeto transportado
        public IEnumerable<municipio> Municipios { get; set;}
        //Constructor de clase
        public IndexModel(IRepositorioMunicipio repomuni)
        {
            this._repomuni = repomuni;
        }
        public void OnGet()
        {
            Municipios = _repomuni.ListarMunicipios(); 
        }
    }
}
