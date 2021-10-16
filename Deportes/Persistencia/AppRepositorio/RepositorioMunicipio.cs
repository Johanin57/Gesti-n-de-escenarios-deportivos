using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Persistencia
{
    public class RepositorioMunicipio : IRepositorioMunicipio
    {
        // atributos
        private readonly AppContext _appContext;

        //Metodos
        public RepositorioMunicipio(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CREAR MUNICIPIO
        bool IRepositorioMunicipio.CrearMunicipio(municipio municipio)
        {
            bool creado = false;
            bool existe = ValidarNombre(municipio);
            if(!existe)
            { 
                try
                {
                    _appContext.tb_municipios.Add(municipio);
                    _appContext.SaveChanges();
                    creado = true;
                }
                catch (System.Exception)
                {
                    return creado;
                }
            }
                return creado;
        }

        //BUSCAR MUNICIPIOS
        municipio IRepositorioMunicipio.BuscarMunicipio(int Id_municipio)
        {
            return _appContext.tb_municipios.Find(Id_municipio);
        }

        //ELIMINAR MUNICIPIO
        bool IRepositorioMunicipio.EliminarMunicipio(int IdMunicipio)
        {
            bool eliminado = false;
            var municipio = _appContext.tb_municipios.Find(IdMunicipio);

            if (municipio != null)
            {
                try
                {
                    _appContext.tb_municipios.Remove(municipio);
                    _appContext.SaveChanges();
                    eliminado = true;
                }
                catch (System.Exception)
                {
                    return eliminado;
                }
            }
            return eliminado;
        }

        //ACTUALIZAR MUNICIPIO
        bool IRepositorioMunicipio.ActualizarMunicipio(municipio municipio)
        {
            bool actualizar = false;
            var mun = _appContext.tb_municipios.Find(municipio.Id);
            if (mun != null)
            {
                try
                {
                    mun.Nombre = municipio.Nombre;
                    _appContext.SaveChanges();
                    actualizar = true;
                }
                catch (System.Exception)
                {
                    return actualizar;
                    throw;
                }
            }
            return actualizar;
        }

        //LISTAR MUNICIPIO
        IEnumerable<municipio> IRepositorioMunicipio.ListarMunicipios()
        {
            return _appContext.tb_municipios;
        }

        List<municipio> IRepositorioMunicipio.ListarMunicipios1()
        {
            return _appContext.tb_municipios.ToList();
        }

        // Validar la exitencia de un municipio
        bool ValidarNombre(municipio municipio)
        {
            bool existe = false;
            var mun = _appContext.tb_municipios.FirstOrDefault(m=>m.Nombre == municipio.Nombre);
            if (mun != null)
            {
                existe = true;
            }
            return existe;
        }




    }
}
