using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public class RepositorioPersona_Equipo :IRepositorioPersona_Equipo
    {
        // atributos
        private readonly AppContext _appContext;

        //Metodos
        public RepositorioPersona_Equipo (AppContext appContext)
        {
            _appContext = appContext;
        }

        //CREAR Persona
        bool IRepositorioPersona_Equipo.CrearPersonaEquipo(personas_equipos Persona_Equipo)
        {
            bool creado = false;
            bool existe = ValidarNombre(Persona_Equipo);
            if (!existe)
            {
                try
                {
                    _appContext.tb_personas_equipos.Add(Persona_Equipo);
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

        //BUSCAR PersonaS
        personas_equipos IRepositorioPersona_Equipo.BuscarPersonasEquipos(int Id_persona, int Id_equipo)
        {           
            return _appContext.tb_personas_equipos.Where(x=> x.Id_persona.Equals(Id_persona) && x.Id_equipo.Equals(Id_equipo)).FirstOrDefault();
        }

        List<personas_equipos> IRepositorioPersona_Equipo.BuscarPersonasPorEquipo(int Id_equipo)
        {
            return _appContext.tb_personas_equipos.Where(x=> x.Id_equipo.Equals(Id_equipo)).ToList();
        }

        //ELIMINAR Persona
        bool IRepositorioPersona_Equipo.EliminarPersonaEquipo(int IdPersona, int IdEquipo)
        {
            bool eliminado = false;
            var PersonaEqui = _appContext.tb_personas_equipos.Where(x => x.Id_persona.Equals(IdPersona) && x.Id_equipo.Equals(IdEquipo)).FirstOrDefault();
            if (PersonaEqui != null)
            {
                try
                {
                    _appContext.tb_personas_equipos.Remove(PersonaEqui);
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

        //ACTUALIZAR Persona
        bool IRepositorioPersona_Equipo.ActualizarPersonaEquipo(personas_equipos Personas_Equipos)
        {
            bool actualizar = false;
            var per = _appContext.tb_personas_equipos.Where(x => x.Id_persona.Equals(Personas_Equipos.Id_persona) && x.Id_equipo.Equals(Personas_Equipos.Id_equipo)).FirstOrDefault();
            if (per != null)
            {
                try
                {
                    per.Id_persona = Personas_Equipos.Id_persona;
                    per.Id_equipo = Personas_Equipos.Id_equipo;
                    per.personas = Personas_Equipos.personas;
                    per.equipos = Personas_Equipos.equipos;
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

        //LISTAR Persona
        IEnumerable<personas_equipos> IRepositorioPersona_Equipo.ListarPersonasEquipos()
        {
            return _appContext.tb_personas_equipos;
        }

        List<personas_equipos> IRepositorioPersona_Equipo.ListarPersonasEquipos1()
        {
            return _appContext.tb_personas_equipos.ToList();
        }

        // Validar la exitencia de un municipio
        bool ValidarNombre(personas_equipos personas_equipos)
        {
            bool existe = false;
            var mun = _appContext.tb_personas_equipos.Where(x => x.Id_persona.Equals(personas_equipos.Id_persona) && x.Id_equipo.Equals(personas_equipos.Id_equipo)).FirstOrDefault();
            if (mun != null)
            {
                existe = true;
            }
            return existe;
        }


    }
}
