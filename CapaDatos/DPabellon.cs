using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DPabellon
    {
        public List<Pabellon> ListarTodo()
        {
            List<Pabellon> pabellon = new List<Pabellon>();
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    pabellon = context.Pabellon
                        .ToList();
                }
                return pabellon;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return pabellon;
            }
        }
    }
}
