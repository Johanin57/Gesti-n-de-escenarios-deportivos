using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace Presentacion.Pages.CEscenario
{
    public class IndexModel : PageModel
    {
        //Crear objeto para poder utilizar IRepositorioEscenario
        private readonly IRepositorioEscenario _repoesce;
        private readonly IRepositorioMunicipio _repomuni;

        //atributo objeto transportado
        public List<Escenario> Escenarios = new();
        public List<escenarioView> esceView = new();
        //Constructor de clase
        public IndexModel(IRepositorioEscenario repoesce, IRepositorioMunicipio repomuni)
        {
            this._repoesce = repoesce;
            this._repomuni = repomuni;
        }
        public void OnGet()
        {
            List<municipio> Muni = _repomuni.ListarMunicipios1();
            Escenarios = _repoesce.ListarEscenario1();
            foreach (var item in Escenarios)
            {
                esceView.Add(new escenarioView
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Direccion = item.Direccion,
                    Telefono = item.Telefono,
                    Id_municipio = item.Id_municipio,
                    minucipioNombre = Muni.Where(x => x.Id.Equals(item.Id_municipio)).Select(n => n.Nombre).FirstOrDefault(),
                });
            }


        }
    }
}
