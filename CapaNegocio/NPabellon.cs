using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NPabellon
    {
        DPabellon dPabellon = new DPabellon();
        public List<Pabellon> ListarTodo()
        {
            return dPabellon.ListarTodo();
        }
    }
}
