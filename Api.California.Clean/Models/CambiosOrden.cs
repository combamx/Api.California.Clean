using System;
using System.Collections.Generic;

namespace Api.California.Clean.Models
{
    public partial class CambiosOrden
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdOrdenTrabajo { get; set; }
        public int? IdProyecto { get; set; }

        public virtual Proyecto? IdProyectoNavigation { get; set; }
    }
}
