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
    public class IndexModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioTorneo
        private readonly IRepositorioTorneo _repotorneo;
        //atributo objeto transportado
        public IEnumerable<torneo> Torneos { get; set; }
        //Constructor de clase
        public IndexModel(IRepositorioTorneo repotorneo)
        {
            this._repotorneo = repotorneo;
        }
        public void OnGet()
        {
            Torneos = _repotorneo.ListarTorneos();
        }
    }
}
