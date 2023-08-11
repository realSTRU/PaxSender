using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PaxSender.Migrations.ContextoMigrations
{
    /// <inheritdoc />
    public partial class Incial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Almacen",
                columns: table => new
                {
                    AlmacenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Identificador = table.Column<string>(type: "TEXT", nullable: false),
                    Visible = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacen", x => x.AlmacenId);
                });

            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SuplidorId = table.Column<int>(type: "INTEGER", nullable: false),
                    AlmacenId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Costo = table.Column<double>(type: "REAL", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: true),
                    Peso = table.Column<double>(type: "REAL", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    Num_Reorden = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha_Entrada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Fecha_Caducidad = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Visible = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.ArticuloId);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Visible = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Celular = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: false),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    Correo = table.Column<string>(type: "TEXT", nullable: true),
                    RNC = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha_Registro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Visible = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    OrdenID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: true),
                    cantidad_anterior = table.Column<int>(type: "INTEGER", nullable: true),
                    cantidad_Resultante = table.Column<int>(type: "INTEGER", nullable: true),
                    Razon = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Visible = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada", x => x.OrdenID);
                });

            migrationBuilder.CreateTable(
                name: "Envio",
                columns: table => new
                {
                    EnvioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SucursalId = table.Column<int>(type: "INTEGER", nullable: false),
                    Destino = table.Column<string>(type: "TEXT", nullable: true),
                    Total = table.Column<double>(type: "REAL", nullable: true),
                    Total_Envio = table.Column<double>(type: "REAL", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    Destinatario_Referencia = table.Column<string>(type: "TEXT", nullable: false),
                    Visible = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envio", x => x.EnvioId);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SucursalId = table.Column<int>(type: "INTEGER", nullable: false),
                    Destino = table.Column<string>(type: "TEXT", nullable: true),
                    Total = table.Column<double>(type: "REAL", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    Visible = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.PedidoId);
                });

            migrationBuilder.CreateTable(
                name: "Salida",
                columns: table => new
                {
                    OrdenID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: true),
                    cantidad_anterior = table.Column<int>(type: "INTEGER", nullable: true),
                    cantidad_Resultante = table.Column<int>(type: "INTEGER", nullable: true),
                    Razon = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Visible = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salida", x => x.OrdenID);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    SucursalId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha_Registro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Visible = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.SucursalId);
                });

            migrationBuilder.CreateTable(
                name: "Suplidor",
                columns: table => new
                {
                    SuplidorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Celular = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    RNC = table.Column<string>(type: "TEXT", nullable: true),
                    Correo = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha_Registro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Visible = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplidor", x => x.SuplidorId);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    VentaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SuplidorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Total = table.Column<double>(type: "REAL", nullable: true),
                    Visible = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.VentaId);
                });

            migrationBuilder.CreateTable(
                name: "EnvioDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PedidoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Costo = table.Column<double>(type: "REAL", nullable: false),
                    Peso = table.Column<double>(type: "REAL", nullable: false),
                    Etiqueta = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvioDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_EnvioDetalle_Envio_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Envio",
                        principalColumn: "EnvioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PedidoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_PedidoDetalle_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentaDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompraId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: true),
                    Visible = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_VentaDetalle_Venta_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Venta",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Almacen",
                columns: new[] { "AlmacenId", "Identificador", "Visible" },
                values: new object[] { 1, "ALMACEN GENERAL", true });

            migrationBuilder.InsertData(
                table: "Articulo",
                columns: new[] { "ArticuloId", "AlmacenId", "CategoriaId", "Costo", "Descripcion", "Estado", "Existencia", "Fecha_Caducidad", "Fecha_Entrada", "Num_Reorden", "Peso", "Precio", "SuplidorId", "Visible" },
                values: new object[] { 1, 1, 4, 0.0, "PAQUETE", "ACTIVO", 10000000, new DateTime(2023, 8, 11, 3, 58, 34, 991, DateTimeKind.Local).AddTicks(6775), new DateTime(2023, 8, 11, 3, 58, 34, 991, DateTimeKind.Local).AddTicks(6767), 10, 0.0, 0.0, 1, true });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Visible" },
                values: new object[,]
                {
                    { 1, "Inmuebles", true },
                    { 2, "Alimentos", true },
                    { 3, "Ropa", true },
                    { 4, "PaxSenderCategory", true }
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "Cedula", "Celular", "Correo", "Direccion", "Fecha_Registro", "Nombre", "RNC", "Telefono", "Visible" },
                values: new object[] { 1, null, "0", null, "0", new DateTime(2023, 8, 11, 3, 58, 34, 991, DateTimeKind.Local).AddTicks(6492), "GENERAL", null, null, true });

            migrationBuilder.InsertData(
                table: "Sucursal",
                columns: new[] { "SucursalId", "Direccion", "Fecha_Registro", "Nombre", "Visible" },
                values: new object[] { 1, "NAGUA RD", new DateTime(2023, 8, 11, 3, 58, 34, 991, DateTimeKind.Local).AddTicks(6804), "Principal DO", true });

            migrationBuilder.InsertData(
                table: "Suplidor",
                columns: new[] { "SuplidorId", "Celular", "Correo", "Direccion", "Fecha_Registro", "Nombre", "RNC", "Telefono", "Visible" },
                values: new object[] { 1, "0", "PaxSender.Net", "PaxSenderMainDireccion", new DateTime(2023, 8, 11, 3, 58, 34, 991, DateTimeKind.Local).AddTicks(6536), "PaxSenderEssensials", "MainRNC", "0", true });

            migrationBuilder.CreateIndex(
                name: "IX_EnvioDetalle_PedidoId",
                table: "EnvioDetalle",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalle_PedidoId",
                table: "PedidoDetalle",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDetalle_CompraId",
                table: "VentaDetalle",
                column: "CompraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Almacen");

            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Entrada");

            migrationBuilder.DropTable(
                name: "EnvioDetalle");

            migrationBuilder.DropTable(
                name: "PedidoDetalle");

            migrationBuilder.DropTable(
                name: "Salida");

            migrationBuilder.DropTable(
                name: "Sucursal");

            migrationBuilder.DropTable(
                name: "Suplidor");

            migrationBuilder.DropTable(
                name: "VentaDetalle");

            migrationBuilder.DropTable(
                name: "Envio");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Venta");
        }
    }
}
