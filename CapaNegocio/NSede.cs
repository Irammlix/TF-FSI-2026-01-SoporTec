using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CapaNegocio
{
    public class NSede
    {
        private DSede dSede = new DSede();
        public List<Sede> ListarTodo()
        {
            return dSede.ListarTodo();
        }
    }
}