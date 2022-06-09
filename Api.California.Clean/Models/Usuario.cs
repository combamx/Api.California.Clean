using System;
using System.Collections.Generic;

namespace Api.California.Clean.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            ActividadesOrdens = new HashSet<ActividadesOrden>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public int? Estatus { get; set; }

        public virtual ICollection<ActividadesOrden> ActividadesOrdens { get; set; }
    }
}
