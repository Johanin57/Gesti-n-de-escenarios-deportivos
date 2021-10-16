using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class RepositorioCancha : IRepositorioCancha
    {// atributos
        private readonly AppContext _appContext;

        //Metodos
        public RepositorioCancha(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CREAR CANCHA
        bool IRepositorioCancha.CrearCancha(cancha Cancha)
        {
            bool creado = false;
            try
            {
                _appContext.tb_canchas.Add(Cancha);
                _appContext.SaveChanges();
                creado = true;
            }
            catch (System.Exception)
            {
                return creado;
            }
            return creado;
        }

        //BUSCAR CANCHA
        cancha IRepositorioCancha.BuscarCancha(int Id_Cancha)
        {
            return _appContext.tb_canchas.Find(Id_Cancha);
        }

        //ELIMINAR Cancha
        bool IRepositorioCancha.EliminarCancha(int IdCancha)
        {
            bool eliminado = false;
            var Cancha = _appContext.tb_canchas.Find(IdCancha);

            if (Cancha != null)
            {
                try
                {
                    _appContext.tb_canchas.Remove(Cancha);
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

        //ACTUALIZAR CANCHA
        bool IRepositorioCancha.ActualizarCancha(cancha Cancha)
        {
            bool actualizar = false;
            var can = _appContext.tb_canchas.Find(Cancha.Id);
            if (can != null)
            {
                try
                {
                    can.Nombre = Cancha.Nombre;
                    can.Deporte = Cancha.Deporte;
                    can.N_Espectadores = Cancha.N_Espectadores;
                    can.Medidas = Cancha.Medidas;
                    can.Id_escenario = Cancha.Id_escenario;
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

        //LISTAR Cancha
        IEnumerable<cancha> IRepositorioCancha.ListarCancha()
        {
            return _appContext.tb_canchas;
        }
        List<cancha> IRepositorioCancha.ListarCancha1()
        {
            return _appContext.tb_canchas.ToList();
        }


    }
}
