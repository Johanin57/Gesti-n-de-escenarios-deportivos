using System;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace Consola
{
    class Program
    {
        public static IRepositorioPersona _repoper = new Persistencia.RepositorioPersona(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            //Console.WriteLine(IRepositorioPersona.ListarPersonas())
            //crearpersona();
            //buscarpersona(1016003616);
            //actualizarpersonas();
            //eliminarpersonas();
            //listarpersona();
        }

        private static bool crearpersona() 
        {
            var per = new persona
            {
                N_identificacion = 1234,
                tipo_persona = "Natural",
                Nombres = "Carlos",
                Apellidos = "Garcia",
                Genero = "Masculino",
                Direccion = "DIR 3",
                Celular = "1232342",
                Correo = "cg@mail.com",
                RH = "a-",
                EPS = "Sanitas",
                F_nacimiento = Convert.ToDateTime ("12 - 03 - 1999"),
                Rol = "Patronizador"
            };
            bool funciono = _repoper.CrearPersona(per);
            Console.WriteLine(funciono);

            if (funciono)
            {
                Console.WriteLine("Registro Creado Satisfactoriamente");
            } 
            else
            {
                Console.WriteLine("No fue posible crear el objeto");
            }
                return funciono;
        }
        private static bool buscarpersona(int N_identificacion) 
        {
            persona person = _repoper.BuscarPersona(N_identificacion);
            if (person!= null)
            {
                Console.WriteLine(person.Nombres +" "+ person.Apellidos +" "+ person.N_identificacion);
                return true;
            }
            else
            {
                Console.WriteLine("No se encuentra el objeto");
                return false;
            }
        }
        private static void actualizarpersona() { }
        private static void eliminarpersona() { }
        private static void listarpersona()
        {
            IEnumerable<persona> Personas = _repoper.ListarPersonas();
            foreach (var P in Personas)
            {
                Console.WriteLine("ID " + P.Id + "Documento" + P.N_identificacion);
            }


        }
    }
}
