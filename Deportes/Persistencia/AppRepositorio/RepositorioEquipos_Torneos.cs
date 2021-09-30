using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Persistencia
{
    class RepositorioEquipos_Torneos: IRepositorioEquipos_Torneos
    {

        // atributos
        private readonly AppContext _appContext;

        //Metodos
        public RepositorioEquipos_Torneos(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CREAR Equipos_Torneos
        bool IRepositorioEquipos_Torneos.CrearEquipos_Torneos(equipos_torneos Equipos_Torneos)
        {
            bool creado = false;
            try
            {
                _appContext.tb_equipos_torneos.Add(Equipos_Torneos);
                _appContext.SaveChanges();
                creado = true;
            }
            catch (System.Exception)
            {
                return creado;
            }
            return creado;
        }

        //BUSCAR Equipos_TorneosS
        equipos_torneos IRepositorioEquipos_Torneos.BuscarEquipos_Torneos(int Id_Equipos_Torneos)
        {
            return _appContext.tb_equipos_torneos.Find(Id_Equipos_Torneos);
        }

        //ELIMINAR Equipos_Torneos
        bool IRepositorioEquipos_Torneos.EliminarEquipos_Torneos(int IdEquipos_Torneos)
        {
            bool eliminado = false;
            var Equipos_Torneos = _appContext.tb_equipos_torneos.Find(IdEquipos_Torneos);

            if (Equipos_Torneos != null)
            {
                try
                {
                    _appContext.tb_equipos_torneos.Remove(Equipos_Torneos);
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

        //ACTUALIZAR Equipos_Torneos
        bool IRepositorioEquipos_Torneos.ActualizarEquipos_Torneos(equipos_torneos Equipos_Torneos)
        {
            bool actualizar = false;
            var equ_tor = _appContext.tb_equipos_torneos.Find(Equipos_Torneos.Id_torneo);
            if (equ_tor != null)
            {
                try
                {
                    equ_tor.Id_equipo = Equipos_Torneos.Id_equipo;
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

        //LISTAR Equipos_Torneos
        IEnumerable<equipos_torneos> IRepositorioEquipos_Torneos.ListarEquipos_Torneos()
        {
            return _appContext.tb_equipos_torneos;
        }



    }
}
