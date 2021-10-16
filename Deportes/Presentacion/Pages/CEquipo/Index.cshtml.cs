using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CEquipo
{
    public class IndexModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioEquipo
        private readonly IRepositorioEquipo _repoequi;
        //atributo objeto transportado
        public IEnumerable<equipo> Equipos { get; set; }
        //Constructor de clase
        public IndexModel(IRepositorioEquipo repoequi)
        {
            this._repoequi = repoequi;
        }
        public void OnGet()
        {
            Equipos = _repoequi.ListarEquipo();
        }
    }
}
