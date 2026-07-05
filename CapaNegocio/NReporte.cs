using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using static CapaDatos.DClasesAuxiliares;

namespace CapaNegocio
{
    public class NReporte
    {
        private NTicket nTicket = new NTicket();

        private DReporte dReporte = new DReporte();

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
    }
}
