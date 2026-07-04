using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NTicket
    {
        private DTicket dTicket = new DTicket();

        public Ticket ObtenerPorId(int idTicket)
        {
            return dTicket.ObtenerPorId(idTicket);
        }
        public List<Ticket> ListarPorTecnico (int idTecnico, string prioridad, string estado)
        {
            return dTicket.ListarPorTecnico(idTecnico, prioridad, estado);
        }

        public List<Ticket> ListarPorSolicitante(int idSolicitante, string estado)
        {
            return dTicket.ListarPorSolicitante(idSolicitante, estado);
        }

        public string Registrar(Ticket ticket)
        {
            ticket.DEstado = "Sin Asignar";
            ticket.FCreacion = DateTime.Now;
            ticket.FActualizacion = null;
            ticket.DPrioridad = null;
            return dTicket.Registrar(ticket);
           

        }

        public string CancelarTicket(int idTicket, string estadoActual)
        {
            if (estadoActual != "Sin Asignar")
            {
                return "Solo se pueden cancelar tickets que aún no han sido asignados.";
            }
            return dTicket.CancelarTicket(idTicket);
        }
        public string ActualizarTicketTecnico(int idTicket, string estado, string comentario)
        {
            return dTicket.ActualizarTicketTecnico(idTicket, estado, comentario);
        }
    }
}
