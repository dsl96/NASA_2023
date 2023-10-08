using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class astronaut5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Astronauts_Status_statusid",
                table: "Astronauts");

            migrationBuilder.DropForeignKey(
                name: "FK_Astronauts_Type_typeid",
                table: "Astronauts");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Astronauts_statusid",
                table: "Astronauts");

            migrationBuilder.DropIndex(
                name: "IX_Astronauts_typeid",
                table: "Astronauts");

            migrationBuilder.DropColumn(
                name: "statusid",
                table: "Astronauts");

            migrationBuilder.DropColumn(
                name: "image_url",
                table: "Agency");

            migrationBuilder.RenameColumn(
                name: "typeid",
                table: "Astronauts",
                newName: "status_stausId");

            migrationBuilder.AddColumn<string>(
                name: "status_StatusName",
                table: "Astronauts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status_StatusName",
                table: "Astronauts");

            migrationBuilder.RenameColumn(
                name: "status_stausId",
                table: "Astronauts",
                newName: "typeid");

            migrationBuilder.AddColumn<int>(
                name: "statusid",
                table: "Astronauts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "image_url",
                table: "Agency",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Astronauts_statusid",
                table: "Astronauts",
                column: "statusid");

            migrationBuilder.CreateIndex(
                name: "IX_Astronauts_typeid",
                table: "Astronauts",
                column: "typeid");

            migrationBuilder.AddForeignKey(
                name: "FK_Astronauts_Status_statusid",
                table: "Astronauts",
                column: "statusid",
                principalTable: "Status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Astronauts_Type_typeid",
                table: "Astronauts",
                column: "typeid",
                principalTable: "Type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
