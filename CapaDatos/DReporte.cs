using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity;
using CapaDatos;

namespace CapaDatos
{
    public class DReporte
    {
        // reporte 1





        //reporte 2 RF - 17
        public List<Ticket> ListarTicketReportePrioridad(string estado, string sede)
        {
            List<Ticket> tickets = new List<Ticket>();

            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    var consulta = context.Ticket
                        .Include(t => t.Sede)
                        .Include(t => t.Tecnico)
                        .Where(t=>t.DEstado=="En Proceso" || t.DEstado=="Asignado")
                        .AsQueryable();

                    if (sede != "Todos")
                    {
                        consulta = consulta.Where(t => t.Sede.DNombreSede == sede);
                    }
                    if (estado != "Todos")
                    {
                        consulta = consulta.Where(t => t.DEstado == estado);
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
        public int CantidadPrioridades(string prioridad, string estado, string sede)
        {
            List<Ticket> tickets = ListarTicketReportePrioridad(estado, sede);

            if(prioridad=="Baja")
            {
                int baja = tickets
                .Where(t => t.DPrioridad == "Baja")
                .Count();
                return baja;

            }
            if (prioridad == "Media")
            {
                int media = tickets
                .Where(t => t.DPrioridad == "Media")
                .Count();
                return media;

            }
            if (prioridad == "Alta")
            {
                int alta = tickets
                .Where(t => t.DPrioridad == "Alta")
                .Count();
                return alta;

            }
            return 0;
        }
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
