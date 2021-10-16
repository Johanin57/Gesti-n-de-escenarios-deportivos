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
    public class IndexModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioCancha
        private readonly IRepositorioCancha _repoesce;
        private readonly IRepositorioMunicipio _repocancha;

        //atributo objeto transportado
        public List<cancha> Canchas = new();
        public List<canchaView> canchaView = new();
        //Constructor de clase
        public IndexModel(IRepositorioCancha repoesce, IRepositorioMunicipio repocancha)
        {
            this._repoesce = repoesce;
            this._repocancha = repocancha;
        }
        public void OnGet()
        {
            List<municipio> Muni = _repocancha.ListarMunicipios1();
            Canchas = _repoesce.ListarCancha1();
            foreach (var item in Canchas)
            {
                canchaView.Add(new canchaView
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Deporte = item.Deporte,
                    N_Espectadores = item.N_Espectadores,
                    Medidas =item.Medidas,
                    Id_escenario = item.Id_escenario,
                    escenarioNombre = Muni.Where(x => x.Id.Equals(item.Id_escenario)).Select(n => n.Nombre).FirstOrDefault(),
                });
            }


        }
    }
}
