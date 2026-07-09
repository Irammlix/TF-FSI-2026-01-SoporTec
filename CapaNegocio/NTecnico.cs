using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaDatos.DClasesAuxiliares;

namespace CapaNegocio
{
    public class NTecnico
    {
        private DTecnico dTecnico = new DTecnico();

        public List<Tecnico> ListarTodo()
        {
            return dTecnico.ListarTodo();
        }

        public bool ExisteCodigo(string codigo)
        {
            return dTecnico.ExisteCodigo(codigo);
        }

        public string Registrar(Tecnico tecnico)
        {
            if (ExisteCodigo(tecnico.CTecnico))
                return "El código ya está en uso";

            tecnico.DActivo = true;
            tecnico.FCreacion = DateTime.Now;
            tecnico.DContrasena = SeguridadHelper.HashPassword(tecnico.DContrasena);
            return dTecnico.Registrar(tecnico);
        }
        public string Modificar(Tecnico tecnico)
        {
            return dTecnico.Modificar(tecnico);
        }

        public string Eliminar(int idTecnico)
        {
            return dTecnico.EliminarLogico(idTecnico);
        }

        public Tecnico ValidarLogin(string codigo, string contrasena)
        {
            Tecnico tecnico = dTecnico.ObtenerPorCodigo(codigo);
            if (tecnico == null)
                return null;

            if (SeguridadHelper.VerificarPassword(contrasena, tecnico.DContrasena))
                return tecnico;

            // Cuenta antigua con contraseña en texto plano: valida y migra al hash.
            if (tecnico.DContrasena == contrasena)
            {
                string hash = SeguridadHelper.HashPassword(contrasena);
                dTecnico.CambiarContrasena(codigo, hash);
                tecnico.DContrasena = hash;
                return tecnico;
            }

            return null;
        }
        public string CambiarContrasena(string codigo, string nuevaContrasena)
        {
            return dTecnico.CambiarContrasena(codigo, SeguridadHelper.HashPassword(nuevaContrasena));
        }
        public List<TecnicosVistaAdmin> AsigListarTecnicos()
        {
            return dTecnico.ListarTecnicosAsignar();
        }
        public Tecnico ObtenerPorId(int idTecnico)
        {
            return dTecnico.ObtenerPorId(idTecnico);    
        }
        //ver si mantener 
        public String reactivarTecnico(int id)
        {
            if (id <= 0)
                return "Técnico no válido";

            return dTecnico.reactivarTecnico(id);
        }
        public List<Tecnico> ListarConDetalle(string txtbusqueda, string ordenarpor)
        {
            return dTecnico.ListarConDetalle(txtbusqueda, ordenarpor);
        }
    }
}
