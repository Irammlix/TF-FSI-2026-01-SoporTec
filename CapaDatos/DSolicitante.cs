using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DSolicitante
    {
        public List<Solicitante> ListarTodo()
        {
            List<Solicitante> solicitantes = new List<Solicitante>();
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    solicitantes = context.Solicitante
                        .Where(s => s.DActivo == true)
                        .ToList();
                }
                return solicitantes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return solicitantes;
            }
        }

        public string Registrar(Solicitante solicitante)
        {
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    context.Solicitante.Add(solicitante);
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

        public Solicitante ValidarCredenciales(string codigo, string contrasena)
        {
            Solicitante solicitante = null;
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    solicitante = context.Solicitante
                        .Where(s => s.CSolicitante == codigo)
                        .Where(s => s.DContrasena == contrasena)
                        .Where(s => s.DActivo == true)
                        .FirstOrDefault();
                }
                return solicitante;
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
                    Solicitante solicitante_temporal = context.Solicitante
                        .Where(s => s.CSolicitante == codigo)
                        .Where(s => s.DActivo == true)
                        .FirstOrDefault();

                    if (solicitante_temporal == null)
                        return "No se encontró el solicitante";

                    solicitante_temporal.DContrasena = nuevaContrasena;
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
    }
}
