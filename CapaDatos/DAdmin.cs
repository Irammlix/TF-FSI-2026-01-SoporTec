using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DAdmin
    {
        public Administrador ObtenerPorCodigo(string codigo)
        {
            Administrador admin = null;
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    admin = context.Administrador
                        .Where(a => a.CAdministrador == codigo)
                        .FirstOrDefault();
                }
                return admin;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public int ObtenerId(string codigo)
        {
            Administrador admin = null;

            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    admin = context.Administrador
                           .Where(t => t.CAdministrador.Equals(codigo))
                        .FirstOrDefault();
                }

                return admin.IdAdministrador;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }

        public string CambiarContrasena(string codigo, string nuevaContrasena)
        {
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    Administrador admin_temporal = context.Administrador
                        .Where(a => a.CAdministrador == codigo)
                        .FirstOrDefault();

                    if (admin_temporal == null)
                        return "No se encontró el administrador";

                    admin_temporal.DContrasena = nuevaContrasena;
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
