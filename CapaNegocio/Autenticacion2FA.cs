using System;
using System.Collections.Generic;

namespace CapaNegocio
{
    public static class Autenticacion2FA
    {
        private static readonly Dictionary<string, (string Codigo, DateTime Expiracion)> _codigos
            = new Dictionary<string, (string, DateTime)>();

        public static string GenerarYAlmacenar(string clave)
        {
            string codigo = new Random().Next(1000, 9999).ToString();
            _codigos[clave] = (codigo, DateTime.Now.AddMinutes(5));
            return codigo;
        }

        public static bool Verificar(string clave, string codigoIngresado)
        {
            if (!_codigos.ContainsKey(clave))
                return false;

            var (codigo, expiracion) = _codigos[clave];
            _codigos.Remove(clave);

            return DateTime.Now <= expiracion && codigo == codigoIngresado;
        }

        public static string OcultarCorreo(string correo)
        {
            if (string.IsNullOrEmpty(correo) || !correo.Contains("@"))
                return "***@***.com";

            var partes = correo.Split('@');
            string usuario = partes[0];
            string dominio = partes[1];

            if (usuario.Length <= 2)
                return usuario[0] + "***@" + dominio;

            return usuario.Substring(0, 2) + new string('*', usuario.Length - 2) + "@" + dominio;
        }
    }
}
