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
            return dSolicitante.Registrar(solicitante);
        }

        public Solicitante ValidarLogin(string codigo, string contrasena)
        {
            return dSolicitante.ValidarCredenciales(codigo, contrasena);
        }

        public string CambiarContrasena(string codigo, string nuevaContrasena)
        {
            return dSolicitante.CambiarContrasena(codigo, nuevaContrasena);
        }
    }
}
