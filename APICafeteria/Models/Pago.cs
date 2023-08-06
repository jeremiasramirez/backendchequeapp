using System;
using System.Collections.Generic;

namespace APICafeteria.Models
{
    public partial class Pago
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string Estado { get; set; } = null!;
    }
}
