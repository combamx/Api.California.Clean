using System;
using System.Collections.Generic;

namespace Api.California.Clean.Models
{
    public partial class EstatusProyecto
    {
        public EstatusProyecto()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
