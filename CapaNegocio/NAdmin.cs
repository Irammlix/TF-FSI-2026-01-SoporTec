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
            return dAdmin.ValidarCredenciales(codigo, contrasena);
        }
        public int ObtenerId(string codigo)
        {
            return dAdmin.ObtenerId(codigo);
        }
    }
}
