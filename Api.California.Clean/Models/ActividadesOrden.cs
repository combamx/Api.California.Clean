using System;
using System.Collections.Generic;

namespace Api.California.Clean.Models
{
    public partial class ActividadesOrden
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdProveedor { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdOrdenTrabajo { get; set; }

        public virtual OrdenesTrabajo? IdOrdenTrabajoNavigation { get; set; }
        public virtual Proveedore? IdProveedorNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
