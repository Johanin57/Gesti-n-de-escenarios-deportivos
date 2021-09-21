using System;
using Dominio;
using Dominio.Entidades;
using Persistencia;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        //public static IRepositorioMunicipio _repomunicipio = new Persistencia.RepositorioMunicipio(new Persistencia.AppContext())
        {
            Console.WriteLine("Hello World!");
            municipio m = new municipio();
            m.Nombre = "Bogota";

           



        }
    }
}
