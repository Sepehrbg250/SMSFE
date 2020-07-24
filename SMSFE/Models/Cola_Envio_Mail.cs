using System;
using System.Collections.Generic;
using System.Text;

namespace SMSFE.Models
{
    public class Cola_Envio_Mail
    {
        public long Id { get; set; }
        public DateTime FechaInsercion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string AttachName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Byte[] Attachment { get; set; }
        public string Enviado { get; set; }
        public int TipoAdjunto { get; set; }
        public long IdAdjunto { get; set; }
        public string Rut_Emisor { get; set; }
        public string Rut_Receptor { get; set; }
        public string RazonSocReceptor { get; set; }
        public bool EsAlerta { get; set; }
        public bool Mostrar { get; set; }
        public int CantidadIntentosEnvio { get; set; }





    }
}
