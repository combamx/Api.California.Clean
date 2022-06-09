using System;
using System.Collections.Generic;

namespace Api.California.Clean.Models
{
    public partial class Vendedore
    {
        public Vendedore()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public int? Estatus { get; set; }
        public DateTime? FechaCreado { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
