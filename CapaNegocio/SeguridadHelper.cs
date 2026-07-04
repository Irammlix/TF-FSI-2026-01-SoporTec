using System;
using System.Security.Cryptography;
using System.Text;

namespace CapaNegocio
{
    public static class SeguridadHelper
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                string salted = "SoporTec_" + password + "_2024";
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(salted));
                var sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        public static bool VerificarPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }

        public static bool ValidarComplejidad(string password, out string mensaje)
        {
            mensaje = "";
            if (string.IsNullOrEmpty(password))
            {
                mensaje = "La contraseña no puede estar vacía";
                return false;
            }
            if (password.Length < 6)
            {
                mensaje = "La contraseña debe tener al menos 6 caracteres";
                return false;
            }
            bool tieneLetra = false, tieneNumero = false;
            foreach (char c in password)
            {
                if (char.IsLetter(c)) tieneLetra = true;
                if (char.IsDigit(c)) tieneNumero = true;
            }
            if (!tieneLetra || !tieneNumero)
            {
                mensaje = "La contraseña debe contener letras y números";
                return false;
            }
            return true;
        }
    }
}
