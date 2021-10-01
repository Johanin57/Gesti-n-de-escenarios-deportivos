﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Persistencia
{
    public interface IRepositorioPersona    {
        //Firmar metodos
        bool CrearPersona(persona Persona);
        persona BuscarPersona(int idPersona);
        bool EliminarPersona(int IdPersona);
        bool ActualizarPersona(persona Persona);

        IEnumerable<persona> ListarPersonas();

    }
}
