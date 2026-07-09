using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NAdmin
    {
        private DAdmin dAdmin = new DAdmin();

        public Administrador ValidarLogin(string codigo, string contrasena)
        {
            Administrador admin = dAdmin.ObtenerPorCodigo(codigo);
            if (admin == null)
                return null;

            if (SeguridadHelper.VerificarPassword(contrasena, admin.DContrasena))
                return admin;

            // Cuenta antigua con contraseña en texto plano.
            if (admin.DContrasena == contrasena)
                return admin;

            return null;
        }
        public int ObtenerId(string codigo)
        {
            return dAdmin.ObtenerId(codigo);
        }

        public string CambiarContrasena(string codigo, string nuevaContrasena)
        {
            return dAdmin.CambiarContrasena(codigo, SeguridadHelper.HashPassword(nuevaContrasena));
        }
    }
}
