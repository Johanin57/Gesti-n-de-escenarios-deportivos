using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CPersona
{
    public class IndexModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioPersonas
        private readonly IRepositorioPersona _repoperso;

        //atributo objeto transportado
        public IEnumerable<persona> Personas { get; set; }
        //Constructor de clase
        public IndexModel(IRepositorioPersona repoperso)
        {
            this._repoperso = repoperso;
        }
        public void OnGet()
        {
            Personas = _repoperso.ListarPersonas();
        }
    }
}
