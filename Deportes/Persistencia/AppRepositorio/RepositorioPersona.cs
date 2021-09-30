using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Persistencia
{
    public class RepositorioPersona:IRepositorioPersona
    {
        // atributos
        private readonly AppContext _appContext;

        //Metodos
        public RepositorioPersona(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CREAR Persona
        bool IRepositorioPersona. CrearPersona(persona Persona)
        {
            bool creado = false;
            try
            {
                _appContext.tb_personas.Add(Persona);
                _appContext.SaveChanges();
                creado = true;
            }
            catch (System.Exception)
            {
                return creado;
            }
            return creado;
        }

        //BUSCAR PersonaS
        persona IRepositorioPersona.BuscarPersona(int Id_Persona)
        {
            return _appContext.tb_personas.Find(Id_Persona);
        }

        //ELIMINAR Persona
        bool IRepositorioPersona.EliminarPersona(int IdPersona)
        {
            bool eliminado = false;
            var Persona = _appContext.tb_personas.Find(IdPersona);

            if (Persona != null)
            {
                try
                {
                    _appContext.tb_personas.Remove(Persona);
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
        bool IRepositorioPersona.ActualizarPersona(persona Persona)
        {
            bool actualizar = false;
            var per = _appContext.tb_personas.Find(Persona.Id);
            if (per != null)
            {
                try
                {
                    per.N_identificacion = Persona.N_identificacion;
                    per.tipo_persona = Persona.tipo_persona;
                    per.Nombres = Persona.Nombres;
                    per.Apellidos = Persona.Apellidos;
                    per.Genero = Persona.Genero;
                    per.Direccion = Persona.Direccion;
                    per.Celular = Persona.Celular;
                    per.Correo = Persona.Correo;
                    per.RH = Persona.RH;
                    per.EPS = Persona.EPS;
                    per.F_nacimiento = Persona.F_nacimiento;
                    per.Rol = Persona.Rol;
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
        IEnumerable<persona> IRepositorioPersona.ListarPersonas()
        {
            return _appContext.tb_personas;
        }



    }
}
