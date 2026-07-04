using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NSolicitante
    {
        private DSolicitante dSolicitante = new DSolicitante();

        public List<Solicitante> ListarTodo()
        {
            return dSolicitante.ListarTodo();
        }

        public string Registrar(Solicitante solicitante)
        {
            solicitante.DActivo = true;
            solicitante.FCreacion = DateTime.Now;
            solicitante.DContrasena = SeguridadHelper.HashPassword(solicitante.DContrasena);
            return dSolicitante.Registrar(solicitante);
        }

        public Solicitante ValidarLogin(string codigo, string contrasena)
        {
            Solicitante solicitante = dSolicitante.ObtenerPorCodigo(codigo);
            if (solicitante == null)
                return null;

            if (SeguridadHelper.VerificarPassword(contrasena, solicitante.DContrasena))
                return solicitante;

            // Cuenta antigua con contraseña en texto plano: valida y migra al hash.
            if (solicitante.DContrasena == contrasena)
            {
                string hash = SeguridadHelper.HashPassword(contrasena);
                dSolicitante.CambiarContrasena(codigo, hash);
                solicitante.DContrasena = hash;
                return solicitante;
            }

            return null;
        }

        public string CambiarContrasena(string codigo, string nuevaContrasena)
        {
            return dSolicitante.CambiarContrasena(codigo, SeguridadHelper.HashPassword(nuevaContrasena));
        }
    }
}
