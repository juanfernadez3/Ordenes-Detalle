using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrdenesDeCompra.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CLienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CLienteId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Precio = table.Column<decimal>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    OrdenId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteID = table.Column<int>(nullable: false),
                    FechaOrden = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    ClientesCLienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.OrdenId);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_ClientesCLienteId",
                        column: x => x.ClientesCLienteId,
                        principalTable: "Clientes",
                        principalColumn: "CLienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenDetalle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductoId = table.Column<int>(nullable: false),
                    OrdenId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDetalle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrdenDetalle_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDetalle_OrdenId",
                table: "OrdenDetalle",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_ClientesCLienteId",
                table: "Ordenes",
                column: "ClientesCLienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenDetalle");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
