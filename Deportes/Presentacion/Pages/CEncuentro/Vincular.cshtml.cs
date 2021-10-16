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
    public class VincularModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioEncuentro
        private readonly IRepositorioEncuentro _repoencu;
        private readonly IRepositorioEquipo _repoequi;
        private readonly IRepositorioTorneo _repotor;
        private readonly IRepositorioTorneos_Encuentros _repotorencu;
        private readonly IRepositorioPersona _repoperso;
        private readonly IRepositorioCancha _repocancha;
        //atributo objeto transportado
        public IEnumerable<equipo> Equipos { get; set; }
        public List<equipo> LEquipos = new();
        public encuentro ObjEncuentro { get; set; }
        public torneo ObjTorneo { get; set; }
        public persona ObjPersona { get; set; }
        public cancha ObjCancha { get; set; }
        public EncuentroView OBjEncuV = new();
        public equipo ObjEquipo { get; set; }
        public torneos_encuentros TE { get; set; }
        public List<torneos_encuentros> LVin { get; set; }
        public List<TorneoEncuentroView> TorEncuV = new();
        public TorneoEncuentroView Fdata { get; set; }
        //Constructor de clase
        public VincularModel(IRepositorioEncuentro repoencu, IRepositorioEquipo repoequi, IRepositorioTorneo repotor, IRepositorioTorneos_Encuentros repotorencu, IRepositorioPersona repoperso, IRepositorioCancha repocancha)
        {
            this._repoencu = repoencu;
            this._repoequi = repoequi;
            this._repotor = repotor;
            this._repotorencu = repotorencu;
            this._repoperso = repoperso;
            this._repocancha = repocancha;
        }
        public ActionResult OnGet(int Id_encuentro, int Id_torneo)
        {
            ObjEncuentro = _repoencu.BuscarEncuentros(Id_encuentro);
            OBjEncuV.Id_torneo = Id_torneo;
            OBjEncuV.TorneoNombre = _repotor.BuscarTorneo(Id_torneo).Nombre +" - "+ _repotor.BuscarTorneo(Id_torneo).Categoria;
            OBjEncuV.CanchaNombre = _repocancha.BuscarCancha(ObjEncuentro.Id_cancha).Nombre + " - " + _repocancha.BuscarCancha(ObjEncuentro.Id_cancha).Deporte;
            OBjEncuV.Fecha = _repoencu.BuscarEncuentros(Id_encuentro).Fecha;
            OBjEncuV.Arbitro = _repoperso.BuscarPersonaId(ObjEncuentro.Id_persona).Nombres + " " + _repoperso.BuscarPersonaId(ObjEncuentro.Id_persona).Apellidos;
            LEquipos = _repoequi.ListarEquipo1();
            if (ObjEncuentro != null)
            {
                LVin = _repotorencu.BuscarEncuentroPorTorneo(Id_torneo);
                if (LVin != null)
                {
                    foreach (var m in LVin)
                    {
                        TorEncuV.Add(new TorneoEncuentroView
                        {
                            ttorneos =_repotor.BuscarTorneo(m.Id_torneo),
                            eequipos = _repoequi.BuscarEquipo(m.Id_equipo),
                            eencuentros =_repoencu.BuscarEncuentros(m.Id_encuentro),
                        }); ;
                    }
                    return Page();
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("./Index");
            }
          
           // return Page();
        }

        
        public ActionResult OnPost(int Id_Torneo, int Id_Encuentro, int Id_Equipo)
        {
            var Eq = _repoequi.BuscarEquipo(Id_Equipo);
            if (Eq != null)
            {
                var funciono = _repotorencu.BuscarTorneosEncuentrosEquipos(Id_Torneo, Id_Encuentro, Id_Equipo);
                if (funciono == null)
                {
                    torneos_encuentros ET = new();
                    ET.Id_torneo = Id_Torneo;
                    ET.Id_encuentro = Id_Encuentro;
                    ET.Id_equipo = Id_Equipo;
                    var validar = _repotorencu.CrearTorneos_Encuentros(ET);
                    if (validar)
                    {
                        return RedirectToPage("Vincular", new { Id_Encuentro, Id_Torneo });
                    }
                    else { ViewData["Error"] = "No fue posible Vincular la Equipo al Encuentro "; 
                        return    RedirectToPage("Vincular", new { Id_Encuentro, Id_Torneo }); 
                    }
                }
                else
                {
                    ViewData["Error"] = "El Equipo ya existe en el Encuentro";

                    return RedirectToPage("Vincular", new { Id_Encuentro, Id_Torneo });
                }
            }
            else { ViewData["Error"] = "Nombre no encontrado"; return Page(); }
        }
    }
}
