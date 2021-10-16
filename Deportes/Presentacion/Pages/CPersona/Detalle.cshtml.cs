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
    public class DetalleModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioPersonas
        private readonly IRepositorioPersona _repoperso;
        //Constructor de clase
        public DetalleModel(IRepositorioPersona repoperso)
        {
            this._repoperso = repoperso;
        }
        //atributo objeto transportado
        [BindProperty]
        public persona ObjPersona { get; set; }
        public ActionResult OnGet(int id)
        {
            ObjPersona = _repoperso.BuscarPersona(id);
            if (ObjPersona != null)
            {
                //ViewData["N_identificacion"] = id;
                ViewData["tipPerson"] = ObjPersona.tipo_persona;
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
