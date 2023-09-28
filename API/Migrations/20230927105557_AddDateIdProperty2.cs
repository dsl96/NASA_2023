using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddDateIdProperty2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NasaDailyImages",
                table: "NasaDailyImages");

            migrationBuilder.DeleteData(
                table: "NasaDailyImages",
                keyColumn: "Date",
                keyValue: new DateTime(2023, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DateId",
                table: "NasaDailyImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NasaDailyImages",
                table: "NasaDailyImages",
                column: "DateId");

            migrationBuilder.InsertData(
                table: "NasaDailyImages",
                columns: new[] { "DateId", "Copyright", "Date", "Explanation", "HdUrl", "MediaType", "ServiceVersion", "Title", "Url" },
                values: new object[] { 20230927, "Theresa Clarke", new DateTime(2023, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not every road ends in a STEVE. A week ago, a sky enthusiast's journey began with a goal: to photograph an aurora over Lake Huron. Driving through rural Ontario, Canada, the forecasted sky show started unexpectedly early, causing the photographer to stop before arriving at the scenic Great Lake. Aurora images were taken toward the north -- but over land, not sea. While waiting for a second round of auroras, a peculiar band of light was noticed to the west.  Slowly, the photographer and friends realized that this western band was likely an unusual type of aurora: a Strong Thermal Emission Velocity Enhancement (STEVE). Moreover, this STEVE was putting on quite a show: appearing intertwined with the central band of our Milky Way Galaxy while intersecting the horizon just near the end of the country road. After capturing this cosmic X on camera, the photographer paused to appreciate the unexpected awesomeness of finding extraordinary beauty in an ordinary setting.     Your Sky Surprise: What picture did APOD feature on your birthday? (post 1995)", "https://apod.nasa.gov/apod/image/2309/SteveMw_Clarke_4177.jpg", "image", "v1", "STEVE and Milky Way Cross over Rural Road", "https://apod.nasa.gov/apod/image/2309/SteveMw_Clarke_960.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NasaDailyImages",
                table: "NasaDailyImages");

            migrationBuilder.DeleteData(
                table: "NasaDailyImages",
                keyColumn: "DateId",
                keyColumnType: "int",
                keyValue: 20230927);

            migrationBuilder.DropColumn(
                name: "DateId",
                table: "NasaDailyImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NasaDailyImages",
                table: "NasaDailyImages",
                column: "Date");

            migrationBuilder.InsertData(
                table: "NasaDailyImages",
                columns: new[] { "Date", "Copyright", "Explanation", "HdUrl", "MediaType", "ServiceVersion", "Title", "Url" },
                values: new object[] { new DateTime(2023, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Theresa Clarke", "Not every road ends in a STEVE. A week ago, a sky enthusiast's journey began with a goal: to photograph an aurora over Lake Huron. Driving through rural Ontario, Canada, the forecasted sky show started unexpectedly early, causing the photographer to stop before arriving at the scenic Great Lake. Aurora images were taken toward the north -- but over land, not sea. While waiting for a second round of auroras, a peculiar band of light was noticed to the west.  Slowly, the photographer and friends realized that this western band was likely an unusual type of aurora: a Strong Thermal Emission Velocity Enhancement (STEVE). Moreover, this STEVE was putting on quite a show: appearing intertwined with the central band of our Milky Way Galaxy while intersecting the horizon just near the end of the country road. After capturing this cosmic X on camera, the photographer paused to appreciate the unexpected awesomeness of finding extraordinary beauty in an ordinary setting.     Your Sky Surprise: What picture did APOD feature on your birthday? (post 1995)", "https://apod.nasa.gov/apod/image/2309/SteveMw_Clarke_4177.jpg", "image", "v1", "STEVE and Milky Way Cross over Rural Road", "https://apod.nasa.gov/apod/image/2309/SteveMw_Clarke_960.jpg" });
        }
    }
}
