using System;
using AppFacturadorApi.Entities.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppFacturadorApi.Data.Model

{
    public partial class dbSISSODINAContext : IdentityDbContext
    {
        public dbSISSODINAContext()
        {
        }

        public dbSISSODINAContext(DbContextOptions<dbSISSODINAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<TbAbonos> TbAbonos { get; set; }
        public virtual DbSet<TbBarrios> TbBarrios { get; set; }
        public virtual DbSet<TbCajas> TbCajas { get; set; }
        public virtual DbSet<TbCajaUsuario> TbCajaUsuario { get; set; }
        public virtual DbSet<TbCajaUsuMonedas> TbCajaUsuMonedas { get; set; }
        public virtual DbSet<TbCanton> TbCanton { get; set; }
        public virtual DbSet<TbCategoriaProducto> TbCategoriaProducto { get; set; }
        public virtual DbSet<TbClientes> TbClientes { get; set; }
        public virtual DbSet<TbCreditos> TbCreditos { get; set; }
        public virtual DbSet<TbDetalleDocumento> TbDetalleDocumento { get; set; }
        public virtual DbSet<TbDetalleImpresion> TbDetalleImpresion { get; set; }
        public virtual DbSet<TbDetalleMovimiento> TbDetalleMovimiento { get; set; }
        public virtual DbSet<TbDetalleProducto> TbDetalleProducto { get; set; }
        public virtual DbSet<TbDistrito> TbDistrito { get; set; }
        public virtual DbSet<TbDocumento> TbDocumento { get; set; }
        public virtual DbSet<TbEmpleado> TbEmpleado { get; set; }
        public virtual DbSet<TbEmpresa> TbEmpresa { get; set; }
        public virtual DbSet<TbExoneraciones> TbExoneraciones { get; set; }
        public virtual DbSet<TbHorarioProveedor> TbHorarioProveedor { get; set; }
        public virtual DbSet<TbImpuestos> TbImpuestos { get; set; }
        public virtual DbSet<TbIngredienteProveedor> TbIngredienteProveedor { get; set; }
        public virtual DbSet<TbIngredientes> TbIngredientes { get; set; }
        public virtual DbSet<TbInventario> TbInventario { get; set; }
        public virtual DbSet<TbMonedas> TbMonedas { get; set; }
        public virtual DbSet<TbMovimientoCajaUsuario> TbMovimientoCajaUsuario { get; set; }
        public virtual DbSet<TbMovimientos> TbMovimientos { get; set; }
        public virtual DbSet<TbPagos> TbPagos { get; set; }
        public virtual DbSet<TbParametrosEmpresa> TbParametrosEmpresa { get; set; }
        public virtual DbSet<TbPermisos> TbPermisos { get; set; }
        public virtual DbSet<TbPersona> TbPersona { get; set; }
        public virtual DbSet<TbPersonasTribunalS> TbPersonasTribunalS { get; set; }
        public virtual DbSet<TbProducto> TbProducto { get; set; }
        public virtual DbSet<TbProveedores> TbProveedores { get; set; }
        public virtual DbSet<TbProvincia> TbProvincia { get; set; }
        public virtual DbSet<TbReporteHacienda> TbReporteHacienda { get; set; }
        public virtual DbSet<TbRequerimientos> TbRequerimientos { get; set; }
        public virtual DbSet<TbRoles> TbRoles { get; set; }
        public virtual DbSet<TbSucursales> TbSucursales { get; set; }
        public virtual DbSet<TbTipoClientes> TbTipoClientes { get; set; }
        public virtual DbSet<TbTipoDocumento> TbTipoDocumento { get; set; }
        public virtual DbSet<TbTipoId> TbTipoId { get; set; }
        public virtual DbSet<TbTipoIngrediente> TbTipoIngrediente { get; set; }
        public virtual DbSet<TbTipoMedidas> TbTipoMedidas { get; set; }
        public virtual DbSet<TbTipoMoneda> TbTipoMoneda { get; set; }
        public virtual DbSet<TbTipoMovimiento> TbTipoMovimiento { get; set; }
        public virtual DbSet<TbTipoPago> TbTipoPago { get; set; }
        public virtual DbSet<TbTipoPuesto> TbTipoPuesto { get; set; }
        public virtual DbSet<TbTipoVenta> TbTipoVenta { get; set; }
        public virtual DbSet<TbUsuarios> TbUsuarios { get; set; }

        // Unable to generate entity type for table 'dbo.tbPrueba'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=dbSISSODINA;Integrated Security=True;Connect Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publishers>(entity =>
            {
                entity.HasKey(e => e.PubId);

                entity.ToTable("publishers");

                entity.Property(e => e.PubId)
                    .HasColumnName("pub_id")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('USA')");

                entity.Property(e => e.PubName)
                    .HasColumnName("pub_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbAbonos>(entity =>
            {
                entity.HasKey(e => e.IdAbono);

                entity.ToTable("tbAbonos");

                entity.HasIndex(e => e.IdDoc)
                    .HasName("IX_FK_tbAbonos_tbCreditos");

                entity.Property(e => e.IdAbono).HasColumnName("idAbono");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdDoc).HasColumnName("idDoc");

                entity.Property(e => e.Monto)
                    .HasColumnName("monto")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TipoDoc).HasColumnName("tipoDoc");

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TbBarrios>(entity =>
            {
                entity.HasKey(e => new { e.Provincia, e.Canton, e.Distrito, e.Barrio });

                entity.ToTable("tbBarrios");

                entity.Property(e => e.Provincia).HasMaxLength(1);

                entity.Property(e => e.Canton)
                    .HasColumnName("canton")
                    .HasMaxLength(2);

                entity.Property(e => e.Distrito)
                    .HasColumnName("distrito")
                    .HasMaxLength(2);

                entity.Property(e => e.Barrio)
                    .HasColumnName("barrio")
                    .HasMaxLength(2);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50);

                entity.HasOne(d => d.TbDistrito)
                    .WithMany(p => p.TbBarrios)
                    .HasForeignKey(d => new { d.Provincia, d.Canton, d.Distrito })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbBarrios_tbDistrito");
            });

            modelBuilder.Entity<TbCajas>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdEmpresa, e.IdTipoEmpresa, e.IdSucursal });

                entity.ToTable("tbCajas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdEmpresa)
                    .HasColumnName("idEmpresa")
                    .HasMaxLength(30);

                entity.Property(e => e.IdTipoEmpresa).HasColumnName("idTipoEmpresa");

                entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.TbCajas)
                    .HasForeignKey(d => new { d.IdSucursal, d.IdEmpresa, d.IdTipoEmpresa })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCajas_tbSucursales");
            });

            modelBuilder.Entity<TbCajaUsuario>(entity =>
            {
                entity.ToTable("tbCajaUsuario");

                entity.HasIndex(e => e.IdCaja)
                    .HasName("IX_FK_tbCajaUsuario_tbCajas");

                entity.HasIndex(e => new { e.TipoId, e.IdUser })
                    .HasName("IX_FK_tbCajaUsuario_tbUsuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCaja).HasColumnName("idCaja");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasColumnName("idUser")
                    .HasMaxLength(30);

                entity.Property(e => e.TipoId).HasColumnName("tipoId");

                entity.Property(e => e.TipoMovCaja).HasColumnName("tipoMovCaja");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);

                entity.HasOne(d => d.TbUsuarios)
                    .WithMany(p => p.TbCajaUsuario)
                    .HasForeignKey(d => new { d.TipoId, d.IdUser })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCajaUsuario_tbUsuarios");
            });

            modelBuilder.Entity<TbCajaUsuMonedas>(entity =>
            {
                entity.HasKey(e => new { e.IdMoneda, e.IdCajaUsuario });

                entity.ToTable("tbCajaUsuMonedas");

                entity.HasIndex(e => e.IdCajaUsuario)
                    .HasName("IX_FK_tbCajaUsuMonedas_tbCajaUsuario");

                entity.Property(e => e.IdMoneda)
                    .HasColumnName("idMoneda")
                    .HasMaxLength(3);

                entity.Property(e => e.IdCajaUsuario).HasColumnName("idCajaUsuario");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.HasOne(d => d.IdCajaUsuarioNavigation)
                    .WithMany(p => p.TbCajaUsuMonedas)
                    .HasForeignKey(d => d.IdCajaUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCajaUsuMonedas_tbCajaUsuario");

                entity.HasOne(d => d.IdMonedaNavigation)
                    .WithMany(p => p.TbCajaUsuMonedas)
                    .HasForeignKey(d => d.IdMoneda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCajaUsuMonedas_tbMonedas");
            });

            modelBuilder.Entity<TbCanton>(entity =>
            {
                entity.HasKey(e => new { e.Provincia, e.Canton });

                entity.ToTable("tbCanton");

                entity.Property(e => e.Provincia).HasMaxLength(1);

                entity.Property(e => e.Canton).HasMaxLength(2);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProvinciaNavigation)
                    .WithMany(p => p.TbCanton)
                    .HasForeignKey(d => d.Provincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCanton_tbProvincia");
            });

            modelBuilder.Entity<TbCategoriaProducto>(entity =>
            {
                entity.ToTable("tbCategoriaProducto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fotocategoria)
                    .HasColumnName("fotocategoria")
                    .HasMaxLength(2000);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TbClientes>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TipoId });

                entity.ToTable("tbClientes");

                entity.HasIndex(e => e.TipoCliente)
                    .HasName("IX_FK_tbClientes_tbTipoClientes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(30);

                entity.Property(e => e.TipoId).HasColumnName("tipoId");

                entity.Property(e => e.Contacto)
                    .HasColumnName("contacto")
                    .HasMaxLength(50);

                entity.Property(e => e.CorreoElectConta)
                    .HasColumnName("correoElectConta")
                    .HasMaxLength(50);

                entity.Property(e => e.CreditoMax).HasColumnName("creditoMax");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.DescuentoMax).HasColumnName("descuentoMax");

                entity.Property(e => e.EncargadoConta)
                    .HasColumnName("encargadoConta")
                    .HasMaxLength(50);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdExonercion)
                    .HasColumnName("idExonercion")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NombreTributario)
                    .HasColumnName("nombreTributario")
                    .HasMaxLength(50);

                entity.Property(e => e.PlazoCreditoMax).HasColumnName("plazoCreditoMax");

                entity.Property(e => e.PrecioAplicar)
                    .HasColumnName("precioAplicar")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TipoCliente).HasColumnName("tipoCliente");

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltCrea)
                    .IsRequired()
                    .HasColumnName("usuario_ult_crea")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdExonercionNavigation)
                    .WithMany(p => p.TbClientes)
                    .HasForeignKey(d => d.IdExonercion)
                    .HasConstraintName("FK_tbClientes_tbExoneraciones");

                entity.HasOne(d => d.TipoClienteNavigation)
                    .WithMany(p => p.TbClientes)
                    .HasForeignKey(d => d.TipoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbClientes_tbTipoClientes");

                entity.HasOne(d => d.TbPersona)
                    .WithMany(p => p.TbClientes)
                    .HasForeignKey(d => new { d.TipoId, d.Id })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbClientes_tbPersona");
            });

            modelBuilder.Entity<TbCreditos>(entity =>
            {
                entity.HasKey(e => e.IdCredito);

                entity.ToTable("tbCreditos");

                entity.HasIndex(e => e.IdMov)
                    .HasName("IX_FK_tbCreditos_tbMovimientos");

                entity.HasIndex(e => new { e.IdCliente, e.TipoCliente })
                    .HasName("IX_FK_tbCreditos_tbClientes");

                entity.Property(e => e.IdCredito).HasColumnName("idCredito");

                entity.Property(e => e.EstadoCredito).HasColumnName("estadoCredito");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCliente)
                    .IsRequired()
                    .HasColumnName("idCliente")
                    .HasMaxLength(30);

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdMov).HasColumnName("idMov");

                entity.Property(e => e.MontoCredito)
                    .HasColumnName("montoCredito")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SaldoCredito)
                    .HasColumnName("saldoCredito")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TipoCliente).HasColumnName("tipoCliente");

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdMovNavigation)
                    .WithMany(p => p.TbCreditos)
                    .HasForeignKey(d => d.IdMov)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbCreditos_tbMovimientos");
            });

            modelBuilder.Entity<TbDetalleDocumento>(entity =>
            {
                entity.HasKey(e => new { e.IdTipoDoc, e.IdDoc, e.IdProducto });

                entity.ToTable("tbDetalleDocumento");

                entity.HasIndex(e => e.IdDoc)
                    .HasName("IX_FK_tbDetalleFactura_tbFactura");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("IX_FK_tbDetalleFactura_tbProducto");

                entity.Property(e => e.IdTipoDoc).HasColumnName("idTipoDoc");

                entity.Property(e => e.IdDoc).HasColumnName("idDoc");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("idProducto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Descuento).HasColumnName("descuento");

                entity.Property(e => e.MontoTotal).HasColumnName("montoTotal");

                entity.Property(e => e.MontoTotalDesc).HasColumnName("montoTotalDesc");

                entity.Property(e => e.MontoTotalExo).HasColumnName("montoTotalExo");

                entity.Property(e => e.MontoTotalImp).HasColumnName("montoTotalImp");

                entity.Property(e => e.NumLinea).HasColumnName("numLinea");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.TotalLinea).HasColumnName("totalLinea");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.TbDetalleDocumento)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDetalleFactura_tbProducto");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.TbDetalleDocumento)
                    .HasForeignKey(d => new { d.IdDoc, d.IdTipoDoc })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDetalleDocumento_tbDocumento");
            });

            modelBuilder.Entity<TbDetalleImpresion>(entity =>
            {
                entity.ToTable("tbDetalleImpresion");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DireccionEmpresa)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.LogoEmpresa)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.MensajeDespedida)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MensajeTributacion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEmpresa)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoEmpresa)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbDetalleMovimiento>(entity =>
            {
                entity.HasKey(e => new { e.IdDetalleMov, e.IdMov, e.IdIngrediente });

                entity.ToTable("tbDetalleMovimiento");

                entity.HasIndex(e => e.IdIngrediente)
                    .HasName("IX_FK_tbDetalleMovimiento_tbIngredientes");

                entity.HasIndex(e => e.IdMov)
                    .HasName("IX_FK_tbDetalleMovimiento_tbMovimientos");

                entity.Property(e => e.IdDetalleMov)
                    .HasColumnName("idDetalleMov")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdMov).HasColumnName("idMov");

                entity.Property(e => e.IdIngrediente).HasColumnName("idIngrediente");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Monto)
                    .HasColumnName("monto")
                    .HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.IdIngredienteNavigation)
                    .WithMany(p => p.TbDetalleMovimiento)
                    .HasForeignKey(d => d.IdIngrediente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDetalleMovimiento_tbIngredientes");

                entity.HasOne(d => d.IdMovNavigation)
                    .WithMany(p => p.TbDetalleMovimiento)
                    .HasForeignKey(d => d.IdMov)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDetalleMovimiento_tbMovimientos");
            });

            modelBuilder.Entity<TbDetalleProducto>(entity =>
            {
                entity.ToTable("tbDetalleProducto");

                entity.HasIndex(e => e.IdIngrediente)
                    .HasName("IX_FK_tbDetalleProducto_tbIngredientes");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("IX_FK_tbDetalleProducto_tbProducto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdIngrediente).HasColumnName("idIngrediente");

                entity.Property(e => e.IdProducto)
                    .IsRequired()
                    .HasColumnName("idProducto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdIngredienteNavigation)
                    .WithMany(p => p.TbDetalleProducto)
                    .HasForeignKey(d => d.IdIngrediente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDetalleProducto_tbIngredientes");
            });

            modelBuilder.Entity<TbDistrito>(entity =>
            {
                entity.HasKey(e => new { e.Provincia, e.Canton, e.Distrito });

                entity.ToTable("tbDistrito");

                entity.Property(e => e.Provincia).HasMaxLength(1);

                entity.Property(e => e.Canton).HasMaxLength(2);

                entity.Property(e => e.Distrito).HasMaxLength(2);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TbCanton)
                    .WithMany(p => p.TbDistrito)
                    .HasForeignKey(d => new { d.Provincia, d.Canton })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDistrito_tbCanton");
            });

            modelBuilder.Entity<TbDocumento>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TipoDocumento });

                entity.ToTable("tbDocumento");

                entity.HasIndex(e => new { e.IdCliente, e.TipoIdCliente })
                    .HasName("IX_FK_tbFactura_tbClientes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TipoDocumento).HasColumnName("tipoDocumento");

                entity.Property(e => e.Clave)
                    .HasColumnName("clave")
                    .HasMaxLength(50);

                entity.Property(e => e.ClaveRef)
                    .HasColumnName("claveRef")
                    .HasMaxLength(50);

                entity.Property(e => e.CodigoRef).HasColumnName("codigoRef");

                entity.Property(e => e.Consecutivo)
                    .HasColumnName("consecutivo")
                    .HasMaxLength(20);

                entity.Property(e => e.Correo1)
                    .HasColumnName("correo1")
                    .HasMaxLength(50);

                entity.Property(e => e.Correo2)
                    .HasColumnName("correo2")
                    .HasMaxLength(50);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.EstadoFactura).HasColumnName("estadoFactura");

                entity.Property(e => e.EstadoFacturaHacienda).HasMaxLength(50);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaRef)
                    .HasColumnName("fechaRef")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("idCliente")
                    .HasMaxLength(30);

                entity.Property(e => e.IdEmpresa)
                    .IsRequired()
                    .HasColumnName("idEmpresa")
                    .HasMaxLength(30);

                entity.Property(e => e.MensajeReporteHacienda)
                    .HasColumnName("mensajeReporteHacienda")
                    .HasMaxLength(50);

                entity.Property(e => e.MensajeRespHacienda).HasColumnName("mensajeRespHacienda");

                entity.Property(e => e.NotificarCorreo).HasColumnName("notificarCorreo");

                entity.Property(e => e.Observaciones)
                    .HasColumnName("observaciones")
                    .HasMaxLength(270);

                entity.Property(e => e.Plazo).HasColumnName("plazo");

                entity.Property(e => e.Razon)
                    .HasColumnName("razon")
                    .HasMaxLength(180);

                entity.Property(e => e.RefPago)
                    .HasColumnName("refPago")
                    .HasMaxLength(30);

                entity.Property(e => e.ReporteAceptaHacienda).HasColumnName("reporteAceptaHacienda");

                entity.Property(e => e.ReporteElectronic).HasColumnName("reporteElectronic");

                entity.Property(e => e.TipoCambio)
                    .HasColumnName("tipoCambio")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TipoDocRef).HasColumnName("tipoDocRef");

                entity.Property(e => e.TipoIdCliente).HasColumnName("tipoIdCliente");

                entity.Property(e => e.TipoIdEmpresa).HasColumnName("tipoIdEmpresa");

                entity.Property(e => e.TipoMoneda).HasColumnName("tipoMoneda");

                entity.Property(e => e.TipoPago).HasColumnName("tipoPago");

                entity.Property(e => e.TipoVenta).HasColumnName("tipoVenta");

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);

                entity.Property(e => e.XmlFirmado).HasColumnName("xmlFirmado");

                entity.Property(e => e.XmlRespuesta).HasColumnName("xmlRespuesta");

                entity.Property(e => e.XmlSinFirma).HasColumnName("xmlSinFirma");

                entity.HasOne(d => d.TipoDocumentoNavigation)
                    .WithMany(p => p.TbDocumento)
                    .HasForeignKey(d => d.TipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumento_tbTipoDocumento");

                entity.HasOne(d => d.TipoMonedaNavigation)
                    .WithMany(p => p.TbDocumento)
                    .HasForeignKey(d => d.TipoMoneda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumento_tbTipoMoneda");

                entity.HasOne(d => d.TipoPagoNavigation)
                    .WithMany(p => p.TbDocumento)
                    .HasForeignKey(d => d.TipoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumento_tbTipoPago");

                entity.HasOne(d => d.TipoVentaNavigation)
                    .WithMany(p => p.TbDocumento)
                    .HasForeignKey(d => d.TipoVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumento_tbTipoVenta");

                entity.HasOne(d => d.TbClientes)
                    .WithMany(p => p.TbDocumento)
                    .HasForeignKey(d => new { d.IdCliente, d.TipoIdCliente })
                    .HasConstraintName("FK_tbFactura_tbClientes");

                entity.HasOne(d => d.TbEmpresa)
                    .WithMany(p => p.TbDocumento)
                    .HasForeignKey(d => new { d.IdEmpresa, d.TipoIdEmpresa })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbDocumento_tbEmpresa");
            });

            modelBuilder.Entity<TbEmpleado>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TipoId });

                entity.ToTable("tbEmpleado");

                entity.HasIndex(e => e.IdPuesto)
                    .HasName("IX_FK_tbEmpleado_tbTipoPuesto");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(30);

                entity.Property(e => e.TipoId).HasColumnName("tipoId");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(500);

                entity.Property(e => e.EsContraDefinido).HasColumnName("esContraDefinido");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fecha_ingreso")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaSalida)
                    .HasColumnName("fecha_salida")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPuesto).HasColumnName("idPuesto");

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltCrea)
                    .IsRequired()
                    .HasColumnName("usuario_ult_crea")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdPuestoNavigation)
                    .WithMany(p => p.TbEmpleado)
                    .HasForeignKey(d => d.IdPuesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbEmpleado_tbTipoPuesto");

                entity.HasOne(d => d.TbPersona)
                    .WithMany(p => p.TbEmpleado)
                    .HasForeignKey(d => new { d.TipoId, d.Id })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbEmpleado_tbPersona");
            });

            modelBuilder.Entity<TbEmpresa>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TipoId });

                entity.ToTable("tbEmpresa");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(30);

                entity.Property(e => e.TipoId).HasColumnName("tipoId");

                entity.Property(e => e.AmbientePruebas).HasColumnName("ambientePruebas");

                entity.Property(e => e.CertificadoInstalado)
                    .HasColumnName("certificadoInstalado")
                    .HasMaxLength(100);

                entity.Property(e => e.ClaveApiHacienda)
                    .HasColumnName("claveApiHacienda")
                    .HasMaxLength(100);

                entity.Property(e => e.ContrasenaCorreo)
                    .HasColumnName("contrasenaCorreo")
                    .HasMaxLength(50);

                entity.Property(e => e.CorreoElectronicoEmpresa)
                    .HasColumnName("correoElectronicoEmpresa")
                    .HasMaxLength(50);

                entity.Property(e => e.CuerpoCorreo)
                    .HasColumnName("cuerpoCorreo")
                    .HasMaxLength(500);

                entity.Property(e => e.FechaCaducidad)
                    .HasColumnName("fechaCaducidad")
                    .HasColumnType("date");

                entity.Property(e => e.FechaResolucio).HasColumnName("fechaResolucio");

                entity.Property(e => e.ImprimeDoc).HasColumnName("imprimeDoc");

                entity.Property(e => e.NombreComercial)
                    .HasColumnName("nombreComercial")
                    .HasMaxLength(100);

                entity.Property(e => e.NumeroResolucion)
                    .HasColumnName("numeroResolucion")
                    .HasMaxLength(100);

                entity.Property(e => e.Pin).HasColumnName("pin");

                entity.Property(e => e.RazonSocial)
                    .HasColumnName("razonSocial")
                    .HasMaxLength(100);

                entity.Property(e => e.RutaCertificado)
                    .HasColumnName("rutaCertificado")
                    .HasMaxLength(100);

                entity.Property(e => e.RutaXmlcompras)
                    .HasColumnName("rutaXMLCompras")
                    .HasMaxLength(500);

                entity.Property(e => e.SubjectCorreo)
                    .HasColumnName("subjectCorreo")
                    .HasMaxLength(50);

                entity.Property(e => e.UsuarioApiHacienda)
                    .HasColumnName("usuarioApiHacienda")
                    .HasMaxLength(100);

                entity.HasOne(d => d.TbPersona)
                    .WithMany(p => p.TbEmpresa)
                    .HasForeignKey(d => new { d.TipoId, d.Id })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbEmpresa_tbPersona");
            });

            modelBuilder.Entity<TbExoneraciones>(entity =>
            {
                entity.ToTable("tbExoneraciones");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30);

                entity.Property(e => e.Valor).HasColumnName("valor");
            });

            modelBuilder.Entity<TbHorarioProveedor>(entity =>
            {
                entity.HasKey(e => new { e.IdTipo, e.IdProveedor, e.IdTipoHorario });

                entity.ToTable("tbHorarioProveedor");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.IdProveedor)
                    .HasColumnName("idProveedor")
                    .HasMaxLength(30);

                entity.Property(e => e.IdTipoHorario).HasColumnName("idTipoHorario");

                entity.Property(e => e.Domingo).HasColumnName("domingo");

                entity.Property(e => e.Jueves).HasColumnName("jueves");

                entity.Property(e => e.Lunes).HasColumnName("lunes");

                entity.Property(e => e.Martes).HasColumnName("martes");

                entity.Property(e => e.Miercoles).HasColumnName("miercoles");

                entity.Property(e => e.Sabado).HasColumnName("sabado");

                entity.Property(e => e.Viernes).HasColumnName("viernes");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.TbHorarioProveedor)
                    .HasForeignKey(d => new { d.IdProveedor, d.IdTipo })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbHorarioProveedor_tbProveedores");
            });

            modelBuilder.Entity<TbImpuestos>(entity =>
            {
                entity.ToTable("tbImpuestos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(30);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<TbIngredienteProveedor>(entity =>
            {
                entity.HasKey(e => new { e.TbIngredientesIdIngrediente, e.TbProveedoresId, e.TbProveedoresTipoId });

                entity.ToTable("tbIngredienteProveedor");

                entity.HasIndex(e => new { e.TbProveedoresId, e.TbProveedoresTipoId })
                    .HasName("IX_FK_tbIngredienteProveedor_tbProveedores");

                entity.Property(e => e.TbIngredientesIdIngrediente).HasColumnName("tbIngredientes_idIngrediente");

                entity.Property(e => e.TbProveedoresId)
                    .HasColumnName("tbProveedores_id")
                    .HasMaxLength(30);

                entity.Property(e => e.TbProveedoresTipoId).HasColumnName("tbProveedores_tipoId");

                entity.HasOne(d => d.TbIngredientesIdIngredienteNavigation)
                    .WithMany(p => p.TbIngredienteProveedor)
                    .HasForeignKey(d => d.TbIngredientesIdIngrediente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbIngredienteProveedor_tbIngredientes");
            });

            modelBuilder.Entity<TbIngredientes>(entity =>
            {
                entity.HasKey(e => e.IdIngrediente);

                entity.ToTable("tbIngredientes");

                entity.HasIndex(e => e.IdTipoIngrediente)
                    .HasName("IX_FK_tbIngredientes_tbTipoIngrediente");

                entity.HasIndex(e => e.IdTipoMedida)
                    .HasName("IX_FK_tbIngredientes_tbTipoMedidas");

                entity.Property(e => e.IdIngrediente).HasColumnName("idIngrediente");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdTipoIngrediente).HasColumnName("idTipoIngrediente");

                entity.Property(e => e.IdTipoMedida).HasColumnName("idTipoMedida");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.PrecioCompra)
                    .HasColumnName("precioCompra")
                    .HasColumnType("decimal(19, 4)");

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdTipoIngredienteNavigation)
                    .WithMany(p => p.TbIngredientes)
                    .HasForeignKey(d => d.IdTipoIngrediente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbIngredientes_tbTipoIngrediente");
            });

            modelBuilder.Entity<TbInventario>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("tbInventario");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("IX_FK_tbInventario_tbIngredientes");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("idProducto")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CantMax)
                    .HasColumnName("cant_max")
                    .HasColumnType("decimal(18, 1)");

                entity.Property(e => e.CantMin)
                    .HasColumnName("cant_min")
                    .HasColumnType("decimal(18, 1)");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("decimal(18, 1)");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TbMonedas>(entity =>
            {
                entity.HasKey(e => e.IdMoneda);

                entity.ToTable("tbMonedas");

                entity.HasIndex(e => e.IdTipoMoneda)
                    .HasName("IX_FK_tbMonedas_tbTipoMoneda");

                entity.Property(e => e.IdMoneda)
                    .HasColumnName("idMoneda")
                    .HasMaxLength(3)
                    .ValueGeneratedNever();

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdTipoMoneda).HasColumnName("idTipoMoneda");

                entity.Property(e => e.Moneda)
                    .IsRequired()
                    .HasColumnName("moneda")
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdTipoMonedaNavigation)
                    .WithMany(p => p.TbMonedas)
                    .HasForeignKey(d => d.IdTipoMoneda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMonedas_tbTipoMoneda");
            });

            modelBuilder.Entity<TbMovimientoCajaUsuario>(entity =>
            {
                entity.HasKey(e => new { e.TbCajaUsuarioId, e.TbMovimientosIdMovimiento });

                entity.ToTable("tbMovimientoCajaUsuario");

                entity.HasIndex(e => e.TbMovimientosIdMovimiento)
                    .HasName("IX_FK_tbMovimientoCajaUsuario_tbMovimientos");

                entity.Property(e => e.TbCajaUsuarioId).HasColumnName("tbCajaUsuario_id");

                entity.Property(e => e.TbMovimientosIdMovimiento).HasColumnName("tbMovimientos_idMovimiento");

                entity.HasOne(d => d.TbCajaUsuario)
                    .WithMany(p => p.TbMovimientoCajaUsuario)
                    .HasForeignKey(d => d.TbCajaUsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMovimientoCajaUsuario_tbCajaUsuario");

                entity.HasOne(d => d.TbMovimientosIdMovimientoNavigation)
                    .WithMany(p => p.TbMovimientoCajaUsuario)
                    .HasForeignKey(d => d.TbMovimientosIdMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMovimientoCajaUsuario_tbMovimientos");
            });

            modelBuilder.Entity<TbMovimientos>(entity =>
            {
                entity.HasKey(e => e.IdMovimiento);

                entity.ToTable("tbMovimientos");

                entity.HasIndex(e => e.IdTipoMov)
                    .HasName("IX_FK_tbMovimientos_tbTipoMovimiento");

                entity.Property(e => e.IdMovimiento).HasColumnName("idMovimiento");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdTipoMov).HasColumnName("idTipoMov");

                entity.Property(e => e.Motivo)
                    .HasColumnName("motivo")
                    .HasMaxLength(500);

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(19, 4)");

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdTipoMovNavigation)
                    .WithMany(p => p.TbMovimientos)
                    .HasForeignKey(d => d.IdTipoMov)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbMovimientos_tbTipoMovimiento");
            });

            modelBuilder.Entity<TbPagos>(entity =>
            {
                entity.ToTable("tbPagos");

                entity.HasIndex(e => e.IdMovimiento)
                    .HasName("IX_FK_tbPagos_tbMovimientos");

                entity.HasIndex(e => new { e.IdEmpleado, e.TipoId })
                    .HasName("IX_FK_tbPagos_tbEmpleado");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CantidadHoraExtra).HasColumnName("cantidad_horaExtra");

                entity.Property(e => e.CantidadHoras).HasColumnName("Cantidad_horas");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaPago)
                    .HasColumnName("fecha_pago")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEmpleado)
                    .IsRequired()
                    .HasColumnName("idEmpleado")
                    .HasMaxLength(30);

                entity.Property(e => e.IdMovimiento).HasColumnName("idMovimiento");

                entity.Property(e => e.TipoId).HasColumnName("tipoId");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdMovimientoNavigation)
                    .WithMany(p => p.TbPagos)
                    .HasForeignKey(d => d.IdMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbPagos_tbMovimientos");

                entity.HasOne(d => d.TbEmpleado)
                    .WithMany(p => p.TbPagos)
                    .HasForeignKey(d => new { d.IdEmpleado, d.TipoId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbPagos_tbEmpleado");
            });

            modelBuilder.Entity<TbParametrosEmpresa>(entity =>
            {
                entity.ToTable("tbParametrosEmpresa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AprobacionDescuento).HasColumnName("aprobacionDescuento");

                entity.Property(e => e.CambioDolar).HasColumnName("cambioDolar");

                entity.Property(e => e.ClienteObligatorioFact).HasColumnName("clienteObligatorioFact");

                entity.Property(e => e.DescuentoBase).HasColumnName("descuentoBase");

                entity.Property(e => e.FacturacionElectronica).HasColumnName("facturacionElectronica");

                entity.Property(e => e.IdEmpresa)
                    .IsRequired()
                    .HasColumnName("idEmpresa")
                    .HasMaxLength(30);

                entity.Property(e => e.IdTipoEmpresa).HasColumnName("idTipoEmpresa");

                entity.Property(e => e.ManejaInventario).HasColumnName("manejaInventario");

                entity.Property(e => e.PlazoMaximoCredito).HasColumnName("plazoMaximoCredito");

                entity.Property(e => e.PlazoMaximoProforma).HasColumnName("plazoMaximoProforma");

                entity.Property(e => e.PrecioBase).HasColumnName("precioBase");

                entity.Property(e => e.UtilidadBase).HasColumnName("utilidadBase");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.TbParametrosEmpresa)
                    .HasForeignKey(d => new { d.IdEmpresa, d.IdTipoEmpresa })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbParametrosEmpresa_tbEmpresa");
            });

            modelBuilder.Entity<TbPermisos>(entity =>
            {
                entity.HasKey(e => new { e.TbRequerimientosIdReq, e.TbRolesIdRol });

                entity.ToTable("tbPermisos");

                entity.HasIndex(e => e.TbRolesIdRol)
                    .HasName("IX_FK_tbPermisos_tbRoles");

                entity.Property(e => e.TbRequerimientosIdReq).HasColumnName("tbRequerimientos_idReq");

                entity.Property(e => e.TbRolesIdRol).HasColumnName("tbRoles_idRol");

                entity.HasOne(d => d.TbRequerimientosIdReqNavigation)
                    .WithMany(p => p.TbPermisos)
                    .HasForeignKey(d => d.TbRequerimientosIdReq)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbPermisos_tbRequerimientos");

                entity.HasOne(d => d.TbRolesIdRolNavigation)
                    .WithMany(p => p.TbPermisos)
                    .HasForeignKey(d => d.TbRolesIdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbPermisos_tbRoles");
            });

            modelBuilder.Entity<TbPersona>(entity =>
            {
                entity.HasKey(e => new { e.TipoId, e.Identificacion });

                entity.ToTable("tbPersona");

                entity.Property(e => e.TipoId).HasColumnName("tipoId");

                entity.Property(e => e.Identificacion)
                    .HasColumnName("identificacion")
                    .HasMaxLength(30);

                entity.Property(e => e.Apellido1)
                    .HasColumnName("apellido1")
                    .HasMaxLength(30);

                entity.Property(e => e.Apellido2)
                    .HasColumnName("apellido2")
                    .HasMaxLength(30);

                entity.Property(e => e.Barrio)
                    .HasColumnName("barrio")
                    .HasMaxLength(2);

                entity.Property(e => e.Canton)
                    .HasColumnName("canton")
                    .HasMaxLength(2);

                entity.Property(e => e.CodigoPaisFax)
                    .HasColumnName("codigoPaisFax")
                    .HasMaxLength(3);

                entity.Property(e => e.CodigoPaisTel)
                    .IsRequired()
                    .HasColumnName("codigoPaisTel")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("((506))");

                entity.Property(e => e.CorreoElectronico)
                    .HasColumnName("correoElectronico")
                    .HasMaxLength(50);

                entity.Property(e => e.Distrito)
                    .HasColumnName("distrito")
                    .HasMaxLength(2);

                entity.Property(e => e.Fax).HasColumnName("fax");

                entity.Property(e => e.FechaNac)
                    .HasColumnName("fechaNac")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100);

                entity.Property(e => e.OtrasSenas)
                    .HasColumnName("otrasSenas")
                    .HasMaxLength(500);

                entity.Property(e => e.Provincia)
                    .HasColumnName("provincia")
                    .HasMaxLength(1);

                entity.Property(e => e.Sexo).HasColumnName("sexo");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.HasOne(d => d.Tipo)
                    .WithMany(p => p.TbPersona)
                    .HasForeignKey(d => d.TipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbPersona_tbTipoId");

                entity.HasOne(d => d.TbBarrios)
                    .WithMany(p => p.TbPersona)
                    .HasForeignKey(d => new { d.Provincia, d.Canton, d.Distrito, d.Barrio })
                    .HasConstraintName("FK_tbPersona_tbBarrios");
            });

            modelBuilder.Entity<TbPersonasTribunalS>(entity =>
            {
                entity.ToTable("tbPersonasTribunalS");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido1)
                    .HasColumnName("APELLIDO1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .HasColumnName("APELLIDO2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Codigopostal)
                    .HasColumnName("CODIGOPOSTAL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasColumnName("SEXO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbProducto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("tbProducto");

                entity.HasIndex(e => e.IdCategoria)
                    .HasName("IX_FK_tbProducto_tbCategoriaProducto");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("idProducto")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AplicaDescuento).HasColumnName("aplicaDescuento");

                entity.Property(e => e.DescuentoMax)
                    .HasColumnName("descuento_max")
                    .HasColumnType("decimal(18, 1)");

                entity.Property(e => e.EsExento).HasColumnName("esExento");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.IdMedida).HasColumnName("idMedida");

                entity.Property(e => e.IdProveedor)
                    .HasColumnName("idProveedor")
                    .HasMaxLength(30);

                entity.Property(e => e.IdTipoIdProveedor).HasColumnName("idTipoIdProveedor");

                entity.Property(e => e.IdTipoImpuesto).HasColumnName("idTipoImpuesto");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(160);

                entity.Property(e => e.PrecioReal)
                    .HasColumnName("precio_real")
                    .HasColumnType("decimal(18, 1)");

                entity.Property(e => e.PrecioUtilidad1).HasColumnName("precioUtilidad1");

                entity.Property(e => e.PrecioUtilidad2).HasColumnName("precioUtilidad2");

                entity.Property(e => e.PrecioUtilidad3).HasColumnName("precioUtilidad3");

                entity.Property(e => e.PrecioVariable).HasColumnName("precioVariable");

                entity.Property(e => e.PrecioVenta1).HasColumnName("precioVenta1");

                entity.Property(e => e.PrecioVenta2).HasColumnName("precioVenta2");

                entity.Property(e => e.PrecioVenta3).HasColumnName("precioVenta3");

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);

                entity.Property(e => e.Utilidad1Porc)
                    .HasColumnName("utilidad1Porc")
                    .HasColumnType("decimal(18, 1)");

                entity.Property(e => e.Utilidad2Porc)
                    .HasColumnName("utilidad2Porc")
                    .HasColumnType("decimal(18, 1)");

                entity.Property(e => e.Utilidad3Porc)
                    .HasColumnName("utilidad3Porc")
                    .HasColumnType("decimal(18, 1)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.TbProducto)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbProducto_tbCategoriaProducto");

                entity.HasOne(d => d.IdMedidaNavigation)
                    .WithMany(p => p.TbProducto)
                    .HasForeignKey(d => d.IdMedida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbProducto_tbTipoMedidas");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithOne(p => p.TbProducto)
                    .HasForeignKey<TbProducto>(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbProducto_tbInventario");

                entity.HasOne(d => d.IdTipoImpuestoNavigation)
                    .WithMany(p => p.TbProducto)
                    .HasForeignKey(d => d.IdTipoImpuesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbProducto_tbImpuestos");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.TbProducto)
                    .HasForeignKey(d => new { d.IdProveedor, d.IdTipoIdProveedor })
                    .HasConstraintName("FK_tbProducto_tbProveedores");
            });

            modelBuilder.Entity<TbProveedores>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TipoId });

                entity.ToTable("tbProveedores");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(30);

                entity.Property(e => e.TipoId).HasColumnName("tipoId");

                entity.Property(e => e.ContactoProveedor)
                    .IsRequired()
                    .HasColumnName("contactoProveedor")
                    .HasMaxLength(150);

                entity.Property(e => e.CorreoElectConta)
                    .HasColumnName("correoElectConta")
                    .HasMaxLength(50);

                entity.Property(e => e.CuentaBancaria)
                    .HasColumnName("cuentaBancaria")
                    .HasMaxLength(50);

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.EncargadoConta)
                    .HasColumnName("encargadoConta")
                    .HasMaxLength(50);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(10);

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.NombreTributario)
                    .HasColumnName("nombreTributario")
                    .HasMaxLength(50);

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);

                entity.HasOne(d => d.TbPersona)
                    .WithMany(p => p.TbProveedores)
                    .HasForeignKey(d => new { d.TipoId, d.Id })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbProveedores_tbPersona");
            });

            modelBuilder.Entity<TbProvincia>(entity =>
            {
                entity.HasKey(e => e.Cod);

                entity.ToTable("tbProvincia");

                entity.HasIndex(e => e.Nombre)
                    .HasName("UQ__tbProvin__75E3EFCF25DA01E3")
                    .IsUnique();

                entity.Property(e => e.Cod)
                    .HasMaxLength(1)
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbReporteHacienda>(entity =>
            {
                entity.ToTable("tbReporteHacienda");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClaveDocEmisor)
                    .IsRequired()
                    .HasColumnName("claveDocEmisor")
                    .HasMaxLength(50);

                entity.Property(e => e.ClaveReceptor)
                    .IsRequired()
                    .HasColumnName("claveReceptor")
                    .HasMaxLength(50);

                entity.Property(e => e.ConsecutivoReceptor)
                    .IsRequired()
                    .HasColumnName("consecutivoReceptor")
                    .HasMaxLength(20);

                entity.Property(e => e.CorreoElectronico)
                    .HasColumnName("correoElectronico")
                    .HasMaxLength(50);

                entity.Property(e => e.EstadoRecibido).HasColumnName("estadoRecibido");

                entity.Property(e => e.EstadoRespHacienda).HasMaxLength(50);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaEmision)
                    .HasColumnName("fechaEmision")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEmisor)
                    .IsRequired()
                    .HasColumnName("idEmisor")
                    .HasMaxLength(30);

                entity.Property(e => e.IdEmpresa)
                    .IsRequired()
                    .HasColumnName("idEmpresa")
                    .HasMaxLength(30);

                entity.Property(e => e.MensajeReporteHacienda)
                    .HasColumnName("mensajeReporteHacienda")
                    .HasMaxLength(50);

                entity.Property(e => e.MensajeRespHacienda).HasColumnName("mensajeRespHacienda");

                entity.Property(e => e.NombreArchivo)
                    .HasColumnName("nombreArchivo")
                    .HasMaxLength(500);

                entity.Property(e => e.NombreEmisor)
                    .IsRequired()
                    .HasColumnName("nombreEmisor")
                    .HasMaxLength(160);

                entity.Property(e => e.Razon)
                    .HasColumnName("razon")
                    .HasMaxLength(160);

                entity.Property(e => e.ReporteAceptaHacienda).HasColumnName("reporteAceptaHacienda");

                entity.Property(e => e.RutaRespuestaHacienda)
                    .HasColumnName("rutaRespuestaHacienda")
                    .HasMaxLength(500);

                entity.Property(e => e.TipoIdEmisor).HasColumnName("tipoIdEmisor");

                entity.Property(e => e.TipoIdEmpresa).HasColumnName("tipoIdEmpresa");

                entity.Property(e => e.TotalFactura)
                    .HasColumnName("totalFactura")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalImp)
                    .HasColumnName("totalImp")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);

                entity.Property(e => e.XmlFirmado)
                    .HasColumnName("xmlFirmado")
                    .IsUnicode(false);

                entity.Property(e => e.XmlRespuesta).HasColumnName("xmlRespuesta");

                entity.Property(e => e.XmlSinFirma)
                    .HasColumnName("xmlSinFirma")
                    .IsUnicode(false);

                entity.HasOne(d => d.TbEmpresa)
                    .WithMany(p => p.TbReporteHacienda)
                    .HasForeignKey(d => new { d.IdEmpresa, d.TipoIdEmpresa })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbReporteHacienda_tbEmpresa");
            });

            modelBuilder.Entity<TbRequerimientos>(entity =>
            {
                entity.HasKey(e => e.IdReq);

                entity.ToTable("tbRequerimientos");

                entity.Property(e => e.IdReq).HasColumnName("idReq");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TbRoles>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("tbRoles");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TbSucursales>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdEmpresa, e.IdTipoEmpresa });

                entity.ToTable("tbSucursales");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdEmpresa)
                    .HasColumnName("idEmpresa")
                    .HasMaxLength(30);

                entity.Property(e => e.IdTipoEmpresa).HasColumnName("idTipoEmpresa");

                entity.Property(e => e.Canton)
                    .IsRequired()
                    .HasColumnName("canton")
                    .HasMaxLength(2);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(500);

                entity.Property(e => e.Distrito)
                    .IsRequired()
                    .HasColumnName("distrito")
                    .HasMaxLength(2);

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasColumnName("provincia")
                    .HasMaxLength(1);

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.TbSucursales)
                    .HasForeignKey(d => new { d.IdEmpresa, d.IdTipoEmpresa })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbSucursales_tbEmpresa");
            });

            modelBuilder.Entity<TbTipoClientes>(entity =>
            {
                entity.ToTable("tbTipoClientes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioCrea)
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TbTipoDocumento>(entity =>
            {
                entity.ToTable("tbTipoDocumento");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TbTipoId>(entity =>
            {
                entity.ToTable("tbTipoId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TbTipoIngrediente>(entity =>
            {
                entity.ToTable("tbTipoIngrediente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TbTipoMedidas>(entity =>
            {
                entity.HasKey(e => e.IdTipoMedida);

                entity.ToTable("tbTipoMedidas");

                entity.Property(e => e.IdTipoMedida).HasColumnName("idTipoMedida");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30);

                entity.Property(e => e.Nomenclatura)
                    .IsRequired()
                    .HasColumnName("nomenclatura")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TbTipoMoneda>(entity =>
            {
                entity.ToTable("tbTipoMoneda");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30);

                entity.Property(e => e.Siglas)
                    .IsRequired()
                    .HasColumnName("siglas")
                    .HasMaxLength(3);

                entity.Property(e => e.Simbolo)
                    .IsRequired()
                    .HasColumnName("simbolo")
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<TbTipoMovimiento>(entity =>
            {
                entity.HasKey(e => e.IdTipo);

                entity.ToTable("tbTipoMovimiento");

                entity.Property(e => e.IdTipo)
                    .HasColumnName("idTipo")
                    .ValueGeneratedNever();

                entity.Property(e => e.AfectaConta).HasColumnName("afecta_conta");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(30);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TbTipoPago>(entity =>
            {
                entity.ToTable("tbTipoPago");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TbTipoPuesto>(entity =>
            {
                entity.HasKey(e => e.IdTipoPuesto);

                entity.ToTable("tbTipoPuesto");

                entity.Property(e => e.IdTipoPuesto).HasColumnName("idTipoPuesto");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30);

                entity.Property(e => e.PrecioExt).HasColumnName("precio_ext");

                entity.Property(e => e.PrecioHora).HasColumnName("precio_hora");

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TbTipoVenta>(entity =>
            {
                entity.ToTable("tbTipoVenta");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TbUsuarios>(entity =>
            {
                entity.HasKey(e => new { e.TipoId, e.Id });

                entity.ToTable("tbUsuarios");

                entity.HasIndex(e => e.IdRol)
                    .HasName("IX_FK_tbUsuarios_tbRoles");

                entity.Property(e => e.TipoId).HasColumnName("tipoId");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(30);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasColumnName("contraseña")
                    .HasMaxLength(30);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaCrea)
                    .HasColumnName("fecha_crea")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaUltMod)
                    .HasColumnName("fecha_ult_mod")
                    .HasColumnType("datetime");

                entity.Property(e => e.FotoUrl)
                    .HasColumnName("foto_url")
                    .HasMaxLength(500);

                entity.Property(e => e.IdEmpresa)
                    .IsRequired()
                    .HasColumnName("idEmpresa")
                    .HasMaxLength(30);

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.IdTipoIdEmpresa).HasColumnName("idTipoIdEmpresa");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasColumnName("nombreUsuario")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioCrea)
                    .IsRequired()
                    .HasColumnName("usuario_crea")
                    .HasMaxLength(30);

                entity.Property(e => e.UsuarioUltMod)
                    .IsRequired()
                    .HasColumnName("usuario_ult_mod")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.TbUsuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUsuarios_tbRoles");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.TbUsuarios)
                    .HasForeignKey(d => new { d.IdEmpresa, d.IdTipoIdEmpresa })
                    .HasConstraintName("FK_tbUsuarios_tbEmpresa");

                entity.HasOne(d => d.TbPersona)
                    .WithOne(p => p.TbUsuarios)
                    .HasForeignKey<TbUsuarios>(d => new { d.TipoId, d.Id })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbUsuarios_tbPersona");
            });
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUser<string>>();

        }
    }
}
