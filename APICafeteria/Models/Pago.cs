using System;
using System.Collections.Generic;

namespace APICafeteria.Models
{
    public partial class Pago
    {
        public int Id { get; set; }
        public string NombreProveedor { get; set; } = null!;
        public string CuentaContable { get; set; } = null!;
        public string Fecha { get; set; } = null!;
        public int Monto { get; set; }
    }
}
