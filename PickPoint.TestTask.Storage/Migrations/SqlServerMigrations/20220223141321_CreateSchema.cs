using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickPoint.TestTask.Storage.Migrations.SqlServerMigrations
{
    public partial class CreateSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pp");

            migrationBuilder.CreateTable(
                name: "PickUpPoints",
                schema: "pp",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickUpPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "pp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RecipientPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    RecipientFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickUpPointId = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_PickUpPoints_PickUpPointId",
                        column: x => x.PickUpPointId,
                        principalSchema: "pp",
                        principalTable: "PickUpPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                schema: "pp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "pp",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                schema: "pp",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PickUpPointId",
                schema: "pp",
                table: "Orders",
                column: "PickUpPointId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts",
                schema: "pp");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "pp");

            migrationBuilder.DropTable(
                name: "PickUpPoints",
                schema: "pp");
        }
    }
}
