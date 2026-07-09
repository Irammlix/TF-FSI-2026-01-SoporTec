using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NEspecialidad
    {
        private DEspecialidad dEspecialidad = new DEspecialidad();

        public List<Especialidad> ListarTodo()
        {
            return dEspecialidad.ListarTodo();
        }
    }
}
