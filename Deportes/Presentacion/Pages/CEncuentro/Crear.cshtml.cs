using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CEncuentro
{
    public class CrearModel : PageModel
    {
        //Crear el objeto
        private readonly IRepositorioEncuentro _repoencu;
        private readonly IRepositorioTorneo _repotorneo;
        private readonly IRepositorioCancha _repocancha;
        private readonly IRepositorioPersona _repoperso;
       //Constructor
        public CrearModel(IRepositorioEncuentro repoencu, IRepositorioCancha repocancha, IRepositorioTorneo repotorneo, IRepositorioPersona repoperso)
        {
            this._repoencu = repoencu;
            this._repocancha = repocancha;
            this._repotorneo = repotorneo;
            this._repoperso = repoperso;
            
        }
        //propiedad de transporte
        [BindProperty]
        public encuentro Encuentro { get; set; }
        public List<torneo> torneos = new();
        public List<cancha> canchas = new();
        public List<persona> perso = new();
       
        public ActionResult OnGet()
        {
            canchas = _repocancha.ListarCancha1();
            torneos = _repotorneo.ListarTorneos1();
            perso = _repoperso.ListarPersonas1();
            
            return Page();
        }
        public ActionResult OnPost()
        {
            bool funciono = _repoencu.CrearEncuentro(Encuentro);
            if (funciono)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ViewData["Error"] = "El Encuentro ya existe";
                return Page();
            }
        }

        public static int FilterBySport(int i) { return 1; }

    }
}
