using System;
using System.Collections.Generic;

#nullable disable

namespace GastosManzia.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Gastos = new HashSet<Gasto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<Gasto> Gastos { get; set; }
    }
}
