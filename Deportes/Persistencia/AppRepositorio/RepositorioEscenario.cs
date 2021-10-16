using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public class RepositorioEscenario:IRepositorioEscenario
    {
        // atributos
        private readonly AppContext _appContext;

        //Metodos
        public RepositorioEscenario(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CREAR ESCENARIO
        bool IRepositorioEscenario.CrearEscenario(Escenario escenario)   
        {
            bool creado = false;
            try
            {
                _appContext.tb_escenario.Add(escenario);
                _appContext.SaveChanges();
                creado = true;
            }
            catch (System.Exception)
            {
                return creado;
            }
            return creado;
        }

        //BUSCAR ESCENARIOS
        Escenario IRepositorioEscenario.BuscarEscenario(int IdEscenario)
        {
            return _appContext.tb_escenario.Find(IdEscenario);
        }

        //ELIMINAR ESCENARIO
        bool IRepositorioEscenario.EliminarEscenario(int IdEscenario)
        {
            bool eliminado = false;
            var Escenario = _appContext.tb_escenario.Find(IdEscenario);

            if (Escenario != null)
            {
                try
                {
                    _appContext.tb_escenario.Remove(Escenario);
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

        //ACTUALIZAR Escenario
        bool IRepositorioEscenario.ActualizarEscenario(Escenario escenario)
        {
            bool actualizar = false;
            var esc = _appContext.tb_escenario.Find(escenario.Id);
            if (esc != null)
            {
                try
                {
                    esc.Nombre = escenario.Nombre;
                    esc.Direccion = escenario.Direccion;
                    esc.Telefono = escenario.Telefono;
                    esc.Id_municipio = escenario.Id_municipio;
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

        //LISTAR Escenario
        IEnumerable<Escenario> IRepositorioEscenario.ListarEscenario()
        {
            return _appContext.tb_escenario;
        }

        List<Escenario> IRepositorioEscenario.ListarEscenario1()
        {
            return _appContext.tb_escenario.ToList();
        }


    }
}
