using System;
using System.Collections.Generic;

namespace Api.California.Clean.Models
{
    public partial class OrdenesTrabajo
    {
        public OrdenesTrabajo()
        {
            ActividadesOrdens = new HashSet<ActividadesOrden>();
        }

        public int Id { get; set; }
        public int? IdProyecto { get; set; }
        public string? Contacto { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Telefono { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? Fechafin { get; set; }

        public virtual Proyecto? IdProyectoNavigation { get; set; }
        public virtual ICollection<ActividadesOrden> ActividadesOrdens { get; set; }
    }
}
