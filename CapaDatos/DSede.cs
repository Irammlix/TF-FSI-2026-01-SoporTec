using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DSede
    {
        public List<Sede> ListarTodo()
        {
            List<Sede> sede = new List<Sede>();
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    sede = context.Sede
                        .Where(t => t.DActivo == true)
                        .ToList();
                }
                return sede;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return sede;
            }
        }
    }
}
