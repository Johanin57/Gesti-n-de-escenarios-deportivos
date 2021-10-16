using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

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
        bool IRepositorioPersona.CrearPersona(persona Persona)
        {
            bool creado = false;
            bool existe = ValidarNombre(Persona);
            if (!existe)
            {
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
            }
            return creado;
        }

        //BUSCAR PersonaS
        persona IRepositorioPersona.BuscarPersona(int N_identificacion)
        {
            return _appContext.tb_personas.FirstOrDefault(x=> x.N_identificacion == N_identificacion);
        }

        persona IRepositorioPersona.BuscarPersonaId(int Id)
        {
                    return _appContext.tb_personas.FirstOrDefault(x => x.Id == Id);
        }

        //ELIMINAR Persona
        bool IRepositorioPersona.EliminarPersona(int N_identificacion)
        {
            bool eliminado = false;
            var Persona = _appContext.tb_personas.FirstOrDefault(x => x.N_identificacion == N_identificacion);

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
            var per = _appContext.tb_personas.First(x=>x.N_identificacion == Persona.N_identificacion);
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

        List<persona> IRepositorioPersona.ListarPersonas1()
        {
            return _appContext.tb_personas.ToList();
        }

        // Validar la exitencia de un municipio
        bool ValidarNombre(persona personas)
        {
            bool existe = false;
            var mun = _appContext.tb_personas.FirstOrDefault(m => m.N_identificacion == personas.N_identificacion);
            if (mun != null)
            {
                existe = true;
            }
            return existe;
        }

    }
}
