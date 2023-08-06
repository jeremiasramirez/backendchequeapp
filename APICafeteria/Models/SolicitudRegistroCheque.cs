using System;
using System.Collections.Generic;

namespace APICafeteria.Models
{
    public partial class SolicitudRegistroCheque
    {
        public int Id { get; set; }
        public int NumeroSolicitud { get; set; }
        public string FechaRegistro { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public int ProveedorId { get; set; }
        public string CContableProveedor { get; set; } = null!;
        public int Monto { get; set; }
        public string ProveedorNombre { get; set; } = null!;
    }
}
