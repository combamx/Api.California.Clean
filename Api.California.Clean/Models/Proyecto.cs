using System;
using System.Collections.Generic;

namespace Api.California.Clean.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            CambiosOrdens = new HashSet<CambiosOrden>();
            OrdenesTrabajos = new HashSet<OrdenesTrabajo>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public decimal? Monto { get; set; }
        public double? RetencionesPorcentaje { get; set; }
        public decimal? RetencionesProyecto { get; set; }
        public double? ProveedorPorcentaje { get; set; }
        public decimal? ProveedorMonto { get; set; }
        public int? IdCliente { get; set; }
        public int? IdVendedor { get; set; }
        public int? IdTipoProyecto { get; set; }
        public int? IdTipoConstruccion { get; set; }
        public int? IdStatus { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Cliente? IdClienteNavigation { get; set; }
        public virtual EstatusProyecto? IdStatusNavigation { get; set; }
        public virtual TiposConstruccion? IdTipoConstruccionNavigation { get; set; }
        public virtual TiposProyecto? IdTipoProyectoNavigation { get; set; }
        public virtual Vendedore? IdVendedorNavigation { get; set; }
        public virtual ICollection<CambiosOrden> CambiosOrdens { get; set; }
        public virtual ICollection<OrdenesTrabajo> OrdenesTrabajos { get; set; }
    }
}
