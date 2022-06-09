using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.California.Clean.Models
{
    public partial class CaliforniaCleanContext : DbContext
    {
        private readonly string _ConnectionStrings;
        public CaliforniaCleanContext( string ConnectionStrings )
        {
            _ConnectionStrings = ConnectionStrings;
        }

        public CaliforniaCleanContext(DbContextOptions<CaliforniaCleanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActividadesOrden> ActividadesOrdens { get; set; } = null!;
        public virtual DbSet<CambiosOrden> CambiosOrdens { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<EstatusProyecto> EstatusProyectos { get; set; } = null!;
        public virtual DbSet<MontosCambiosOrden> MontosCambiosOrdens { get; set; } = null!;
        public virtual DbSet<OrdenesTrabajo> OrdenesTrabajos { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;
        public virtual DbSet<Proyecto> Proyectos { get; set; } = null!;
        public virtual DbSet<TiposConstruccion> TiposConstruccions { get; set; } = null!;
        public virtual DbSet<TiposProyecto> TiposProyectos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<Vendedore> Vendedores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer( _ConnectionStrings );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActividadesOrden>(entity =>
            {
                entity.ToTable("Actividades_Orden");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdOrdenTrabajo).HasColumnName("idOrdenTrabajo");

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdOrdenTrabajoNavigation)
                    .WithMany(p => p.ActividadesOrdens)
                    .HasForeignKey(d => d.IdOrdenTrabajo)
                    .HasConstraintName("FK_Actividades_Orden_Ordenes_Trabajo");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.ActividadesOrdens)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK_Actividades_Orden_Proveedores");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ActividadesOrdens)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Actividades_Orden_Usuarios");
            });

            modelBuilder.Entity<CambiosOrden>(entity =>
            {
                entity.ToTable("Cambios_Orden");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdOrdenTrabajo).HasColumnName("idOrdenTrabajo");

                entity.Property(e => e.IdProyecto).HasColumnName("idProyecto");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.CambiosOrdens)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("FK_Cambios_Orden_Proyectos");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.Compania)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasColumnName("compania");

                entity.Property(e => e.Correo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Cp).HasColumnName("cp");

                entity.Property(e => e.Direccion)
                    .HasColumnType("text")
                    .HasColumnName("direccion");

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreado");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<EstatusProyecto>(entity =>
            {
                entity.ToTable("Estatus_Proyecto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<MontosCambiosOrden>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Montos_Cambios_Orden");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCambioOrden).HasColumnName("idCambioOrden");

                entity.Property(e => e.IdProyecto).HasColumnName("idProyecto");

                entity.Property(e => e.Monto)
                    .HasColumnType("money")
                    .HasColumnName("monto");

                entity.HasOne(d => d.IdCambioOrdenNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCambioOrden)
                    .HasConstraintName("FK_Montos_Cambios_Orden_Cambios_Orden");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("FK_Montos_Cambios_Orden_Proyectos");
            });

            modelBuilder.Entity<OrdenesTrabajo>(entity =>
            {
                entity.ToTable("Ordenes_Trabajo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.Contacto)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("contacto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.Fechafin)
                    .HasColumnType("datetime")
                    .HasColumnName("fechafin");

                entity.Property(e => e.IdProyecto).HasColumnName("idProyecto");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.OrdenesTrabajos)
                    .HasForeignKey(d => d.IdProyecto)
                    .HasConstraintName("FK_Ordenes_Trabajo_Proyectos");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.Correo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Cp).HasColumnName("cp");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaFin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaInicio");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.IdTipoConstruccion).HasColumnName("idTipoConstruccion");

                entity.Property(e => e.IdTipoProyecto).HasColumnName("idTipoProyecto");

                entity.Property(e => e.IdVendedor).HasColumnName("idVendedor");

                entity.Property(e => e.Monto)
                    .HasColumnType("money")
                    .HasColumnName("monto");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.ProveedorMonto)
                    .HasColumnType("money")
                    .HasColumnName("proveedorMonto");

                entity.Property(e => e.ProveedorPorcentaje).HasColumnName("proveedorPorcentaje");

                entity.Property(e => e.RetencionesPorcentaje).HasColumnName("retencionesPorcentaje");

                entity.Property(e => e.RetencionesProyecto)
                    .HasColumnType("money")
                    .HasColumnName("retencionesProyecto");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Proyectos_Clientes");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK_Proyectos_Estatus_Proyecto");

                entity.HasOne(d => d.IdTipoConstruccionNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.IdTipoConstruccion)
                    .HasConstraintName("FK_Proyectos_Tipos_Construccion");

                entity.HasOne(d => d.IdTipoProyectoNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.IdTipoProyecto)
                    .HasConstraintName("FK_Proyectos_Tipos_Proyecto");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("FK_Proyectos_Vendedores");
            });

            modelBuilder.Entity<TiposConstruccion>(entity =>
            {
                entity.ToTable("Tipos_Construccion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdTipoProyecto).HasColumnName("idTipoProyecto");

                entity.Property(e => e.Orden).HasColumnName("orden");
            });

            modelBuilder.Entity<TiposProyecto>(entity =>
            {
                entity.ToTable("Tipos_Proyecto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Correo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Vendedore>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Correo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.FechaCreado)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
