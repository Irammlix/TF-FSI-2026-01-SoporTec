using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NTecnico
    {
        private DTecnico dTecnico = new DTecnico();

        public List<Tecnico> ListarTodo()
        {
            return dTecnico.ListarTodo();
        }

        public string Registrar(Tecnico tecnico)
        {
            // en capa negocio se setea DActivo = true al registrar
            tecnico.DActivo = true; 
            tecnico.FCreacion = DateTime.Now;
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
            return dTecnico.ValidarCredenciales(codigo, contrasena);
        }
        public string CambiarContrasena(string codigo, string nuevaContrasena)
        {
            return dTecnico.CambiarContrasena(codigo, nuevaContrasena);
        }

        //ver si mantener 
        public String reactivarTecnico(int id)
        {
            if (id <= 0)
                return "Técnico no válido";

            return dTecnico.reactivarTecnico(id);
        }

    }
}
