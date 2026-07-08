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

            public int IdTecnico { get; set; }
            public int IdSolicitante { get; set; }
            public string TipoSolicitud { get; set; }

        }
        public class TecnicosVistaAdmin
        {
            public int IdTecnico { get; set; }
            public string Usuario { get; set; }
            public string NombreTecnico { get; set; }
            public string SedeTecnico { get; set; }
            public string Especialidad { get; set; }
            public string Correo { get; set; }

            //
        }
        public class ReporteTecnico
        {
            public string NombreTecnico { get; set; }

            public int CantidadResueltos { get; set; }

            public int CantidadPendientes { get; set; }
        }
        public class DetalleTecnico
        {
            public int IdTicket { get; set; }

            public string Titulo { get; set; }

            public string TipoSolicitud { get; set; }

            public string Prioridad { get; set; }

            public string Estado { get; set; }

            public DateTime FechaCreacion { get; set; }
        }
    }
}
