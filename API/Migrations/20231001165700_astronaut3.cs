using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class astronaut3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agency",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    featured = table.Column<bool>(type: "bit", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    abbrev = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    administrator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    founding_year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    launchers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spacecraft = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logo_url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "Astronauts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    statusid = table.Column<int>(type: "int", nullable: false),
                    typeid = table.Column<int>(type: "int", nullable: false),
                    in_space = table.Column<bool>(type: "bit", nullable: false),
                    time_in_space = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eva_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_of_death = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    twitter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    instagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wiki = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agencyid = table.Column<int>(type: "int", nullable: false),
                    profile_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    profile_image_thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    flights_count = table.Column<int>(type: "int", nullable: false),
                    landings_count = table.Column<int>(type: "int", nullable: false),
                    spacewalks_count = table.Column<int>(type: "int", nullable: false),
                    last_flight = table.Column<DateTime>(type: "datetime2", nullable: false),
                    first_flight = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Astronauts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Astronauts_Agency_agencyid",
                        column: x => x.agencyid,
                        principalTable: "Agency",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Astronauts_Status_statusid",
                        column: x => x.statusid,
                        principalTable: "Status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Astronauts_Type_typeid",
                        column: x => x.typeid,
                        principalTable: "Type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Astronauts_agencyid",
                table: "Astronauts",
                column: "agencyid");

            migrationBuilder.CreateIndex(
                name: "IX_Astronauts_statusid",
                table: "Astronauts",
                column: "statusid");

            migrationBuilder.CreateIndex(
                name: "IX_Astronauts_typeid",
                table: "Astronauts",
                column: "typeid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Astronauts");

            migrationBuilder.DropTable(
                name: "Agency");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Type");
        }
    }
}
