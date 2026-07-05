using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
