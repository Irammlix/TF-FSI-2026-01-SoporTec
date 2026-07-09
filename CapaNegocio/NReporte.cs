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

        private static string[] NombresMes =
        {
            "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
            "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
        };

        public class ConteoPabellon
        {
            public string Pabellon { get; set; }
            public int Cantidad { get; set; }
        }

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

        public List<TicketVistaAdmin> DetalleTicketsPabellon(string nombreSede, string nombrePabellon, string estadoFiltro)
        {
            List<TicketVistaAdmin> tickets = nTicket.ListarTodoAdministrador();

            IEnumerable<TicketVistaAdmin> query = tickets
                .Where(t => t.Sede == nombreSede && t.Pabellon == nombrePabellon);

            if (!string.IsNullOrEmpty(estadoFiltro) && estadoFiltro != "Todos")
                query = query.Where(t => t.Estado == estadoFiltro);

            return query.OrderByDescending(t => t.FCreacion).ToList();
        }

        public List<int> ListarAniosConTickets()
        {
            return dReporte.ListarAniosConTickets();
        }

        public int[] ContarIngresadosPorMes(int anio)
        {
            return dReporte.ContarIngresadosPorMes(anio);
        }

        public int[] ContarResueltosPorMes(int anio)
        {
            return dReporte.ContarResueltosPorMes(anio);
        }

        public List<Ticket> ListarPorMes(int anio, int mes)
        {
            return dReporte.ListarPorMes(anio, mes);
        }

        public List<Ticket> ListarResueltosPorMes(int anio, int mes)
        {
            return dReporte.ListarResueltosPorMes(anio, mes);
        }

        // Total anual de ingresados (suma de los 12 meses).
        public int ContarIngresados(int anio)
        {
            return ContarIngresadosPorMes(anio).Sum();
        }

        // Total anual de resueltos (suma de los 12 meses).
        public int ContarResueltos(int anio)
        {
            return ContarResueltosPorMes(anio).Sum();
        }

        // Mes con más ingresos, ej. "Marzo (24)", para el KPI lbl_MesPico.
        public string ObtenerMesPico(int anio)
        {
            int[] ingresados = ContarIngresadosPorMes(anio);

            int mesPico = 0;
            for (int i = 1; i < ingresados.Length; i++)
            {
                if (ingresados[i] > ingresados[mesPico])
                    mesPico = i;
            }

            return NombresMes[mesPico] + " (" + ingresados[mesPico] + ")";
        }

        // Texto del indicador de tendencia (lbl_IndicadorTendencia), según la fórmula que se dejó en el documento.
        public string CalcularIndicadorTendencia(int totalIngresados, int totalResueltos)
        {
            if (totalResueltos > totalIngresados)
                return "El equipo está liquidando el backlog";
            else if (totalIngresados > totalResueltos)
                return "El sistema se está acumulando, revisar capacidad";
            else
                return "El equipo está en equilibrio inestable";
        }

        //REPORTE 1

        public List<Ticket> ListarTicketReporteEstado(string sede)
        {
            if (string.IsNullOrWhiteSpace(sede))
                sede = "Todos";
            return dReporte.ListarTicketReporteEstado(sede);
        }

        //FIN REPORTE 1

        // REPORTE 2
        public List<Ticket> ListarTicketReportePrioridad(string estado, string sede)
        {
            return dReporte.ListarTicketReportePrioridad(estado, sede);
        }
        public int CantidadPrioridades(string prioridad, string estado, string sede)
        {
            return dReporte.CantidadPrioridades(prioridad, estado, sede);
        }

        // REPORTE 3 - RF-18: Rendimiento por tecnico
        public List<ReporteTecnico> ObtenerRendimientoPorTecnico(int? tecnico, string estado)
        {
            return dReporte.ObtenerRendimientoPorTecnico(tecnico, estado);
        }

        public List<DetalleTecnico> ObtenerDetalleTecnico(int? tecnico)
        {
            return dReporte.ObtenerDetalleTecnico(tecnico);
        }
        public List<TecnicoFiltroItem> ObtenerTecnicos()
        {
            return dReporte.ObtenerTecnicos();
        }

        // ===================== REPORTE 5 - RF-20: Distribución por tipo de incidencia =====================

        public class ConteoTipo
        {
            public string TipoSolicitud { get; set; }
            public int Cantidad { get; set; }
        }

        // Agrupa todos los tickets (cualquier estado) por tipo de solicitud.
        // sedeFiltro: "Todas" (o null/vacío) = sin filtro; caso contrario filtra por esa sede.
        public List<ConteoTipo> TicketsPorTipo(string sedeFiltro)
        {
            List<TicketVistaAdmin> tickets = nTicket.ListarTodoAdministrador();

            IEnumerable<TicketVistaAdmin> query = tickets;

            if (!string.IsNullOrEmpty(sedeFiltro) && sedeFiltro != "Todas")
                query = query.Where(t => t.Sede == sedeFiltro);

            return query
                .Where(t => !string.IsNullOrEmpty(t.TipoSolicitud))
                .GroupBy(t => t.TipoSolicitud)
                .Select(g => new ConteoTipo { TipoSolicitud = g.Key, Cantidad = g.Count() })
                .OrderByDescending(c => c.Cantidad)
                .ToList();
        }

        // Detalle de los tickets de un tipo de solicitud concreto (para el drill-down).
        public List<TicketVistaAdmin> DetalleTicketsTipo(string tipoSolicitud, string sedeFiltro)
        {
            List<TicketVistaAdmin> tickets = nTicket.ListarTodoAdministrador();

            IEnumerable<TicketVistaAdmin> query = tickets.Where(t => t.TipoSolicitud == tipoSolicitud);

            if (!string.IsNullOrEmpty(sedeFiltro) && sedeFiltro != "Todas")
                query = query.Where(t => t.Sede == sedeFiltro);

            return query.OrderByDescending(t => t.FCreacion).ToList();
        }

        // % de variación de tickets del tipo dado entre el mes actual y el mes anterior (según FCreacion).
        // Devuelve null cuando no hay tickets el mes anterior con los que comparar (evita división por cero).
        public double? CalcularVariacionMensualTipo(string tipoSolicitud, string sedeFiltro)
        {
            List<TicketVistaAdmin> tickets = nTicket.ListarTodoAdministrador();

            IEnumerable<TicketVistaAdmin> query = tickets.Where(t => t.TipoSolicitud == tipoSolicitud);

            if (!string.IsNullOrEmpty(sedeFiltro) && sedeFiltro != "Todas")
                query = query.Where(t => t.Sede == sedeFiltro);

            DateTime hoy = DateTime.Now;
            DateTime mesAnterior = hoy.AddMonths(-1);

            int cantidadMesActual = query.Count(t => t.FCreacion.Year == hoy.Year && t.FCreacion.Month == hoy.Month);
            int cantidadMesAnterior = query.Count(t => t.FCreacion.Year == mesAnterior.Year && t.FCreacion.Month == mesAnterior.Month);

            if (cantidadMesAnterior == 0)
                return null;

            return Math.Round((cantidadMesActual - cantidadMesAnterior) * 100.0 / cantidadMesAnterior, 1);
        }
    }
}
