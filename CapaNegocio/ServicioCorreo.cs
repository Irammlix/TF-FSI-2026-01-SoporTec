using System.Net;
using System.Net.Mail;

namespace CapaNegocio
{
    public static class ServicioCorreo
    {
        // ====== CONFIGURAR ANTES DE USAR ======
        // 1. Activar Verificación en 2 pasos en tu cuenta de Google
        // 2. Ir a myaccount.google.com > Seguridad > Contraseñas de aplicaciones
        // 3. Generar una contraseña para "Correo" y pegarla abajo (sin espacios)
        public static string UltimoError { get; private set; }
        private static readonly string CorreoEmisor = "jporrasaliano@gmail.com";
        private static readonly string ContrasenaApp = "nzlilipvhnpwpvjk";

        private static void Enviar(string destinatario, string asunto, string cuerpoHtml)
        {
            var mensaje = new MailMessage
            {
                From = new MailAddress(CorreoEmisor, "SoporTec"),
                Subject = asunto,
                Body = cuerpoHtml,
                IsBodyHtml = true
            };
            mensaje.To.Add(destinatario);

            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential(CorreoEmisor, ContrasenaApp);
                smtp.EnableSsl = true;
                smtp.Send(mensaje);
            }
        }

        public static bool EnviarCodigo2FA(string destinatario, string codigo)
        {
            try
            {
                string cuerpo = string.Format(@"
                <div style='font-family:Segoe UI,sans-serif;max-width:500px;margin:auto;padding:30px;border:1px solid #e0e0e0;border-radius:10px'>
                    <h2 style='color:#B4232D;text-align:center'>SoporTec</h2>
                    <p>Tu código de verificación es:</p>
                    <div style='text-align:center;margin:20px 0'>
                        <span style='font-size:32px;font-weight:bold;letter-spacing:8px;background:#f5f5f5;padding:15px 30px;border-radius:8px'>{0}</span>
                    </div>
                    <p style='color:#666;font-size:13px'>Este código expira en 5 minutos. No compartas este código con nadie.</p>
                </div>", codigo);
                Enviar(destinatario, "Código de Verificación - SoporTec", cuerpo);
                return true;
            }
            catch (System.Exception ex)
            {
                UltimoError = ex.Message + (ex.InnerException != null ? " → " + ex.InnerException.Message : "");
                return false;
            }
        }

        public static bool EnviarNotificacionTicket(string destinatario, string tituloTicket, string estado, int idTicket)
        {
            try
            {
                string cuerpo = string.Format(@"
                <div style='font-family:Segoe UI,sans-serif;max-width:500px;margin:auto;padding:30px;border:1px solid #e0e0e0;border-radius:10px'>
                    <h2 style='color:#B4232D;text-align:center'>SoporTec</h2>
                    <h3>Actualización de Ticket #{0}</h3>
                    <p><strong>Título:</strong> {1}</p>
                    <p><strong>Estado:</strong> <span style='color:#0D9488;font-weight:bold'>{2}</span></p>
                    <p style='color:#666;font-size:13px'>Este es un mensaje automático del sistema de soporte técnico.</p>
                </div>", idTicket, tituloTicket, estado);
                Enviar(destinatario, string.Format("Ticket #{0} - {1} | SoporTec", idTicket, estado), cuerpo);
                return true;
            }
            catch { return false; }
        }

        public static bool EnviarConfirmacionCreacion(string destinatario, string tituloTicket, int idTicket)
        {
            try
            {
                string cuerpo = string.Format(@"
                <div style='font-family:Segoe UI,sans-serif;max-width:500px;margin:auto;padding:30px;border:1px solid #e0e0e0;border-radius:10px'>
                    <h2 style='color:#B4232D;text-align:center'>SoporTec</h2>
                    <h3 style='text-align:center'>Ticket Registrado Exitosamente</h3>
                    <div style='background:#f5f5f5;padding:15px;border-radius:8px;margin:15px 0'>
                        <p><strong>Ticket N°:</strong> {0}</p>
                        <p><strong>Título:</strong> {1}</p>
                        <p><strong>Estado:</strong> <span style='color:#0D9488;font-weight:bold'>Sin Asignar</span></p>
                    </div>
                    <p>Tu solicitud ha sido registrada correctamente. Un administrador asignará un técnico para atender tu caso.</p>
                    <p>Puedes revisar el estado de tu ticket en la sección <strong>Mis Tickets</strong>.</p>
                    <p style='color:#666;font-size:13px'>Este es un mensaje automático del sistema de soporte técnico SoporTec.</p>
                </div>", idTicket, tituloTicket);
                Enviar(destinatario, string.Format("Ticket #{0} Registrado | SoporTec", idTicket), cuerpo);
                return true;
            }
            catch (System.Exception ex)
            {
                UltimoError = ex.Message + (ex.InnerException != null ? " → " + ex.InnerException.Message : "");
                return false;
            }
        }

        public static bool EnviarRecuperacion(string destinatario, string codigo)
        {
            try
            {
                string cuerpo = string.Format(@"
                <div style='font-family:Segoe UI,sans-serif;max-width:500px;margin:auto;padding:30px;border:1px solid #e0e0e0;border-radius:10px'>
                    <h2 style='color:#B4232D;text-align:center'>SoporTec</h2>
                    <p>Recibimos una solicitud para recuperar tu contraseña.</p>
                    <p>Tu código de verificación es:</p>
                    <div style='text-align:center;margin:20px 0'>
                        <span style='font-size:32px;font-weight:bold;letter-spacing:8px;background:#f5f5f5;padding:15px 30px;border-radius:8px'>{0}</span>
                    </div>
                    <p style='color:#666;font-size:13px'>Si no solicitaste este cambio, ignora este mensaje.</p>
                </div>", codigo);
                Enviar(destinatario, "Recuperar Contraseña - SoporTec", cuerpo);
                return true;
            }
            catch { return false; }
        }
    }
}
