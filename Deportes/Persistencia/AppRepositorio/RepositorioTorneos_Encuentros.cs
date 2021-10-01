using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    class RepositorioTorneos_Encuentros:IRepositorioTorneos_Encuentros
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
            catch (System.Exception)
            {
                return creado;
            }
            return creado;
        }

        //BUSCAR Torneos_EncuentrosS
        torneos_encuentros IRepositorioTorneos_Encuentros.BuscarTorneos_Encuentros(int Id_Torneo)
        {
            return _appContext.tb_torneos_encuentros.Find(Id_Torneo);
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
