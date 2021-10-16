using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;   

namespace Presentacion.Pages.CCancha
{
    public class DetalleModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioCanchas
        private readonly IRepositorioCancha _repocancha;
        private readonly IRepositorioEscenario _repoesce;
        //Constructor de clase
        public DetalleModel(IRepositorioCancha repocancha, IRepositorioEscenario repoesce)
        {
            this._repocancha = repocancha;
            this._repoesce = repoesce;
        }
        //atributo objeto transportado
        [BindProperty]
        public cancha ObjCancha { get; set; }
        public List<Escenario> Esc = new();
        public ActionResult OnGet(int id)
        {
            ObjCancha = _repocancha.BuscarCancha(id);
            Esc = _repoesce.ListarEscenario1();
            if (ObjCancha != null)
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
