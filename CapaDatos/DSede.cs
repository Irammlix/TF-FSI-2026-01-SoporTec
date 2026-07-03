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
            List<Sede> sedes = new List<Sede>();
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    sedes = context.Sede
                        .Where(s => s.DActivo == true)
                        .ToList();
                }
                return sedes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return sedes;
            }
        }
    }
}
