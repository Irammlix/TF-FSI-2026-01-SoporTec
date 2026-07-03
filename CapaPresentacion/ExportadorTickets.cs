using CapaDatos;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;

namespace CapaPresentacion
{
    public class ExportadorTickets
    {
        public static void ExportarCsv(List<Ticket> tickets, string rutaArchivo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("sep=;");
            sb.AppendLine("N° Ticket;Título;Descripción;Estado;Prioridad;Comentario;Fecha Creación;Fecha Actualización;Solicitante");

            foreach (Ticket ticket in tickets)
            {
                string linea = "";

                linea += ticket.IdTicket + ";";
                linea += LimpiarTexto(ticket.DTitulo) + ";";
                linea += LimpiarTexto(ticket.DDescripcion) + ";";
                linea += LimpiarTexto(ticket.DEstado) + ";";
                linea += LimpiarTexto(ticket.DPrioridad) + ";";
                linea += LimpiarTexto(ticket.DComentario) + ";";
                linea += ticket.FCreacion.ToString() + ";";
                linea += ticket.FActualizacion.ToString() + ";";
                linea += ticket.IdCreadoPor.ToString();

                sb.AppendLine(linea);
            }

            File.WriteAllText(rutaArchivo, sb.ToString(), Encoding.Default);
        }

        private static string LimpiarTexto(string texto)
        {
            if (texto == null)
                return "";

            return texto.Replace(";", ",").Replace("\n", " ").Replace("\r", " ");
        }

        private static void DibujarCampo(Graphics g, string etiqueta, string valor, int x, int y, Font fontEtiqueta, Font fontTexto)
        {
            g.DrawString(etiqueta, fontEtiqueta, Brushes.Black, x, y);
            g.DrawString(valor ?? "", fontTexto, Brushes.Black, x + 170, y);
        }
        public static void ExportarPdfTicket(Ticket ticket, string rutaArchivo)
        {
            PrintDocument documento = new PrintDocument();

            documento.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            documento.PrinterSettings.PrintToFile = true;
            documento.PrinterSettings.PrintFileName = rutaArchivo;

            documento.PrintPage += (sender, e) =>
            {
                Graphics g = e.Graphics;

                Font fontTitulo = new Font("Arial", 18, FontStyle.Bold);
                Font fontSubtitulo = new Font("Arial", 11, FontStyle.Bold);
                Font fontTexto = new Font("Arial", 10);
                Font fontSeccion = new Font("Arial", 12, FontStyle.Bold);

                Brush colorTexto = Brushes.Black;
                Brush colorBlanco = Brushes.White;
                Brush colorCabecera = new SolidBrush(Color.FromArgb(35, 45, 65));
                Brush colorSeccion = new SolidBrush(Color.FromArgb(230, 235, 245));

                Pen lapizBorde = new Pen(Color.FromArgb(160, 160, 160), 1);

                int x = 60;
                int y = 50;
                int ancho = 720;

                // Cabecera
                g.FillRectangle(colorCabecera, x, y, ancho, 60);
                g.DrawString("FICHA DEL TICKET", fontTitulo, colorBlanco, x + 20, y + 17);

                y += 80;

                // Número de ticket
                g.DrawString("N° Ticket: " + ticket.IdTicket.ToString(), fontSubtitulo, colorTexto, x, y);
                y += 35;

                // Sección: Datos generales
                g.FillRectangle(colorSeccion, x, y, ancho, 30);
                g.DrawRectangle(lapizBorde, x, y, ancho, 30);
                g.DrawString("Datos generales", fontSeccion, colorTexto, x + 10, y + 7);

                y += 45;

                DibujarCampo(g, "Título:", ticket.DTitulo, x, y, fontSubtitulo, fontTexto);
                y += 30;

                DibujarCampo(g, "Tipo de solicitud:", ticket.TipoSolicitud.DNombre, x, y, fontSubtitulo, fontTexto);
                y += 30;

                DibujarCampo(g, "Sede:", ticket.Sede.DNombreSede, x, y, fontSubtitulo, fontTexto);
                y += 30;

                DibujarCampo(g, "Pabellón:", ticket.Pabellon.DNombrePabellon, x, y, fontSubtitulo, fontTexto);
                y += 30;

                DibujarCampo(g, "Solicitante:", ticket.Solicitante.DNombres, x, y, fontSubtitulo, fontTexto);
                y += 40;

                // Sección: Estado del ticket
                g.FillRectangle(colorSeccion, x, y, ancho, 30);
                g.DrawRectangle(lapizBorde, x, y, ancho, 30);
                g.DrawString("Estado del ticket", fontSeccion, colorTexto, x + 10, y + 7);

                y += 45;

                DibujarCampo(g, "Prioridad:", ticket.DPrioridad, x, y, fontSubtitulo, fontTexto);
                y += 30;

                DibujarCampo(g, "Estado:", ticket.DEstado, x, y, fontSubtitulo, fontTexto);
                y += 30;

                DibujarCampo(g, "Fecha de creación:", ticket.FCreacion.ToString(), x, y, fontSubtitulo, fontTexto);
                y += 30;

                DibujarCampo(g, "Fecha de actualización:", ticket.FActualizacion.ToString(), x, y, fontSubtitulo, fontTexto);
                y += 40;

                // Sección: Descripción
                g.FillRectangle(colorSeccion, x, y, ancho, 30);
                g.DrawRectangle(lapizBorde, x, y, ancho, 30);
                g.DrawString("Descripción del problema", fontSeccion, colorTexto, x + 10, y + 7);

                y += 45;

                Rectangle rectDescripcion = new Rectangle(x, y, ancho, 90);
                g.DrawRectangle(lapizBorde, rectDescripcion);
                g.DrawString(ticket.DDescripcion ?? "", fontTexto, colorTexto, rectDescripcion);

                y += 115;

                // Sección: Comentario técnico
                g.FillRectangle(colorSeccion, x, y, ancho, 30);
                g.DrawRectangle(lapizBorde, x, y, ancho, 30);
                g.DrawString("Comentario técnico", fontSeccion, colorTexto, x + 10, y + 7);

                y += 45;

                Rectangle rectComentario = new Rectangle(x, y, ancho, 90);
                g.DrawRectangle(lapizBorde, rectComentario);
                g.DrawString(ticket.DComentario ?? "", fontTexto, colorTexto, rectComentario);

                y += 120;

                // Pie de página
                g.DrawLine(lapizBorde, x, y, x + ancho, y);
                y += 15;
                g.DrawString("Sistema de Tickets Universitario", fontTexto, Brushes.Gray, x, y);
            };

            documento.Print();
        }
    }
}