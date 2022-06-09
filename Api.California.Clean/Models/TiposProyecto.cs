using System;
using System.Collections.Generic;

namespace Api.California.Clean.Models
{
    public partial class TiposProyecto
    {
        public TiposProyecto()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
