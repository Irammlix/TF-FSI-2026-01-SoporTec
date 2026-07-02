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
        public string ActualizarTicketTecnico(int idTicket, string estado, string comentario)
        {
            return dTicket.ActualizarTicketTecnico(idTicket, estado, comentario);
        }
    }
}
