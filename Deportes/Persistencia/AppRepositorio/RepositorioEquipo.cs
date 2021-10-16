using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class RepositorioEquipo : IRepositorioEquipo
    {

        // atributos
        private readonly AppContext _appContext;

        //Metodos
        public RepositorioEquipo(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CREAR Equipo
        bool IRepositorioEquipo.CrearEquipo(equipo Equipo)
        {
            bool creado = false;
            try
            {
                _appContext.tb_equipos.Add(Equipo);
                _appContext.SaveChanges();
                creado = true;
            }
            catch (System.Exception)
            {
                return creado;
            }
            return creado;
        }

        //BUSCAR EquipoS
        equipo IRepositorioEquipo.BuscarEquipo(int Id_Equipo)
        {
            return _appContext.tb_equipos.Find(Id_Equipo);
        }

        equipo IRepositorioEquipo.BuscarEquipoPorNombre(string Nombre_equipo)
        {
            return _appContext.tb_equipos.FirstOrDefault(x => x.Nombre == Nombre_equipo);
        }

        //ELIMINAR Equipo
        bool IRepositorioEquipo.EliminarEquipo(int IdEquipo)
        {
            bool eliminado = false;
            var Equipo = _appContext.tb_equipos.Find(IdEquipo);

            if (Equipo != null)
            {
                try
                {
                    _appContext.tb_equipos.Remove(Equipo);
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

        //ACTUALIZAR Equipo
        bool IRepositorioEquipo.ActualizarEquipo(equipo Equipo)
        {
            bool actualizar = false;
            var equ = _appContext.tb_equipos.Find(Equipo.Id);
            if (equ != null)
            {
                try
                {
                    equ.Nombre = Equipo.Nombre;
                    equ.Deporte = Equipo.Deporte;
                    equ.F_creacion = Equipo.F_creacion;
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

        //LISTAR Equipo
        IEnumerable<equipo> IRepositorioEquipo.ListarEquipo()
        {
            return _appContext.tb_equipos;

        }
        List<equipo> IRepositorioEquipo.ListarEquipo1()
        {
            return _appContext.tb_equipos.ToList();
        }



    }
}