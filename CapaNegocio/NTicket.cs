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

        public List<Ticket> ListarPorTecnico (int idTecnico, string prioridad, string estado)
        {
            return dTicket.ListarPorTecnico(idTecnico, prioridad, estado);
        }
    }
}
