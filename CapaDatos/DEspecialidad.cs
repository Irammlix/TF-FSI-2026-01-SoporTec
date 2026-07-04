using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DEspecialidad
    {
        public List<Especialidad> ListarTodo()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    especialidades = context.Especialidad
                        .ToList();
                }
                return especialidades;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return especialidades;
            }
        }
    }
}
