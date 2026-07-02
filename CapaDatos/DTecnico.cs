using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                    tecnico_temporal.CTecnico = tecnico.CTecnico;
                    tecnico_temporal.DNombres = tecnico.DNombres;
                    tecnico_temporal.DApellidos = tecnico.DApellidos;
                    tecnico_temporal.DContrasena = tecnico.DContrasena;
                    tecnico_temporal.IdEspecialidad = tecnico.IdEspecialidad;
                    tecnico_temporal.IdSede = tecnico.IdSede;
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
    }
}
