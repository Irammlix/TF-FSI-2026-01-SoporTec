using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaDatos.DClasesAuxiliares;
namespace CapaNegocio
{
    public class NTicket
    {
        private DTicket dTicket = new DTicket();
        public Ticket ObtenerPorId(int idTicket)
        {
            return dTicket.ObtenerPorId(idTicket);
        }
        public List<Ticket> ListarPorTecnico(int idTecnico, string prioridad, string estado)
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
        public List<TicketVistaAdmin> ListarTodoAdministrador()
        {
            return dTicket.ListarTodoAdministrador();
        }
        public List<TicketVistaAdmin> ListarTicketsEstado(string estado)
        {
            return dTicket.ListarTicketsEstado(estado);
        }
        public List<TicketVistaAdmin> ObtenerTitutloOID(string idOTitulo)
        {
            return dTicket.ObtenerTitutloOID(idOTitulo);
        }
        public string ActualizarTicketTecnico(int idTicket, string estado, string comentario)
        {
            return dTicket.ActualizarTicketTecnico(idTicket, estado, comentario);
        }
        public string AsignarTicket(int idTecnico, int idTicket, int administradorActualId, string prioridad)
        {
            return dTicket.AsignarTicket(idTecnico, idTicket, administradorActualId,prioridad);
        }
    }
}