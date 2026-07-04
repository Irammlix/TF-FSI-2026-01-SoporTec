using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using static CapaDatos.DClasesAuxiliares;

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
                        .Include(t => t.Pabellon)
                        .Include(t => t.Sede)
                        .Include(t => t.TipoSolicitud)
                        .Include(t => t.Solicitante)
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

        //ADMINISTRADOR
        public List<TicketVistaAdmin> ListarTodoAdministrador()
        {
            List<TicketVistaAdmin> LTickets = new List<TicketVistaAdmin>();

            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    LTickets = context.Ticket
                .Include(t => t.Pabellon)
                .Include(t => t.Sede)
                .Include(t => t.Solicitante)
                .Include(t => t.Tecnico).ToList()
                .Select(t => new TicketVistaAdmin
                {
                    IdTicket = t.IdTicket,
                    Titulo = t.DTitulo,
                    Sede = t.Sede.DNombreSede,
                    Pabellon = t.Pabellon.DNombrePabellon,
                    Prioridad = t.DPrioridad,
                    FCreacion = t.FCreacion,
                    FActualizacion = t.FActualizacion,
                    Estado = t.DEstado,
                    NombreTecnicoAsignado = t.Tecnico == null ? "" : t.Tecnico.DNombres,
                    IdSolicitante = t.IdCreadoPor,
                    IdTecnico = t.IdAtendidoPor.GetValueOrDefault(-1)
                 
                })
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


        public List<TicketVistaAdmin> ObtenerTitutloOID(string idOTitulo, List<TicketVistaAdmin> lista)
        {
            List<TicketVistaAdmin> LTickets = lista;
            if (lista == null)
            {
                LTickets = ListarTodoAdministrador();
            }
            try
            {
                if (idOTitulo.Equals(""))
                {
                    return LTickets;
                }
                List<TicketVistaAdmin> TicketsFiltrados = LTickets.Where(t => t.Titulo.Contains(idOTitulo) || t.IdTicket.ToString().StartsWith(idOTitulo)).ToList();

                return TicketsFiltrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return LTickets;
            }
        }
        public List<TicketVistaAdmin> ListarTicketsEstadoPrioridadNombre(string estadoSeleccionado, string prioridadSeleccionada, string NombreOId)
        {
            List<TicketVistaAdmin> LTickets = ListarTodoAdministrador();
            try
            {
                if (NombreOId == "")
                {
                    if (prioridadSeleccionada != "Todos")
                    {
                        LTickets = LTickets
                            .Where(t => t.Prioridad == prioridadSeleccionada)
                            .ToList();
                    }

                    if (estadoSeleccionado != "Todos")
                    {
                        LTickets = LTickets
                            .Where(t => t.Estado == estadoSeleccionado)
                            .ToList();
                    }

                    LTickets = LTickets
                        .OrderBy(t => OrdenEstado(t.Estado))
                        .ThenBy(t => OrdenPrioridad(t.Prioridad))
                        .ToList();
                    return LTickets;
                }

                if (prioridadSeleccionada != "Todos")
                {
                    LTickets = LTickets
                        .Where(t => t.Prioridad == prioridadSeleccionada)
                        .ToList();
                }

                if (estadoSeleccionado != "Todos")
                {
                    LTickets = LTickets
                        .Where(t => t.Estado == estadoSeleccionado)
                        .ToList();
                }

                LTickets = LTickets
                    .OrderBy(t => OrdenEstado(t.Estado))
                    .ThenBy(t => OrdenPrioridad(t.Prioridad))
                    .ToList();
                LTickets = ObtenerTitutloOID(NombreOId, LTickets);


                return LTickets;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return LTickets;
            }
        }
        public string AsignarTicket(int idTecnico, int idTicket, int administradorActual,string Prioridad)
        {
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    Ticket ticket = context.Ticket.Find(idTicket);

                    ticket.IdAtendidoPor = idTecnico;
                    ticket.IdAsignadoPor = administradorActual;
                    ticket.DPrioridad = Prioridad;
                    ticket.DEstado = "Asignado";
                    ticket.FActualizacion = DateTime.Now;

                    context.SaveChanges();
                }

                return "Ticket asignado correctamente";
            }
            catch (Exception ex)
            {
                // Buscamos el error más profundo y específico que nos manda SQL Server
                Exception errorReal = ex;
                while (errorReal.InnerException != null)
                {
                    errorReal = errorReal.InnerException;
                }

                return "Error en BD: " + errorReal.Message;
            }
        }


    }
}