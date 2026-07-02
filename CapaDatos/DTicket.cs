using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DTicket
    {
        // INICIO: TECNICO
        private int OrdenEstado(string estado)
        {
            if (estado == "Asignado")
                return 1;

            if (estado == "En Proceso")
                return 2;

            if (estado == "Resuelto")
                return 3;

            return 4;
        }
        private int OrdenPrioridad(string prioridad)
        {
            if (prioridad == "Alta")
                return 1;

            if (prioridad == "Media")
                return 2;

            if (prioridad == "Baja")
                return 3;

            return 4;
        }

        public List<Ticket> ListarPorTecnico(int idTecnico, string prioridad, string estado)
        {
            List<Ticket> LTickets = new List<Ticket>();

            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    LTickets = context.Ticket
                        .Where(t => t.IdAtendidoPor == idTecnico)
                        .ToList();

                    if (prioridad != "Todos")
                    {
                        LTickets = LTickets
                            .Where(t => t.DPrioridad == prioridad)
                            .ToList();
                    }

                    if (estado != "Todos")
                    {
                        LTickets = LTickets
                            .Where(t => t.DEstado == estado)
                            .ToList();
                    }

                    LTickets = LTickets
                        .OrderBy(t => OrdenEstado(t.DEstado))
                        .ThenBy(t => OrdenPrioridad(t.DPrioridad))
                        .ToList();
                }

                return LTickets;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return LTickets;
            }
        }

        // FIN : TECNICO
    }
}
