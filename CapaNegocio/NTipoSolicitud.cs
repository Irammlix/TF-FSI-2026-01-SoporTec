using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NTipoSolicitud
    {
        DTipoSolicitud dTipoSolicitud=new DTipoSolicitud();
        public List<TipoSolicitud> ListarTodo()
        {
            return dTipoSolicitud.ListarTodo();
        }
    }
}
