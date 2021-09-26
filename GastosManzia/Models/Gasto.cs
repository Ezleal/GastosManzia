using System;
using System.Collections.Generic;

#nullable disable

namespace GastosManzia.Models
{
    public partial class Gasto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public int IdProducto { get; set; }
        public string Detalle { get; set; }
        public double Total { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
