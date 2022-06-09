using System;
using System.Collections.Generic;

namespace Api.California.Clean.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public int Id { get; set; }
        public string? Compania { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public int? Cp { get; set; }
        public string? Telefono { get; set; }
        public int? Estatus { get; set; }
        public string? Correo { get; set; }
        public DateTime? FechaCreado { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
