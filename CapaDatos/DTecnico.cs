using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;

namespace CapaDatos
{
    public class DTecnico
    {
        public List<Tecnico> ListarTodo()
        {
            List<Tecnico> tecnicos = new List<Tecnico>();
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    tecnicos = context.Tecnico
                        .Where(t => t.DActivo == true)
                        .ToList();
                }
                return tecnicos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return tecnicos;
            }
        }

        public bool ExisteCodigo(string codigo)
        {
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    return context.Tecnico.Any(t => t.CTecnico == codigo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public string Registrar(Tecnico tecnico)
        {
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    context.Tecnico.Add(tecnico);
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

        public string Modificar(Tecnico tecnico)
        {
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    Tecnico tecnico_temporal = context.Tecnico.Find(tecnico.IdTecnico);

                    tecnico_temporal.DNombres = tecnico.DNombres;
                    tecnico_temporal.DApellidos = tecnico.DApellidos;
                    tecnico_temporal.IdEspecialidad = tecnico.IdEspecialidad;
                    tecnico_temporal.IdSede = tecnico.IdSede;
                    tecnico_temporal.DCorreo = tecnico.DCorreo;
                    context.SaveChanges();
                }
                return "Modificado exitosamente";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        public string EliminarLogico(int idTecnico)
        {
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    Tecnico tecnico_temporal = context.Tecnico.Find(idTecnico);

                    tecnico_temporal.DActivo = false;
                    context.SaveChanges();
                }
                return "Eliminado exitosamente";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        public Tecnico ValidarCredenciales(string codigo, string contrasena)
        {
            Tecnico tecnico = null;
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    tecnico = context.Tecnico
                        .Where(t => t.CTecnico == codigo)
                        .Where(t => t.DContrasena == contrasena)
                        .Where(t => t.DActivo == true)
                        .FirstOrDefault();
                }
                return tecnico;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public string CambiarContrasena(string codigo, string nuevaContrasena)
        {
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    Tecnico tecnico_temporal = context.Tecnico
                        .Where(t => t.CTecnico == codigo)
                        .Where(t => t.DActivo == true)
                        .FirstOrDefault();

                    if (tecnico_temporal == null)
                        return "No se encontró el técnico";

                    tecnico_temporal.DContrasena = nuevaContrasena;
                    context.SaveChanges();
                }
                return "Contraseña actualizada exitosamente";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }
        //ver si mantener 
        public String reactivarTecnico(int id)
        {
          try
          {
                using (var context = new dbSistema_TecnicoEntities())
                {
                            var registro = context.Tecnico.Find(id);
                            if (registro != null)
                            {
                                registro.DActivo = true;
                                context.SaveChanges();
                            }
                }
                        return "Reactivado exitosamente";
          }
          catch (Exception ex)
          {
          return ex.Message;
          }
        }
        public List<Tecnico> ListarConDetalle(string txtbusqueda, string ordenarpor)
        {
            List<Tecnico> tecnicos= new List<Tecnico>();
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    tecnicos = context.Tecnico
                        .Include(t=>t.Especialidad)
                        .Include(t=>t.Sede)
                        .Include(t=>t.Ticket)
                        .Where(t=>t.DActivo==true)
                        .ToList();
                    if (!string.IsNullOrWhiteSpace(txtbusqueda))
                    {
                        int idBusqueda;
                        if (int.TryParse(txtbusqueda, out idBusqueda))
                        {
                            tecnicos = tecnicos
                                .Where(t => t.IdTecnico == idBusqueda || t.CTecnico.Contains(txtbusqueda))
                                .ToList();
                        }
                        else
                        {
                            tecnicos=tecnicos
                                .Where(t=>(t.DNombres+" "+t.DApellidos)
                                .ToLower()
                                .Contains(txtbusqueda.ToLower()))
                                .ToList();
                        }
                    }
                    switch (ordenarpor)
                    {
                        case "Especialidad":
                            tecnicos = tecnicos.OrderBy(t => t.Especialidad.DNombre).ToList(); break;
                        case "Sede":
                            tecnicos = tecnicos.OrderBy(t=>t.Sede.DNombreSede).ToList(); break;
                        case "Cantidad de Tickets":
                            tecnicos=tecnicos.OrderByDescending(t=>t.Ticket.Count).ToList(); break;
                        default:
                            tecnicos=tecnicos.OrderBy(t=>t.DNombres).ThenBy(t=>t.DApellidos).ToList(); break;

                            
                    }
                }
                return tecnicos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return tecnicos;
            }
            
        }


    }
}
