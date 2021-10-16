using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class RepositorioEncuentro : IRepositorioEncuentro
    {
        // atributos
        private readonly AppContext _appContext;

        //Metodos
        public RepositorioEncuentro(AppContext appContext)
        {
            _appContext = appContext;
        }

        //CREAR Encuentro
        bool IRepositorioEncuentro.CrearEncuentro(encuentro Encuentro)
        {
            bool creado = false;
            try
            {
                _appContext.tb_encuentros.Add(Encuentro);
                _appContext.SaveChanges();
                creado = true;
            }
            catch (System.Exception)
            {
                return creado;
            }
            return creado;
        }

        //BUSCAR EncuentroS
        encuentro IRepositorioEncuentro.BuscarEncuentros(int Id_Encuentro)
        {
            return _appContext.tb_encuentros.Find(Id_Encuentro);
        }

        //ELIMINAR Encuentro
        bool IRepositorioEncuentro.EliminarEncuentro(int IdEncuentro)
        {
            bool eliminado = false;
            var Encuentro = _appContext.tb_encuentros.Find(IdEncuentro);

            if (Encuentro != null)
            {
                try
                {
                    _appContext.tb_encuentros.Remove(Encuentro);
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

        //ACTUALIZAR Encuentro
        bool IRepositorioEncuentro.ActualizarEncuentro(encuentro Encuentro)
        {
            bool actualizar = false;
            var enc = _appContext.tb_encuentros.Find(Encuentro.Id);
            if (enc != null)
            {
                try
                {
                    enc.Id_torneo = Encuentro.Id_torneo;
                    enc.Id_cancha = Encuentro.Id_cancha;
                    enc.Fecha = Encuentro.Fecha;
                    enc.Id_persona = Encuentro.Id_persona;
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

        //LISTAR Encuentro
        IEnumerable<encuentro> IRepositorioEncuentro.ListarEncuentros()
        {
            return _appContext.tb_encuentros;
        }

        List<encuentro> IRepositorioEncuentro.ListarEncuentros1()
        {
            return _appContext.tb_encuentros.ToList();
        }

    }
}
