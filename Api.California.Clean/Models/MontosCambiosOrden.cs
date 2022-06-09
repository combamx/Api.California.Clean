using System;
using System.Collections.Generic;

namespace Api.California.Clean.Models
{
    public partial class MontosCambiosOrden
    {
        public int? Id { get; set; }
        public decimal? Monto { get; set; }
        public int? IdCambioOrden { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdProyecto { get; set; }

        public virtual CambiosOrden? IdCambioOrdenNavigation { get; set; }
        public virtual Proyecto? IdProyectoNavigation { get; set; }
    }
}
