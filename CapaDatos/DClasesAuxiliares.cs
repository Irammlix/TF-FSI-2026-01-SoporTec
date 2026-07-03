using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DClasesAuxiliares
    {
        public class TicketVistaAdmin
        {
            public int IdTicket { get; set; }
            public string Titulo { get; set; }
            public string Sede { get; set; }
            public string Pabellon { get; set; }
            public string Estado { get; set; }
            public string Prioridad { get; set; }
            public System.DateTime FCreacion { get; set; }
            public Nullable<System.DateTime> FActualizacion { get; set; }

            public string NombreTecnicoAsignado { get; set; }
            // Agrega los demás campos que necesites mostrar...
        }
    }
}
