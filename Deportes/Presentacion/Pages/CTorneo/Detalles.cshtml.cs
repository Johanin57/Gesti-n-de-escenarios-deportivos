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
    public class DetallesModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioTorneos
        private readonly IRepositorioTorneo _repotorneo;
        //Constructor de clase
        public DetallesModel(IRepositorioTorneo repotorneo)
        {
            this._repotorneo = repotorneo;
        }
        //atributo objeto transportado
        [BindProperty]
        public torneo ObjTorneo { get; set; }
        public ActionResult OnGet(int id)
        {
            ObjTorneo = _repotorneo.BuscarTorneo(id);
            if (ObjTorneo != null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }

       
    }
}
