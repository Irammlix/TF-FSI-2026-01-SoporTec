using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DAdmin
    {
        public Administrador ValidarCredenciales(string codigo, string contrasena)
        {
            Administrador admin = null;
            try
            {
                using (var context = new dbSistema_TecnicoEntities())
                {
                    admin = context.Administrador
                        .Where(a => a.CAdministrador == codigo)
                        .Where(a => a.DContrasena == contrasena)
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
    }
}
