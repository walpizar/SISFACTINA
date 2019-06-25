using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppFacturadorApi.Data.Migrations
{
    public partial class nueva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    pub_id = table.Column<string>(unicode: false, maxLength: 4, nullable: false),
                    pub_name = table.Column<string>(unicode: false, maxLength: 40, nullable: true),
                    city = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    state = table.Column<string>(unicode: false, maxLength: 2, nullable: true),
                    country = table.Column<string>(unicode: false, maxLength: 30, nullable: true, defaultValueSql: "('USA')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.pub_id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbAbonos",
                columns: table => new
                {
                    idAbono = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idDoc = table.Column<int>(nullable: false),
                    tipoDoc = table.Column<int>(nullable: false),
                    monto = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false),
                    estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAbonos", x => x.idAbono);
                });

            migrationBuilder.CreateTable(
                name: "tbCategoriaProducto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(maxLength: 30, nullable: false),
                    descripcion = table.Column<string>(maxLength: 500, nullable: true),
                    fotocategoria = table.Column<string>(maxLength: 2000, nullable: true),
                    estado = table.Column<bool>(nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategoriaProducto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbDetalleImpresion",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    NombreEmpresa = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    TelefonoEmpresa = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    DireccionEmpresa = table.Column<string>(maxLength: 1000, nullable: false),
                    MensajeTributacion = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    MensajeDespedida = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    LogoEmpresa = table.Column<string>(unicode: false, maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDetalleImpresion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbExoneraciones",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(maxLength: 30, nullable: true),
                    descripcion = table.Column<string>(maxLength: 500, nullable: true),
                    valor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbExoneraciones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbImpuestos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    valor = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    descripcion = table.Column<string>(maxLength: 30, nullable: true),
                    estado = table.Column<bool>(nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbImpuestos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbInventario",
                columns: table => new
                {
                    idProducto = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    cantidad = table.Column<decimal>(type: "decimal(18, 1)", nullable: false),
                    cant_min = table.Column<decimal>(type: "decimal(18, 1)", nullable: true),
                    cant_max = table.Column<decimal>(type: "decimal(18, 1)", nullable: true),
                    estado = table.Column<bool>(nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbInventario", x => x.idProducto);
                });

            migrationBuilder.CreateTable(
                name: "tbPersonasTribunalS",
                columns: table => new
                {
                    ID = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    CODIGOPOSTAL = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    SEXO = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    NOMBRE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    APELLIDO1 = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    APELLIDO2 = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPersonasTribunalS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbProvincia",
                columns: table => new
                {
                    Cod = table.Column<string>(maxLength: 1, nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProvincia", x => x.Cod);
                });

            migrationBuilder.CreateTable(
                name: "tbRequerimientos",
                columns: table => new
                {
                    idReq = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(maxLength: 30, nullable: false),
                    descripcion = table.Column<string>(maxLength: 500, nullable: true),
                    estado = table.Column<bool>(nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbRequerimientos", x => x.idReq);
                });

            migrationBuilder.CreateTable(
                name: "tbRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    idRol = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(maxLength: 30, nullable: false),
                    descripcion = table.Column<string>(maxLength: 500, nullable: true),
                    estado = table.Column<bool>(nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbRoles", x => x.idRol);
                });

            migrationBuilder.CreateTable(
                name: "tbTipoClientes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(maxLength: 30, nullable: true),
                    descripcion = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    estado = table.Column<bool>(nullable: true),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: true),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: true),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: true),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTipoClientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbTipoDocumento",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTipoDocumento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbTipoId",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTipoId", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbTipoIngrediente",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(maxLength: 30, nullable: false),
                    descripcion = table.Column<string>(maxLength: 500, nullable: true),
                    estado = table.Column<bool>(nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTipoIngrediente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbTipoMedidas",
                columns: table => new
                {
                    idTipoMedida = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(maxLength: 30, nullable: false),
                    nomenclatura = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    descripcion = table.Column<string>(maxLength: 500, nullable: true),
                    estado = table.Column<bool>(nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTipoMedidas", x => x.idTipoMedida);
                });

            migrationBuilder.CreateTable(
                name: "tbTipoMoneda",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(maxLength: 30, nullable: false),
                    siglas = table.Column<string>(maxLength: 3, nullable: false),
                    simbolo = table.Column<string>(maxLength: 1, nullable: false),
                    estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTipoMoneda", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbTipoMovimiento",
                columns: table => new
                {
                    idTipo = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(maxLength: 30, nullable: false),
                    descripcion = table.Column<string>(maxLength: 30, nullable: true),
                    afecta_conta = table.Column<short>(nullable: false),
                    estado = table.Column<bool>(nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTipoMovimiento", x => x.idTipo);
                });

            migrationBuilder.CreateTable(
                name: "tbTipoPago",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTipoPago", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbTipoPuesto",
                columns: table => new
                {
                    idTipoPuesto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(maxLength: 30, nullable: false),
                    descripcion = table.Column<string>(maxLength: 500, nullable: true),
                    precio_hora = table.Column<double>(nullable: true),
                    precio_ext = table.Column<double>(nullable: true),
                    estado = table.Column<bool>(nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTipoPuesto", x => x.idTipoPuesto);
                });

            migrationBuilder.CreateTable(
                name: "tbTipoVenta",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTipoVenta", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbCanton",
                columns: table => new
                {
                    Provincia = table.Column<string>(maxLength: 1, nullable: false),
                    Canton = table.Column<string>(maxLength: 2, nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCanton", x => new { x.Provincia, x.Canton });
                    table.ForeignKey(
                        name: "FK_tbCanton_tbProvincia",
                        column: x => x.Provincia,
                        principalTable: "tbProvincia",
                        principalColumn: "Cod",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbPermisos",
                columns: table => new
                {
                    tbRequerimientos_idReq = table.Column<int>(nullable: false),
                    tbRoles_idRol = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPermisos", x => new { x.tbRequerimientos_idReq, x.tbRoles_idRol });
                    table.ForeignKey(
                        name: "FK_tbPermisos_tbRequerimientos",
                        column: x => x.tbRequerimientos_idReq,
                        principalTable: "tbRequerimientos",
                        principalColumn: "idReq",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbPermisos_tbRoles",
                        column: x => x.tbRoles_idRol,
                        principalTable: "tbRoles",
                        principalColumn: "idRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbIngredientes",
                columns: table => new
                {
                    idIngrediente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(maxLength: 50, nullable: false),
                    idTipoMedida = table.Column<int>(nullable: false),
                    idTipoIngrediente = table.Column<int>(nullable: false),
                    precioCompra = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    estado = table.Column<bool>(nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbIngredientes", x => x.idIngrediente);
                    table.ForeignKey(
                        name: "FK_tbIngredientes_tbTipoIngrediente",
                        column: x => x.idTipoIngrediente,
                        principalTable: "tbTipoIngrediente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbMonedas",
                columns: table => new
                {
                    idMoneda = table.Column<string>(maxLength: 3, nullable: false),
                    moneda = table.Column<string>(maxLength: 10, nullable: false),
                    idTipoMoneda = table.Column<int>(nullable: false),
                    estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMonedas", x => x.idMoneda);
                    table.ForeignKey(
                        name: "FK_tbMonedas_tbTipoMoneda",
                        column: x => x.idTipoMoneda,
                        principalTable: "tbTipoMoneda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbMovimientos",
                columns: table => new
                {
                    idMovimiento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    idTipoMov = table.Column<int>(nullable: false),
                    estado = table.Column<bool>(nullable: false),
                    motivo = table.Column<string>(maxLength: 500, nullable: true),
                    total = table.Column<decimal>(type: "decimal(19, 4)", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMovimientos", x => x.idMovimiento);
                    table.ForeignKey(
                        name: "FK_tbMovimientos_tbTipoMovimiento",
                        column: x => x.idTipoMov,
                        principalTable: "tbTipoMovimiento",
                        principalColumn: "idTipo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbDistrito",
                columns: table => new
                {
                    Provincia = table.Column<string>(maxLength: 1, nullable: false),
                    Canton = table.Column<string>(maxLength: 2, nullable: false),
                    Distrito = table.Column<string>(maxLength: 2, nullable: false),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDistrito", x => new { x.Provincia, x.Canton, x.Distrito });
                    table.ForeignKey(
                        name: "FK_tbDistrito_tbCanton",
                        columns: x => new { x.Provincia, x.Canton },
                        principalTable: "tbCanton",
                        principalColumns: new[] { "Provincia", "Canton" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbDetalleProducto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idProducto = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    idIngrediente = table.Column<int>(nullable: false),
                    cantidad = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDetalleProducto", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbDetalleProducto_tbIngredientes",
                        column: x => x.idIngrediente,
                        principalTable: "tbIngredientes",
                        principalColumn: "idIngrediente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbIngredienteProveedor",
                columns: table => new
                {
                    tbIngredientes_idIngrediente = table.Column<int>(nullable: false),
                    tbProveedores_id = table.Column<string>(maxLength: 30, nullable: false),
                    tbProveedores_tipoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbIngredienteProveedor", x => new { x.tbIngredientes_idIngrediente, x.tbProveedores_id, x.tbProveedores_tipoId });
                    table.ForeignKey(
                        name: "FK_tbIngredienteProveedor_tbIngredientes",
                        column: x => x.tbIngredientes_idIngrediente,
                        principalTable: "tbIngredientes",
                        principalColumn: "idIngrediente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbCreditos",
                columns: table => new
                {
                    idCredito = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idCliente = table.Column<string>(maxLength: 30, nullable: false),
                    tipoCliente = table.Column<int>(nullable: true),
                    idMov = table.Column<int>(nullable: false),
                    idEstado = table.Column<bool>(nullable: false),
                    estadoCredito = table.Column<bool>(nullable: false),
                    montoCredito = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false),
                    saldoCredito = table.Column<decimal>(type: "decimal(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCreditos", x => x.idCredito);
                    table.ForeignKey(
                        name: "FK_tbCreditos_tbMovimientos",
                        column: x => x.idMov,
                        principalTable: "tbMovimientos",
                        principalColumn: "idMovimiento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbDetalleMovimiento",
                columns: table => new
                {
                    idDetalleMov = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idMov = table.Column<int>(nullable: false),
                    idIngrediente = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: false),
                    monto = table.Column<decimal>(type: "decimal(19, 4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDetalleMovimiento", x => new { x.idDetalleMov, x.idMov, x.idIngrediente });
                    table.ForeignKey(
                        name: "FK_tbDetalleMovimiento_tbIngredientes",
                        column: x => x.idIngrediente,
                        principalTable: "tbIngredientes",
                        principalColumn: "idIngrediente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbDetalleMovimiento_tbMovimientos",
                        column: x => x.idMov,
                        principalTable: "tbMovimientos",
                        principalColumn: "idMovimiento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbBarrios",
                columns: table => new
                {
                    Provincia = table.Column<string>(maxLength: 1, nullable: false),
                    canton = table.Column<string>(maxLength: 2, nullable: false),
                    distrito = table.Column<string>(maxLength: 2, nullable: false),
                    barrio = table.Column<string>(maxLength: 2, nullable: false),
                    nombre = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBarrios", x => new { x.Provincia, x.canton, x.distrito, x.barrio });
                    table.ForeignKey(
                        name: "FK_tbBarrios_tbDistrito",
                        columns: x => new { x.Provincia, x.canton, x.distrito },
                        principalTable: "tbDistrito",
                        principalColumns: new[] { "Provincia", "Canton", "Distrito" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbPersona",
                columns: table => new
                {
                    tipoId = table.Column<int>(nullable: false),
                    identificacion = table.Column<string>(maxLength: 30, nullable: false),
                    nombre = table.Column<string>(maxLength: 100, nullable: false),
                    apellido1 = table.Column<string>(maxLength: 30, nullable: true),
                    apellido2 = table.Column<string>(maxLength: 30, nullable: true),
                    correoElectronico = table.Column<string>(maxLength: 50, nullable: true),
                    fechaNac = table.Column<DateTime>(type: "datetime", nullable: true),
                    sexo = table.Column<int>(nullable: true),
                    codigoPaisTel = table.Column<string>(maxLength: 10, nullable: false, defaultValueSql: "((506))"),
                    telefono = table.Column<int>(nullable: false),
                    codigoPaisFax = table.Column<string>(maxLength: 3, nullable: true),
                    fax = table.Column<int>(nullable: true),
                    provincia = table.Column<string>(maxLength: 1, nullable: true),
                    canton = table.Column<string>(maxLength: 2, nullable: true),
                    distrito = table.Column<string>(maxLength: 2, nullable: true),
                    barrio = table.Column<string>(maxLength: 2, nullable: true),
                    otrasSenas = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPersona", x => new { x.tipoId, x.identificacion });
                    table.ForeignKey(
                        name: "FK_tbPersona_tbTipoId",
                        column: x => x.tipoId,
                        principalTable: "tbTipoId",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbPersona_tbBarrios",
                        columns: x => new { x.provincia, x.canton, x.distrito, x.barrio },
                        principalTable: "tbBarrios",
                        principalColumns: new[] { "Provincia", "canton", "distrito", "barrio" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbClientes",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 30, nullable: false),
                    tipoId = table.Column<int>(nullable: false),
                    tipoCliente = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(maxLength: 500, nullable: true),
                    estado = table.Column<bool>(nullable: false),
                    precioAplicar = table.Column<int>(nullable: false, defaultValueSql: "((1))"),
                    descuentoMax = table.Column<int>(nullable: false),
                    creditoMax = table.Column<int>(nullable: false),
                    plazoCreditoMax = table.Column<int>(nullable: false),
                    nombreTributario = table.Column<string>(maxLength: 50, nullable: true),
                    encargadoConta = table.Column<string>(maxLength: 50, nullable: true),
                    correoElectConta = table.Column<string>(maxLength: 50, nullable: true),
                    idExonercion = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_crea = table.Column<string>(maxLength: 30, nullable: false),
                    contacto = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbClientes", x => new { x.id, x.tipoId });
                    table.ForeignKey(
                        name: "FK_tbClientes_tbExoneraciones",
                        column: x => x.idExonercion,
                        principalTable: "tbExoneraciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbClientes_tbTipoClientes",
                        column: x => x.tipoCliente,
                        principalTable: "tbTipoClientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbClientes_tbPersona",
                        columns: x => new { x.tipoId, x.id },
                        principalTable: "tbPersona",
                        principalColumns: new[] { "tipoId", "identificacion" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbEmpleado",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 30, nullable: false),
                    tipoId = table.Column<int>(nullable: false),
                    idPuesto = table.Column<int>(nullable: false),
                    fecha_ingreso = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_salida = table.Column<DateTime>(type: "datetime", nullable: true),
                    estado = table.Column<bool>(nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_crea = table.Column<string>(maxLength: 30, nullable: false),
                    esContraDefinido = table.Column<bool>(nullable: false),
                    direccion = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEmpleado", x => new { x.id, x.tipoId });
                    table.ForeignKey(
                        name: "FK_tbEmpleado_tbTipoPuesto",
                        column: x => x.idPuesto,
                        principalTable: "tbTipoPuesto",
                        principalColumn: "idTipoPuesto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbEmpleado_tbPersona",
                        columns: x => new { x.tipoId, x.id },
                        principalTable: "tbPersona",
                        principalColumns: new[] { "tipoId", "identificacion" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbEmpresa",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 30, nullable: false),
                    tipoId = table.Column<int>(nullable: false),
                    razonSocial = table.Column<string>(maxLength: 100, nullable: true),
                    certificadoInstalado = table.Column<string>(maxLength: 100, nullable: true),
                    rutaCertificado = table.Column<string>(maxLength: 100, nullable: true),
                    pin = table.Column<int>(nullable: true),
                    usuarioApiHacienda = table.Column<string>(maxLength: 100, nullable: true),
                    claveApiHacienda = table.Column<string>(maxLength: 100, nullable: true),
                    numeroResolucion = table.Column<string>(maxLength: 100, nullable: true),
                    fechaResolucio = table.Column<DateTime>(nullable: true),
                    correoElectronicoEmpresa = table.Column<string>(maxLength: 50, nullable: true),
                    contrasenaCorreo = table.Column<string>(maxLength: 50, nullable: true),
                    nombreComercial = table.Column<string>(maxLength: 100, nullable: true),
                    cuerpoCorreo = table.Column<string>(maxLength: 500, nullable: true),
                    subjectCorreo = table.Column<string>(maxLength: 50, nullable: true),
                    fechaCaducidad = table.Column<DateTime>(type: "date", nullable: true),
                    ambientePruebas = table.Column<bool>(nullable: true),
                    rutaXMLCompras = table.Column<string>(maxLength: 500, nullable: true),
                    imprimeDoc = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEmpresa", x => new { x.id, x.tipoId });
                    table.ForeignKey(
                        name: "FK_tbEmpresa_tbPersona",
                        columns: x => new { x.tipoId, x.id },
                        principalTable: "tbPersona",
                        principalColumns: new[] { "tipoId", "identificacion" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbProveedores",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 30, nullable: false),
                    tipoId = table.Column<int>(nullable: false),
                    descripcion = table.Column<string>(maxLength: 500, nullable: true),
                    contactoProveedor = table.Column<string>(maxLength: 150, nullable: false),
                    fax = table.Column<string>(maxLength: 10, nullable: true),
                    nombreTributario = table.Column<string>(maxLength: 50, nullable: true),
                    encargadoConta = table.Column<string>(maxLength: 50, nullable: true),
                    correoElectConta = table.Column<string>(maxLength: 50, nullable: true),
                    cuentaBancaria = table.Column<string>(maxLength: 50, nullable: true),
                    estado = table.Column<bool>(nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProveedores", x => new { x.id, x.tipoId });
                    table.ForeignKey(
                        name: "FK_tbProveedores_tbPersona",
                        columns: x => new { x.tipoId, x.id },
                        principalTable: "tbPersona",
                        principalColumns: new[] { "tipoId", "identificacion" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbPagos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idEmpleado = table.Column<string>(maxLength: 30, nullable: false),
                    tipoId = table.Column<int>(nullable: false),
                    Cantidad_horas = table.Column<int>(nullable: false),
                    cantidad_horaExtra = table.Column<int>(nullable: true),
                    total = table.Column<float>(nullable: false),
                    fecha_pago = table.Column<DateTime>(type: "datetime", nullable: false),
                    descripcion = table.Column<string>(maxLength: 500, nullable: true),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false),
                    idMovimiento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPagos", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbPagos_tbMovimientos",
                        column: x => x.idMovimiento,
                        principalTable: "tbMovimientos",
                        principalColumn: "idMovimiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbPagos_tbEmpleado",
                        columns: x => new { x.idEmpleado, x.tipoId },
                        principalTable: "tbEmpleado",
                        principalColumns: new[] { "id", "tipoId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbDocumento",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    tipoDocumento = table.Column<int>(nullable: false),
                    consecutivo = table.Column<string>(maxLength: 20, nullable: true),
                    clave = table.Column<string>(maxLength: 50, nullable: true),
                    reporteElectronic = table.Column<bool>(nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    idCliente = table.Column<string>(maxLength: 30, nullable: true),
                    tipoIdCliente = table.Column<int>(nullable: true),
                    tipoVenta = table.Column<int>(nullable: false),
                    plazo = table.Column<int>(nullable: true),
                    tipoPago = table.Column<int>(nullable: false),
                    refPago = table.Column<string>(maxLength: 30, nullable: true),
                    tipoMoneda = table.Column<int>(nullable: false),
                    tipoCambio = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    estadoFactura = table.Column<int>(nullable: false),
                    EstadoFacturaHacienda = table.Column<string>(maxLength: 50, nullable: true),
                    reporteAceptaHacienda = table.Column<bool>(nullable: false),
                    mensajeReporteHacienda = table.Column<string>(maxLength: 50, nullable: true),
                    mensajeRespHacienda = table.Column<bool>(nullable: true),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false),
                    estado = table.Column<bool>(nullable: false),
                    notificarCorreo = table.Column<bool>(nullable: false),
                    correo1 = table.Column<string>(maxLength: 50, nullable: true),
                    correo2 = table.Column<string>(maxLength: 50, nullable: true),
                    observaciones = table.Column<string>(maxLength: 270, nullable: true),
                    idEmpresa = table.Column<string>(maxLength: 30, nullable: false),
                    tipoIdEmpresa = table.Column<int>(nullable: false),
                    tipoDocRef = table.Column<int>(nullable: true),
                    claveRef = table.Column<string>(maxLength: 50, nullable: true),
                    fechaRef = table.Column<DateTime>(type: "datetime", nullable: true),
                    codigoRef = table.Column<int>(nullable: true),
                    razon = table.Column<string>(maxLength: 180, nullable: true),
                    xmlSinFirma = table.Column<string>(nullable: true),
                    xmlFirmado = table.Column<string>(nullable: true),
                    xmlRespuesta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDocumento", x => new { x.id, x.tipoDocumento });
                    table.ForeignKey(
                        name: "FK_tbDocumento_tbTipoDocumento",
                        column: x => x.tipoDocumento,
                        principalTable: "tbTipoDocumento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbDocumento_tbTipoMoneda",
                        column: x => x.tipoMoneda,
                        principalTable: "tbTipoMoneda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbDocumento_tbTipoPago",
                        column: x => x.tipoPago,
                        principalTable: "tbTipoPago",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbDocumento_tbTipoVenta",
                        column: x => x.tipoVenta,
                        principalTable: "tbTipoVenta",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbFactura_tbClientes",
                        columns: x => new { x.idCliente, x.tipoIdCliente },
                        principalTable: "tbClientes",
                        principalColumns: new[] { "id", "tipoId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbDocumento_tbEmpresa",
                        columns: x => new { x.idEmpresa, x.tipoIdEmpresa },
                        principalTable: "tbEmpresa",
                        principalColumns: new[] { "id", "tipoId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbParametrosEmpresa",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idEmpresa = table.Column<string>(maxLength: 30, nullable: false),
                    idTipoEmpresa = table.Column<int>(nullable: false),
                    utilidadBase = table.Column<float>(nullable: false),
                    manejaInventario = table.Column<bool>(nullable: false),
                    cambioDolar = table.Column<decimal>(nullable: true),
                    descuentoBase = table.Column<decimal>(nullable: true),
                    aprobacionDescuento = table.Column<bool>(nullable: true),
                    precioBase = table.Column<int>(nullable: true),
                    facturacionElectronica = table.Column<bool>(nullable: true),
                    clienteObligatorioFact = table.Column<bool>(nullable: true),
                    plazoMaximoCredito = table.Column<int>(nullable: true),
                    plazoMaximoProforma = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbParametrosEmpresa", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbParametrosEmpresa_tbEmpresa",
                        columns: x => new { x.idEmpresa, x.idTipoEmpresa },
                        principalTable: "tbEmpresa",
                        principalColumns: new[] { "id", "tipoId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbReporteHacienda",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    consecutivoReceptor = table.Column<string>(maxLength: 20, nullable: false),
                    claveReceptor = table.Column<string>(maxLength: 50, nullable: false),
                    claveDocEmisor = table.Column<string>(maxLength: 50, nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    fechaEmision = table.Column<DateTime>(type: "datetime", nullable: false),
                    tipoIdEmisor = table.Column<int>(nullable: false),
                    idEmisor = table.Column<string>(maxLength: 30, nullable: false),
                    nombreEmisor = table.Column<string>(maxLength: 160, nullable: false),
                    EstadoRespHacienda = table.Column<string>(maxLength: 50, nullable: true),
                    reporteAceptaHacienda = table.Column<bool>(nullable: false),
                    mensajeReporteHacienda = table.Column<string>(maxLength: 50, nullable: true),
                    mensajeRespHacienda = table.Column<bool>(nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false),
                    estadoRecibido = table.Column<int>(nullable: false),
                    razon = table.Column<string>(maxLength: 160, nullable: true),
                    totalImp = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    totalFactura = table.Column<decimal>(type: "decimal(18, 0)", nullable: false),
                    idEmpresa = table.Column<string>(maxLength: 30, nullable: false),
                    tipoIdEmpresa = table.Column<int>(nullable: false),
                    nombreArchivo = table.Column<string>(maxLength: 500, nullable: true),
                    rutaRespuestaHacienda = table.Column<string>(maxLength: 500, nullable: true),
                    xmlSinFirma = table.Column<string>(unicode: false, nullable: true),
                    xmlFirmado = table.Column<string>(unicode: false, nullable: true),
                    xmlRespuesta = table.Column<string>(nullable: true),
                    correoElectronico = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbReporteHacienda", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbReporteHacienda_tbEmpresa",
                        columns: x => new { x.idEmpresa, x.tipoIdEmpresa },
                        principalTable: "tbEmpresa",
                        principalColumns: new[] { "id", "tipoId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbSucursales",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idEmpresa = table.Column<string>(maxLength: 30, nullable: false),
                    idTipoEmpresa = table.Column<int>(nullable: false),
                    provincia = table.Column<string>(maxLength: 1, nullable: false),
                    canton = table.Column<string>(maxLength: 2, nullable: false),
                    distrito = table.Column<string>(maxLength: 2, nullable: false),
                    direccion = table.Column<string>(maxLength: 500, nullable: true),
                    telefono = table.Column<int>(nullable: true),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false),
                    nombre = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbSucursales", x => new { x.id, x.idEmpresa, x.idTipoEmpresa });
                    table.ForeignKey(
                        name: "FK_tbSucursales_tbEmpresa",
                        columns: x => new { x.idEmpresa, x.idTipoEmpresa },
                        principalTable: "tbEmpresa",
                        principalColumns: new[] { "id", "tipoId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbSucursales_tbDistrito",
                        columns: x => new { x.provincia, x.canton, x.distrito },
                        principalTable: "tbDistrito",
                        principalColumns: new[] { "Provincia", "Canton", "Distrito" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbUsuarios",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    tipoId = table.Column<int>(nullable: false),
                    id = table.Column<string>(maxLength: 30, nullable: false),
                    nombreUsuario = table.Column<string>(maxLength: 30, nullable: false),
                    contraseña = table.Column<string>(maxLength: 30, nullable: false),
                    idRol = table.Column<int>(nullable: false),
                    foto_url = table.Column<string>(maxLength: 500, nullable: true),
                    idEmpresa = table.Column<string>(maxLength: 30, nullable: false),
                    idTipoIdEmpresa = table.Column<int>(nullable: true),
                    estado = table.Column<bool>(nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUsuarios", x => new { x.tipoId, x.id });
                    table.ForeignKey(
                        name: "FK_tbUsuarios_tbRoles",
                        column: x => x.idRol,
                        principalTable: "tbRoles",
                        principalColumn: "idRol",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbUsuarios_tbEmpresa",
                        columns: x => new { x.idEmpresa, x.idTipoIdEmpresa },
                        principalTable: "tbEmpresa",
                        principalColumns: new[] { "id", "tipoId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbUsuarios_tbPersona",
                        columns: x => new { x.tipoId, x.id },
                        principalTable: "tbPersona",
                        principalColumns: new[] { "tipoId", "identificacion" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbHorarioProveedor",
                columns: table => new
                {
                    idTipo = table.Column<int>(nullable: false),
                    idProveedor = table.Column<string>(maxLength: 30, nullable: false),
                    idTipoHorario = table.Column<int>(nullable: false),
                    lunes = table.Column<bool>(nullable: true),
                    martes = table.Column<bool>(nullable: true),
                    miercoles = table.Column<bool>(nullable: true),
                    jueves = table.Column<bool>(nullable: true),
                    viernes = table.Column<bool>(nullable: true),
                    sabado = table.Column<bool>(nullable: true),
                    domingo = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbHorarioProveedor", x => new { x.idTipo, x.idProveedor, x.idTipoHorario });
                    table.ForeignKey(
                        name: "FK_tbHorarioProveedor_tbProveedores",
                        columns: x => new { x.idProveedor, x.idTipo },
                        principalTable: "tbProveedores",
                        principalColumns: new[] { "id", "tipoId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbProducto",
                columns: table => new
                {
                    idProducto = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    nombre = table.Column<string>(maxLength: 160, nullable: false),
                    id_categoria = table.Column<int>(nullable: false),
                    idProveedor = table.Column<string>(maxLength: 30, nullable: true),
                    idMedida = table.Column<int>(nullable: false),
                    idTipoIdProveedor = table.Column<int>(nullable: true),
                    precioVariable = table.Column<bool>(nullable: true),
                    precioUtilidad1 = table.Column<decimal>(nullable: true),
                    precioUtilidad2 = table.Column<decimal>(nullable: true),
                    precioUtilidad3 = table.Column<decimal>(nullable: true),
                    precioVenta1 = table.Column<decimal>(nullable: false),
                    precioVenta2 = table.Column<decimal>(nullable: false),
                    precioVenta3 = table.Column<decimal>(nullable: false),
                    utilidad1Porc = table.Column<decimal>(type: "decimal(18, 1)", nullable: false),
                    utilidad3Porc = table.Column<decimal>(type: "decimal(18, 1)", nullable: false),
                    utilidad2Porc = table.Column<decimal>(type: "decimal(18, 1)", nullable: false),
                    precio_real = table.Column<decimal>(type: "decimal(18, 1)", nullable: false),
                    esExento = table.Column<bool>(nullable: false),
                    idTipoImpuesto = table.Column<int>(nullable: false),
                    aplicaDescuento = table.Column<bool>(nullable: true),
                    foto = table.Column<string>(unicode: false, maxLength: 2000, nullable: true),
                    descuento_max = table.Column<decimal>(type: "decimal(18, 1)", nullable: true),
                    estado = table.Column<bool>(nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProducto", x => x.idProducto);
                    table.ForeignKey(
                        name: "FK_tbProducto_tbCategoriaProducto",
                        column: x => x.id_categoria,
                        principalTable: "tbCategoriaProducto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbProducto_tbTipoMedidas",
                        column: x => x.idMedida,
                        principalTable: "tbTipoMedidas",
                        principalColumn: "idTipoMedida",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbProducto_tbInventario",
                        column: x => x.idProducto,
                        principalTable: "tbInventario",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbProducto_tbImpuestos",
                        column: x => x.idTipoImpuesto,
                        principalTable: "tbImpuestos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbProducto_tbProveedores",
                        columns: x => new { x.idProveedor, x.idTipoIdProveedor },
                        principalTable: "tbProveedores",
                        principalColumns: new[] { "id", "tipoId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbCajas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(maxLength: 30, nullable: false),
                    descripcion = table.Column<string>(maxLength: 500, nullable: true),
                    estado = table.Column<bool>(nullable: false),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false),
                    idEmpresa = table.Column<string>(maxLength: 30, nullable: false),
                    idTipoEmpresa = table.Column<int>(nullable: false),
                    idSucursal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCajas", x => new { x.id, x.idEmpresa, x.idTipoEmpresa, x.idSucursal });
                    table.ForeignKey(
                        name: "FK_tbCajas_tbSucursales",
                        columns: x => new { x.idSucursal, x.idEmpresa, x.idTipoEmpresa },
                        principalTable: "tbSucursales",
                        principalColumns: new[] { "id", "idEmpresa", "idTipoEmpresa" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbCajaUsuario",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idCaja = table.Column<int>(nullable: false),
                    idUser = table.Column<string>(maxLength: 30, nullable: false),
                    tipoId = table.Column<int>(nullable: false),
                    tipoMovCaja = table.Column<int>(nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    total = table.Column<int>(nullable: true),
                    fecha_crea = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_ult_mod = table.Column<DateTime>(type: "datetime", nullable: false),
                    usuario_crea = table.Column<string>(maxLength: 30, nullable: false),
                    usuario_ult_mod = table.Column<string>(maxLength: 30, nullable: false),
                    estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCajaUsuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbCajaUsuario_tbUsuarios",
                        columns: x => new { x.tipoId, x.idUser },
                        principalTable: "tbUsuarios",
                        principalColumns: new[] { "tipoId", "id" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbDetalleDocumento",
                columns: table => new
                {
                    idTipoDoc = table.Column<int>(nullable: false),
                    idDoc = table.Column<int>(nullable: false),
                    idProducto = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    numLinea = table.Column<int>(nullable: false),
                    cantidad = table.Column<decimal>(nullable: false),
                    precio = table.Column<decimal>(nullable: false),
                    montoTotal = table.Column<decimal>(nullable: false),
                    descuento = table.Column<decimal>(nullable: false),
                    montoTotalDesc = table.Column<decimal>(nullable: false),
                    montoTotalImp = table.Column<decimal>(nullable: false),
                    montoTotalExo = table.Column<decimal>(nullable: false),
                    totalLinea = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDetalleDocumento", x => new { x.idTipoDoc, x.idDoc, x.idProducto });
                    table.ForeignKey(
                        name: "FK_tbDetalleFactura_tbProducto",
                        column: x => x.idProducto,
                        principalTable: "tbProducto",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbDetalleDocumento_tbDocumento",
                        columns: x => new { x.idDoc, x.idTipoDoc },
                        principalTable: "tbDocumento",
                        principalColumns: new[] { "id", "tipoDocumento" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbCajaUsuMonedas",
                columns: table => new
                {
                    idMoneda = table.Column<string>(maxLength: 3, nullable: false),
                    idCajaUsuario = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: false),
                    subtotal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCajaUsuMonedas", x => new { x.idMoneda, x.idCajaUsuario });
                    table.ForeignKey(
                        name: "FK_tbCajaUsuMonedas_tbCajaUsuario",
                        column: x => x.idCajaUsuario,
                        principalTable: "tbCajaUsuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbCajaUsuMonedas_tbMonedas",
                        column: x => x.idMoneda,
                        principalTable: "tbMonedas",
                        principalColumn: "idMoneda",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbMovimientoCajaUsuario",
                columns: table => new
                {
                    tbCajaUsuario_id = table.Column<int>(nullable: false),
                    tbMovimientos_idMovimiento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbMovimientoCajaUsuario", x => new { x.tbCajaUsuario_id, x.tbMovimientos_idMovimiento });
                    table.ForeignKey(
                        name: "FK_tbMovimientoCajaUsuario_tbCajaUsuario",
                        column: x => x.tbCajaUsuario_id,
                        principalTable: "tbCajaUsuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbMovimientoCajaUsuario_tbMovimientos",
                        column: x => x.tbMovimientos_idMovimiento,
                        principalTable: "tbMovimientos",
                        principalColumn: "idMovimiento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbAbonos_tbCreditos",
                table: "tbAbonos",
                column: "idDoc");

            migrationBuilder.CreateIndex(
                name: "IX_tbCajas_idSucursal_idEmpresa_idTipoEmpresa",
                table: "tbCajas",
                columns: new[] { "idSucursal", "idEmpresa", "idTipoEmpresa" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbCajaUsuario_tbCajas",
                table: "tbCajaUsuario",
                column: "idCaja");

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbCajaUsuario_tbUsuarios",
                table: "tbCajaUsuario",
                columns: new[] { "tipoId", "idUser" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbCajaUsuMonedas_tbCajaUsuario",
                table: "tbCajaUsuMonedas",
                column: "idCajaUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tbClientes_idExonercion",
                table: "tbClientes",
                column: "idExonercion");

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbClientes_tbTipoClientes",
                table: "tbClientes",
                column: "tipoCliente");

            migrationBuilder.CreateIndex(
                name: "IX_tbClientes_tipoId_id",
                table: "tbClientes",
                columns: new[] { "tipoId", "id" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbCreditos_tbMovimientos",
                table: "tbCreditos",
                column: "idMov");

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbCreditos_tbClientes",
                table: "tbCreditos",
                columns: new[] { "idCliente", "tipoCliente" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbDetalleFactura_tbFactura",
                table: "tbDetalleDocumento",
                column: "idDoc");

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbDetalleFactura_tbProducto",
                table: "tbDetalleDocumento",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_tbDetalleDocumento_idDoc_idTipoDoc",
                table: "tbDetalleDocumento",
                columns: new[] { "idDoc", "idTipoDoc" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbDetalleMovimiento_tbIngredientes",
                table: "tbDetalleMovimiento",
                column: "idIngrediente");

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbDetalleMovimiento_tbMovimientos",
                table: "tbDetalleMovimiento",
                column: "idMov");

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbDetalleProducto_tbIngredientes",
                table: "tbDetalleProducto",
                column: "idIngrediente");

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbDetalleProducto_tbProducto",
                table: "tbDetalleProducto",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_tbDocumento_tipoDocumento",
                table: "tbDocumento",
                column: "tipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_tbDocumento_tipoMoneda",
                table: "tbDocumento",
                column: "tipoMoneda");

            migrationBuilder.CreateIndex(
                name: "IX_tbDocumento_tipoPago",
                table: "tbDocumento",
                column: "tipoPago");

            migrationBuilder.CreateIndex(
                name: "IX_tbDocumento_tipoVenta",
                table: "tbDocumento",
                column: "tipoVenta");

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbFactura_tbClientes",
                table: "tbDocumento",
                columns: new[] { "idCliente", "tipoIdCliente" });

            migrationBuilder.CreateIndex(
                name: "IX_tbDocumento_idEmpresa_tipoIdEmpresa",
                table: "tbDocumento",
                columns: new[] { "idEmpresa", "tipoIdEmpresa" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbEmpleado_tbTipoPuesto",
                table: "tbEmpleado",
                column: "idPuesto");

            migrationBuilder.CreateIndex(
                name: "IX_tbEmpleado_tipoId_id",
                table: "tbEmpleado",
                columns: new[] { "tipoId", "id" });

            migrationBuilder.CreateIndex(
                name: "IX_tbEmpresa_tipoId_id",
                table: "tbEmpresa",
                columns: new[] { "tipoId", "id" });

            migrationBuilder.CreateIndex(
                name: "IX_tbHorarioProveedor_idProveedor_idTipo",
                table: "tbHorarioProveedor",
                columns: new[] { "idProveedor", "idTipo" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbIngredienteProveedor_tbProveedores",
                table: "tbIngredienteProveedor",
                columns: new[] { "tbProveedores_id", "tbProveedores_tipoId" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbIngredientes_tbTipoIngrediente",
                table: "tbIngredientes",
                column: "idTipoIngrediente");

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbIngredientes_tbTipoMedidas",
                table: "tbIngredientes",
                column: "idTipoMedida");

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbInventario_tbIngredientes",
                table: "tbInventario",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbMonedas_tbTipoMoneda",
                table: "tbMonedas",
                column: "idTipoMoneda");

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbMovimientoCajaUsuario_tbMovimientos",
                table: "tbMovimientoCajaUsuario",
                column: "tbMovimientos_idMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbMovimientos_tbTipoMovimiento",
                table: "tbMovimientos",
                column: "idTipoMov");

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbPagos_tbMovimientos",
                table: "tbPagos",
                column: "idMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbPagos_tbEmpleado",
                table: "tbPagos",
                columns: new[] { "idEmpleado", "tipoId" });

            migrationBuilder.CreateIndex(
                name: "IX_tbParametrosEmpresa_idEmpresa_idTipoEmpresa",
                table: "tbParametrosEmpresa",
                columns: new[] { "idEmpresa", "idTipoEmpresa" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbPermisos_tbRoles",
                table: "tbPermisos",
                column: "tbRoles_idRol");

            migrationBuilder.CreateIndex(
                name: "IX_tbPersona_provincia_canton_distrito_barrio",
                table: "tbPersona",
                columns: new[] { "provincia", "canton", "distrito", "barrio" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbProducto_tbCategoriaProducto",
                table: "tbProducto",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_tbProducto_idMedida",
                table: "tbProducto",
                column: "idMedida");

            migrationBuilder.CreateIndex(
                name: "IX_tbProducto_idTipoImpuesto",
                table: "tbProducto",
                column: "idTipoImpuesto");

            migrationBuilder.CreateIndex(
                name: "IX_tbProducto_idProveedor_idTipoIdProveedor",
                table: "tbProducto",
                columns: new[] { "idProveedor", "idTipoIdProveedor" });

            migrationBuilder.CreateIndex(
                name: "IX_tbProveedores_tipoId_id",
                table: "tbProveedores",
                columns: new[] { "tipoId", "id" });

            migrationBuilder.CreateIndex(
                name: "UQ__tbProvin__75E3EFCF25DA01E3",
                table: "tbProvincia",
                column: "Nombre",
                unique: true,
                filter: "([Nombre] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_tbReporteHacienda_idEmpresa_tipoIdEmpresa",
                table: "tbReporteHacienda",
                columns: new[] { "idEmpresa", "tipoIdEmpresa" });

            migrationBuilder.CreateIndex(
                name: "IX_tbSucursales_idEmpresa_idTipoEmpresa",
                table: "tbSucursales",
                columns: new[] { "idEmpresa", "idTipoEmpresa" });

            migrationBuilder.CreateIndex(
                name: "IX_tbSucursales_provincia_canton_distrito",
                table: "tbSucursales",
                columns: new[] { "provincia", "canton", "distrito" });

            migrationBuilder.CreateIndex(
                name: "IX_FK_tbUsuarios_tbRoles",
                table: "tbUsuarios",
                column: "idRol");

            migrationBuilder.CreateIndex(
                name: "IX_tbUsuarios_idEmpresa_idTipoIdEmpresa",
                table: "tbUsuarios",
                columns: new[] { "idEmpresa", "idTipoIdEmpresa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "publishers");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "tbAbonos");

            migrationBuilder.DropTable(
                name: "tbCajas");

            migrationBuilder.DropTable(
                name: "tbCajaUsuMonedas");

            migrationBuilder.DropTable(
                name: "tbCreditos");

            migrationBuilder.DropTable(
                name: "tbDetalleDocumento");

            migrationBuilder.DropTable(
                name: "tbDetalleImpresion");

            migrationBuilder.DropTable(
                name: "tbDetalleMovimiento");

            migrationBuilder.DropTable(
                name: "tbDetalleProducto");

            migrationBuilder.DropTable(
                name: "tbHorarioProveedor");

            migrationBuilder.DropTable(
                name: "tbIngredienteProveedor");

            migrationBuilder.DropTable(
                name: "tbMovimientoCajaUsuario");

            migrationBuilder.DropTable(
                name: "tbPagos");

            migrationBuilder.DropTable(
                name: "tbParametrosEmpresa");

            migrationBuilder.DropTable(
                name: "tbPermisos");

            migrationBuilder.DropTable(
                name: "tbPersonasTribunalS");

            migrationBuilder.DropTable(
                name: "tbReporteHacienda");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "tbSucursales");

            migrationBuilder.DropTable(
                name: "tbMonedas");

            migrationBuilder.DropTable(
                name: "tbProducto");

            migrationBuilder.DropTable(
                name: "tbDocumento");

            migrationBuilder.DropTable(
                name: "tbIngredientes");

            migrationBuilder.DropTable(
                name: "tbCajaUsuario");

            migrationBuilder.DropTable(
                name: "tbMovimientos");

            migrationBuilder.DropTable(
                name: "tbEmpleado");

            migrationBuilder.DropTable(
                name: "tbRequerimientos");

            migrationBuilder.DropTable(
                name: "tbCategoriaProducto");

            migrationBuilder.DropTable(
                name: "tbTipoMedidas");

            migrationBuilder.DropTable(
                name: "tbInventario");

            migrationBuilder.DropTable(
                name: "tbImpuestos");

            migrationBuilder.DropTable(
                name: "tbProveedores");

            migrationBuilder.DropTable(
                name: "tbTipoDocumento");

            migrationBuilder.DropTable(
                name: "tbTipoMoneda");

            migrationBuilder.DropTable(
                name: "tbTipoPago");

            migrationBuilder.DropTable(
                name: "tbTipoVenta");

            migrationBuilder.DropTable(
                name: "tbClientes");

            migrationBuilder.DropTable(
                name: "tbTipoIngrediente");

            migrationBuilder.DropTable(
                name: "tbUsuarios");

            migrationBuilder.DropTable(
                name: "tbTipoMovimiento");

            migrationBuilder.DropTable(
                name: "tbTipoPuesto");

            migrationBuilder.DropTable(
                name: "tbExoneraciones");

            migrationBuilder.DropTable(
                name: "tbTipoClientes");

            migrationBuilder.DropTable(
                name: "tbRoles");

            migrationBuilder.DropTable(
                name: "tbEmpresa");

            migrationBuilder.DropTable(
                name: "tbPersona");

            migrationBuilder.DropTable(
                name: "tbTipoId");

            migrationBuilder.DropTable(
                name: "tbBarrios");

            migrationBuilder.DropTable(
                name: "tbDistrito");

            migrationBuilder.DropTable(
                name: "tbCanton");

            migrationBuilder.DropTable(
                name: "tbProvincia");
        }
    }
}
