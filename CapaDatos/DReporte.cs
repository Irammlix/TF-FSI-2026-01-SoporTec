using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity;
using CapaDatos;
using static CapaDatos.DClasesAuxiliares;

namespace CapaDatos
{
    public class DReporte
    {
        public List<int> ListarAniosConTickets()
        {
            List<int> anios = new List<int>();
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    anios = context.Ticket
                        .Select(t => t.FCreacion.Year)
                        .Distinct()
                        .OrderByDescending(a => a)
                        .ToList();
                }
                return anios;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return anios;
            }
        }

        public int[] ContarIngresadosPorMes(int anio)
        {
            int[] conteo = new int[12];
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    var grupos = context.Ticket
                        .Where(t => t.FCreacion.Year == anio)
                        .GroupBy(t => t.FCreacion.Month)
                        .Select(g => new { Mes = g.Key, Cantidad = g.Count() })
                        .ToList();

                    foreach (var g in grupos)
                        conteo[g.Mes - 1] = g.Cantidad;
                }
                return conteo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return conteo;
            }
        }

        public int[] ContarResueltosPorMes(int anio)
        {
            int[] conteo = new int[12];
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    var grupos = context.Ticket
                        .Where(t => t.DEstado == "Resuelto" && t.FActualizacion.HasValue && t.FActualizacion.Value.Year == anio)
                        .GroupBy(t => t.FActualizacion.Value.Month)
                        .Select(g => new { Mes = g.Key, Cantidad = g.Count() })
                        .ToList();

                    foreach (var g in grupos)
                        conteo[g.Mes - 1] = g.Cantidad;
                }
                return conteo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return conteo;
            }
        }

        public List<Ticket> ListarPorMes(int anio, int mes)
        {
            List<Ticket> tickets = new List<Ticket>();
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    tickets = context.Ticket
                        .Where(t => t.FCreacion.Year == anio && t.FCreacion.Month == mes)
                        .OrderBy(t => t.IdTicket)
                        .ToList();
                }
                return tickets;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return tickets;
            }
        }

        public List<Ticket> ListarResueltosPorMes(int anio, int mes)
        {
            List<Ticket> tickets = new List<Ticket>();
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    tickets = context.Ticket
                        .Where(t => t.DEstado == "Resuelto" && t.FActualizacion.HasValue
                            && t.FActualizacion.Value.Year == anio && t.FActualizacion.Value.Month == mes)
                        .OrderBy(t => t.IdTicket)
                        .ToList();
                }
                return tickets;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return tickets;
            }
        }

        //reporte 2 RF - 17
        public List<Ticket> ListarTicketReportePrioridad(string estado, string sede)
        {
            List<Ticket> tickets = new List<Ticket>();
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    var consulta = context.Ticket
                        .Include(t => t.Sede)
                        .Include(t => t.Tecnico)
                        .Where(t=>t.DEstado=="En Proceso" || t.DEstado=="Asignado")
                        .AsQueryable();

                    if (sede != "Todos")
                    {
                        consulta = consulta.Where(t => t.Sede.DNombreSede == sede);
                    }
                    if (estado != "Todos")
                    {
                        consulta = consulta.Where(t => t.DEstado == estado);
                    }

                    tickets = consulta.ToList();
                }
                return tickets;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return tickets;
            }

        }
        public int CantidadPrioridades(string prioridad, string estado, string sede)
        {
            List<Ticket> tickets = ListarTicketReportePrioridad(estado, sede);

            if(prioridad=="Baja")
            {
                int baja = tickets
                .Where(t => t.DPrioridad == "Baja")
                .Count();
                return baja;

            }
            if (prioridad == "Media")
            {
                int media = tickets
                .Where(t => t.DPrioridad == "Media")
                .Count();
                return media;

            }
            if (prioridad == "Alta")
            {
                int alta = tickets
                .Where(t => t.DPrioridad == "Alta")
                .Count();
                return alta;

            }
            return 0;
        }
        //REPORTE 1
        public List<Ticket> ListarTicketReporteEstado(string sede)
        {
            List<Ticket> tickets = new List<Ticket>();

            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    var consulta = context.Ticket
                        .Include(t => t.Sede)
                        .Include(t => t.Tecnico)
                        .AsQueryable();

                    if (sede != "Todos")
                    {
                        consulta = consulta.Where(t => t.Sede.DNombreSede == sede);
                    }

                    tickets = consulta.ToList();
                }
                return tickets;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return tickets;
            }
        }
        //FIN REPORTE 1

        // REPORTE 3 - RF-18: Rendimiento por tecnico
        public List<ReporteTecnico> ObtenerRendimientoPorTecnico(int? idTecnico, string estado)
        {
            using (var context = new dbSistema_TecnicoEntities())
            {
                var tickets = context.Ticket
                    .Include(t => t.Tecnico)
                    .Where(t => t.IdAtendidoPor != null);

                if (idTecnico.HasValue)
                {
                    tickets = tickets.Where(t => t.IdAtendidoPor == idTecnico.Value);
                }

                if (!string.IsNullOrEmpty(estado) && estado != "Todos")
                {
                    tickets = tickets.Where(t => t.DEstado == estado);
                }

                return tickets.ToList()
                    .GroupBy(t => t.Tecnico.IdTecnico)
                    .Select(g => new ReporteTecnico
                    {
                        IdTecnico = g.Key,
                        CodigoTecnico = g.First().Tecnico.CTecnico,
                        NombreTecnico = g.First().Tecnico.DNombres,
                        CantidadResueltos = g.Count(t => t.DEstado == "Resuelto"),
                        CantidadPendientes = g.Count(t => t.DEstado != "Resuelto")
                    })
                    .ToList();
            }
        }

        public List<DetalleTecnico> ObtenerDetalleTecnico(int? idTecnico)
        {
            List<DetalleTecnico> lista = new List<DetalleTecnico>();
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    var query = context.Ticket
                        .Include(t => t.TipoSolicitud)
                        .Include(t => t.Tecnico)
                        .Where(t => t.IdAtendidoPor != null);

                    if (idTecnico.HasValue)
                    {
                        query = query.Where(t => t.IdAtendidoPor == idTecnico.Value);
                    }

                    lista = query
                        .Select(t => new DetalleTecnico
                        {
                            IdTicket = t.IdTicket,
                            Titulo = t.DTitulo,
                            TipoSolicitud = t.TipoSolicitud.DNombre,
                            Prioridad = t.DPrioridad,
                            Estado = t.DEstado,
                            FechaCreacion = t.FCreacion
                        })
                        .ToList();
                }
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return lista;
            }
        }

        public List<TecnicoFiltroItem> ObtenerTecnicos()
        {
            using (var context = new dbSistema_TecnicoEntities())
            {
                List<TecnicoFiltroItem> lista = context.Tecnico
                    .Select(t => new TecnicoFiltroItem
                    {
                        IdTecnico = t.IdTecnico,
                        Codigo = t.CTecnico
                    })
                    .ToList();

                lista.Insert(0, new TecnicoFiltroItem { IdTecnico = null, Codigo = "Todos" });
                return lista;
            }
        }
        // FIN REPORTE 3
        // FIN REPORTE 3
    }
}