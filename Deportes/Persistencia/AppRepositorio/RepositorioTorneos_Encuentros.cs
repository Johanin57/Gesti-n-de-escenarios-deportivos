using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public class RepositorioTorneos_Encuentros:IRepositorioTorneos_Encuentros
    {
        // atributos
        private readonly AppContext _appContext;

        //Metodos
        public RepositorioTorneos_Encuentros(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CREAR Torneos_Encuentros
        bool IRepositorioTorneos_Encuentros.CrearTorneos_Encuentros(torneos_encuentros Torneos_Encuentros)
        {
            bool creado = false;
            try
            {
                _appContext.tb_torneos_encuentros.Add(Torneos_Encuentros);
                _appContext.SaveChanges();
                creado = true;
            }
            catch (System.Exception ex)
            {
                return creado;
            }
            return creado;
        }

        //BUSCAR Torneos_EncuentrosS
        List<torneos_encuentros> IRepositorioTorneos_Encuentros.BuscarEncuentroPorTorneo(int Id_Torneo)
        {
            var list =  _appContext.tb_torneos_encuentros.ToList();

            return list.Where(x => x.Id_torneo.Equals(Id_Torneo)).ToList();
        }

        torneos_encuentros IRepositorioTorneos_Encuentros.BuscarTorneosEncuentrosEquipos(int Id_torneo, int Id_encuentro, int Id_equipo)
        {
            return _appContext.tb_torneos_encuentros.Where(x => x.Id_torneo.Equals(Id_torneo) && x.Id_encuentro.Equals(Id_encuentro) && x.Id_equipo.Equals(Id_equipo)).FirstOrDefault();
        }

        //ELIMINAR Torneos_Encuentros
        bool IRepositorioTorneos_Encuentros.EliminarTorneos_Encuentros(int IdTorneo)
        {
            bool eliminado = false;
            var Torneos_Encuentros = _appContext.tb_torneos_encuentros.Find(IdTorneo);

            if (Torneos_Encuentros != null)
            {
                try
                {
                    _appContext.tb_torneos_encuentros.Remove(Torneos_Encuentros);
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

        //ACTUALIZAR Torneos_Encuentros
        bool IRepositorioTorneos_Encuentros.ActualizarTorneos_Encuentros(torneos_encuentros Torneos_Encuentros)
        {
            bool actualizar = false;
            var torenc = _appContext.tb_torneos_encuentros.Find(Torneos_Encuentros.Id_torneo);
            if (torenc != null)
            {
                try
                {
                    torenc.Id_encuentro = Torneos_Encuentros.Id_encuentro;
                    torenc.Id_equipo = Torneos_Encuentros.Id_equipo;
                    torenc.Id_equipo2 = Torneos_Encuentros.Id_equipo2;
                    torenc.Id_ganador = Torneos_Encuentros.Id_ganador;
                    torenc.Id_torneo = Torneos_Encuentros.Id_torneo;
                    torenc.Id_encuentro = Torneos_Encuentros.Id_encuentro;
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

        //LISTAR Torneos_Encuentros
        IEnumerable<torneos_encuentros> IRepositorioTorneos_Encuentros.ListarTorneos_Encuentros()
        {
            return _appContext.tb_torneos_encuentros;
        }



    }
}
