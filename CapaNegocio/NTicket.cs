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
        public List<Ticket> ListarPorTecnico (int idTecnico, string prioridad, string estado)
        {
            return dTicket.ListarPorTecnico(idTecnico, prioridad, estado);
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
    }
}
