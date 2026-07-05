using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using static CapaDatos.DClasesAuxiliares;

namespace CapaNegocio
{
    public class NReporte
    {
        private DReporte dReporte = new DReporte();
        private NTicket nTicket = new NTicket();

        // Resultado de la agrupación de tickets por pabellón (RF-19)
        public class ConteoPabellon
        {
            public string Pabellon { get; set; }
            public int Cantidad { get; set; }
        }

        // ===================== RF-19: Tickets por sede y pabellón =====================

        // Cuenta los tickets de una sede agrupados por pabellón.
        // estadoFiltro: "Todos" (o null/vacío) = sin filtro; caso contrario filtra por ese estado.
        // descendente: true = de mayor a menor cantidad; false = de menor a mayor.
        public List<ConteoPabellon> TicketsPorPabellon(string nombreSede, string estadoFiltro, bool descendente)
        {
            List<TicketVistaAdmin> tickets = nTicket.ListarTodoAdministrador();

            IEnumerable<TicketVistaAdmin> query = tickets.Where(t => t.Sede == nombreSede);

            if (!string.IsNullOrEmpty(estadoFiltro) && estadoFiltro != "Todos")
                query = query.Where(t => t.Estado == estadoFiltro);

            List<ConteoPabellon> conteo = query
                .Where(t => t.Pabellon != null)
                .GroupBy(t => t.Pabellon)
                .Select(g => new ConteoPabellon { Pabellon = g.Key, Cantidad = g.Count() })
                .ToList();

            return descendente
                ? conteo.OrderByDescending(c => c.Cantidad).ToList()
                : conteo.OrderBy(c => c.Cantidad).ToList();
        }

        // Detalle de los tickets de un pabellón concreto dentro de una sede (para el drill-down).
        public List<TicketVistaAdmin> DetalleTicketsPabellon(string nombreSede, string nombrePabellon, string estadoFiltro)
        {
            List<TicketVistaAdmin> tickets = nTicket.ListarTodoAdministrador();

            IEnumerable<TicketVistaAdmin> query = tickets
                .Where(t => t.Sede == nombreSede && t.Pabellon == nombrePabellon);

            if (!string.IsNullOrEmpty(estadoFiltro) && estadoFiltro != "Todos")
                query = query.Where(t => t.Estado == estadoFiltro);

            return query.OrderByDescending(t => t.FCreacion).ToList();
        }

        //REPORTE 1

        public List<Ticket> ListarTicketReporteEstado(string sede)
        {
            if (string.IsNullOrWhiteSpace(sede))
                sede = "Todos";
            return dReporte.ListarTicketReporteEstado(sede);
        }

        //FIN REPORTE 1
    }
}
