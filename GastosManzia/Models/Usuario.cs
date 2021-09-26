using System;
using System.Collections.Generic;

#nullable disable

namespace GastosManzia.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Gastos = new HashSet<Gasto>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Gasto> Gastos { get; set; }
    }
}
