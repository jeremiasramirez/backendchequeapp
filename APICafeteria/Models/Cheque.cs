using System;
using System.Collections.Generic;

namespace APICafeteria.Models
{
    public partial class Cheque
    {
        public int Id { get; set; }
        public double Monto { get; set; }
        public int IdCheque { get; set; }
        public int IdProveedor { get; set; }
        public string NumCuentaCheque { get; set; } = null!;
    }
}
