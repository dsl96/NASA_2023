using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NasaDailyImages",
                keyColumn: "DateId",
                keyValue: 20230927,
                columns: new[] { "Explanation", "Title" },
                values: new object[] { "Short explanation 1.", "Image 1" });

            migrationBuilder.InsertData(
                table: "NasaDailyImages",
                columns: new[] { "DateId", "Copyright", "Date", "Explanation", "HdUrl", "MediaType", "ServiceVersion", "Title", "Url" },
                values: new object[,]
                {
                    { 20230928, "Another Author", new DateTime(2023, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Short explanation 2.", "https://example.com/image2.jpg", "image", "v1", "Image 2", "https://example.com/image2_hd.jpg" },
                    { 20230929, "John Doe", new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Short explanation 3.", "https://example.com/image3.jpg", "image", "v1", "Image 3", "https://example.com/image3_hd.jpg" },
                    { 20230930, "Jane Smith", new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Short explanation 4.", "https://example.com/image4.jpg", "image", "v1", "Image 4", "https://example.com/image4_hd.jpg" },
                    { 20231001, "A. N. Other", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Short explanation 5.", "https://example.com/image5.jpg", "image", "v1", "Image 5", "https://example.com/image5_hd.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NasaDailyImages",
                keyColumn: "DateId",
                keyValue: 20230928);

            migrationBuilder.DeleteData(
                table: "NasaDailyImages",
                keyColumn: "DateId",
                keyValue: 20230929);

            migrationBuilder.DeleteData(
                table: "NasaDailyImages",
                keyColumn: "DateId",
                keyValue: 20230930);

            migrationBuilder.DeleteData(
                table: "NasaDailyImages",
                keyColumn: "DateId",
                keyValue: 20231001);

            migrationBuilder.UpdateData(
                table: "NasaDailyImages",
                keyColumn: "DateId",
                keyValue: 20230927,
                columns: new[] { "Explanation", "Title" },
                values: new object[] { "Not every road ends in a STEVE. A week ago, a sky enthusiast's journey began with a goal: to photograph an aurora over Lake Huron. Driving through rural Ontario, Canada, the forecasted sky show started unexpectedly early, causing the photographer to stop before arriving at the scenic Great Lake. Aurora images were taken toward the north -- but over land, not sea. While waiting for a second round of auroras, a peculiar band of light was noticed to the west.  Slowly, the photographer and friends realized that this western band was likely an unusual type of aurora: a Strong Thermal Emission Velocity Enhancement (STEVE). Moreover, this STEVE was putting on quite a show: appearing intertwined with the central band of our Milky Way Galaxy while intersecting the horizon just near the end of the country road. After capturing this cosmic X on camera, the photographer paused to appreciate the unexpected awesomeness of finding extraordinary beauty in an ordinary setting.     Your Sky Surprise: What picture did APOD feature on your birthday? (post 1995)", "STEVE and Milky Way Cross over Rural Road" });
        }
    }
}
