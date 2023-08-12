using System;
using System.Collections.Generic;

namespace APICafeteria.Models
{
    public partial class Pago1
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string Estado { get; set; } = null!;
    }
}
