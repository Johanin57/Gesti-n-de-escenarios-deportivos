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
    public class DetallesModel : PageModel
    {
        //Objeto para utilizar el repositorio
        private readonly IRepositorioEncuentro _repoencu;
        private readonly IRepositorioTorneo _repoTorneo;
        private readonly IRepositorioCancha _repocancha;
        private readonly IRepositorioPersona _repoperso;
        // Constructor
        public DetallesModel(IRepositorioEncuentro repoencu, IRepositorioTorneo repoTorneo, IRepositorioPersona repoperso, IRepositorioCancha repocancha)
        {
            this._repoencu = repoencu;
            this._repoTorneo = repoTorneo;
            this._repocancha = repocancha;
            this._repoperso = repoperso;
        }
        //Propiedad transportable
        [BindProperty]
        public encuentro ObjEncuentro { get; set; }
        public List<torneo> Torneos = new();
        public List<cancha> Canchas = new();
        public List<persona> Personas = new();

        public ActionResult OnGet(int Id)
        {
            ObjEncuentro = _repoencu.BuscarEncuentros(Id);
            Torneos = _repoTorneo.ListarTorneos1();
            Personas = _repoperso.ListarPersonas1();
            Canchas = _repocancha.ListarCancha1();
            if (ObjEncuentro != null)
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
