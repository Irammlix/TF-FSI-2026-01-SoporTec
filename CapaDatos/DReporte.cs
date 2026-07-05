using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CapaDatos;

namespace CapaDatos
{
    public class DReporte
    {
        //REPORTE 1
        public List<Ticket> ListarTicketReporteEstado(string sede)
        {
            List<Ticket> tickets = new List<Ticket>();

            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    var consulta = context.Ticket
                        .Include(t => t.Sede)
                        .Include(t => t.Tecnico)
                        .AsQueryable();

                    if (sede != "Todos")
                    {
                        consulta = consulta.Where(t => t.Sede.DNombreSede == sede);
                    }

                    tickets = consulta.ToList();
                }
                return tickets;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return tickets;
            }
        }

        //FIN REPORTE 1
    }
}
