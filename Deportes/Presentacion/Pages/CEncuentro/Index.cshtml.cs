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
    public class IndexModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioCancha
        private readonly IRepositorioEncuentro _repoencu;
        private readonly IRepositorioCancha _repocancha;
        private readonly IRepositorioTorneo _repotorneo;
        private readonly IRepositorioPersona _repoperso;

        //atributo objeto transportado
        public List<persona> Arbitro = new();
        public List<cancha> Canchas = new();
        public List<torneo> Torneos = new();
        public List<encuentro> Encu = new();
        public List<EncuentroView> EncuView = new();
        //Constructor de clase
        public IndexModel(IRepositorioCancha repocancha, IRepositorioEncuentro repoencu, IRepositorioPersona repoperso, IRepositorioTorneo repotorneo)
        {
            this._repoencu = repoencu;
            this._repocancha = repocancha;
            this._repoperso = repoperso;
            this._repotorneo = repotorneo;
        }
        public void OnGet()
        {
            Encu = _repoencu.ListarEncuentros1();
            Canchas = _repocancha.ListarCancha1();
            Torneos = _repotorneo.ListarTorneos1();
            Arbitro = _repoperso.ListarPersonas1();

            foreach (var item in Encu)
            {
                EncuView.Add(new EncuentroView
                {
                    Id = item.Id,
                    Id_torneo = item.Id_torneo,
                    TorneoNombre = Torneos.Where(x => x.Id.Equals(item.Id_torneo)).Select(n => n.Nombre+" - "+n.Categoria).FirstOrDefault(),
                    CanchaNombre = Canchas.Where(x => x.Id.Equals(item.Id_cancha)).Select(n => n.Nombre+" - "+n.Deporte).FirstOrDefault(),
                    Fecha = item.Fecha,
                    Arbitro = Arbitro.Where(x => x.Id.Equals(item.Id_persona)).Select(n => n.Nombres + " " + n.Apellidos).FirstOrDefault(),
                });
            }


        }


    }
}
