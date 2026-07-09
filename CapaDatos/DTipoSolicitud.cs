using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DTipoSolicitud
    {
        public List<TipoSolicitud> ListarTodo()
        {
            List<TipoSolicitud> tipoSolicitud = new List<TipoSolicitud>();
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    tipoSolicitud = context.TipoSolicitud
                        .ToList();
                }
                return tipoSolicitud;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return tipoSolicitud;
            }
        }
    }
}
