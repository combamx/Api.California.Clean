using System;
using System.Collections.Generic;

namespace Api.California.Clean.Models
{
    public partial class TiposConstruccion
    {
        public TiposConstruccion()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int? Orden { get; set; }
        public int? IdTipoProyecto { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
