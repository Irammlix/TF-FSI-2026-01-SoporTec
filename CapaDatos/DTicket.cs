using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace CapaDatos
{
    public class DTicket
    {
        public Ticket ObtenerPorId(int idTicket)
        {
            Ticket ticket = null;

            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    ticket = context.Ticket
                        .Include(t => t.Pabellon)
                        .Include(t => t.Sede)
                        .Include(t => t.TipoSolicitud)
                        .Include(t => t.Administrador)
                        .Include(t => t.Solicitante)
                        .Include(t => t.Tecnico)
                        .Where(t => t.IdTicket == idTicket)
                        .FirstOrDefault();
                }

                return ticket;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // INICIO: TECNICO
        private int OrdenEstado(string estado)
        {
            if (estado == "Asignado")
                return 1;

            if (estado == "En Proceso")
                return 2;

            if (estado == "Resuelto")
                return 3;

            return 4;
        }
        private int OrdenPrioridad(string prioridad)
        {
            if (prioridad == "Alta")
                return 1;

            if (prioridad == "Media")
                return 2;

            if (prioridad == "Baja")
                return 3;

            return 4;
        }

        public List<Ticket> ListarPorTecnico(int idTecnico, string prioridad, string estado)
        {
            List<Ticket> LTickets = new List<Ticket>();

            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    LTickets = context.Ticket
                        .Where(t => t.IdAtendidoPor == idTecnico)
                        .ToList();

                    if (prioridad != "Todos")
                    {
                        LTickets = LTickets
                            .Where(t => t.DPrioridad == prioridad)
                            .ToList();
                    }

                    if (estado != "Todos")
                    {
                        LTickets = LTickets
                            .Where(t => t.DEstado == estado)
                            .ToList();
                    }

                    LTickets = LTickets
                        .OrderBy(t => OrdenEstado(t.DEstado))
                        .ThenBy(t => OrdenPrioridad(t.DPrioridad))
                        .ToList();
                }

                return LTickets;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return LTickets;
            }
        }

        //listar por solicitante
        public List<Ticket> ListarPorSolicitante(int idSolicitante, string estado)
        {
            List<Ticket> LTickets = new List<Ticket>();

            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    LTickets = context.Ticket
                        .Include(t => t.TipoSolicitud)
                        .Include(t => t.Sede)
                        .Include(t => t.Pabellon)
                        .Where(t => t.IdCreadoPor == idSolicitante)
                        .ToList();

                    if (estado != "Todos")
                    {
                        LTickets = LTickets
                            .Where(t => t.DEstado == estado)
                            .ToList();
                    }

                    LTickets = LTickets
                        .OrderBy(t => OrdenEstado(t.DEstado))
                        .ThenBy(t => OrdenPrioridad(t.DPrioridad))
                        .ToList();
                }

                return LTickets;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return LTickets;
            }
        }

        //Cancelar Ticket
        public string CancelarTicket(int idTicket)
        {
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    Ticket ticket = context.Ticket.Find(idTicket);

                    ticket.DEstado = "Cancelado";
                    ticket.FActualizacion = DateTime.Now;

                    context.SaveChanges();
                }

                return "Ticket cancelado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //registrar tecnico
        public string Registrar(Ticket ticket)
        {
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    context.Ticket.Add(ticket);
                    context.SaveChanges();
                }
                return "Registrado exitosamente";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }
        public string ActualizarTicketTecnico(int idTicket, string estado, string comentario)
        {
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    Ticket ticket = context.Ticket.Find(idTicket);

                    ticket.DEstado = estado;
                    ticket.DComentario = comentario;
                    ticket.FActualizacion = DateTime.Now;

                    context.SaveChanges();
                }

                return "Ticket actualizado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // FIN : TECNICO
    }
}
