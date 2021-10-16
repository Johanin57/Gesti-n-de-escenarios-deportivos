using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public class RepositorioTorneo:IRepositorioTorneo
    {
        // atributos
        private readonly AppContext _appContext;

        //Metodos
        public RepositorioTorneo(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CREAR TORNEO
        bool IRepositorioTorneo.CrearTorneo(torneo Torneo)
        {
            bool creado = false;
            try
            {
                _appContext.tb_torneos.Add(Torneo);
                _appContext.SaveChanges();
                creado = true;
            }
            catch (System.Exception)
            {
                return creado;
            }
            return creado;
        }

        //BUSCAR TORNEO
        torneo IRepositorioTorneo.BuscarTorneo(int Id_Torneo)
        {
            return _appContext.tb_torneos.Find(Id_Torneo);
        }

        //ELIMINAR TORNEO
        bool IRepositorioTorneo.EliminarTorneo(int IdTorneo)
        {
            bool eliminado = false;
            var Torneo = _appContext.tb_torneos.Find(IdTorneo);

            if (Torneo != null)
            {
                try
                {
                    _appContext.tb_torneos.Remove(Torneo);
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

        //ACTUALIZAR TORNEO
        bool IRepositorioTorneo.ActualizarTorneo(torneo Torneo)
        {
            bool actualizar = false;
            var tor = _appContext.tb_torneos.Find(Torneo.Id);
            if (tor != null)
            {
                try
                {
                    tor.Nombre = Torneo.Nombre;
                    tor.Categoria = Torneo.Categoria;
                    tor.F_Inicio = Torneo.F_Inicio;
                    tor.F_Fin = Torneo.F_Fin;
                    tor.N_rondas = Torneo.N_rondas;
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

        //LISTAR TORNEO
        IEnumerable<torneo> IRepositorioTorneo.ListarTorneos()
        {
            return _appContext.tb_torneos;
        }

        List<torneo> IRepositorioTorneo.ListarTorneos1()
        {
            return _appContext.tb_torneos.ToList();
        }

    }
}
