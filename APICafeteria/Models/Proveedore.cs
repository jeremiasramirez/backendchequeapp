using System;
using System.Collections.Generic;

namespace APICafeteria.Models
{
    public partial class Proveedore
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public int Balance { get; set; }
        public int CuentaContable { get; set; }
        public string Estado { get; set; } = null!;
    }
}
