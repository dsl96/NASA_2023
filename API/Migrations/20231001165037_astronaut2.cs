using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class astronaut2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NasaDailyImages",
                keyColumn: "DateId",
                keyValue: 20230927);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "NasaDailyImages",
                columns: new[] { "DateId", "Copyright", "Date", "Explanation", "HdUrl", "MediaType", "ServiceVersion", "Title", "Url" },
                values: new object[,]
                {
                    { 20230927, "Theresa Clarke", new DateTime(2023, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Short explanation 1.", "https://apod.nasa.gov/apod/image/2309/SteveMw_Clarke_4177.jpg", "image", "v1", "Image 1", "https://apod.nasa.gov/apod/image/2309/SteveMw_Clarke_960.jpg" },
                    { 20230928, "Another Author", new DateTime(2023, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Short explanation 2.", "https://example.com/image2.jpg", "image", "v1", "Image 2", "https://example.com/image2_hd.jpg" },
                    { 20230929, "John Doe", new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Short explanation 3.", "https://example.com/image3.jpg", "image", "v1", "Image 3", "https://example.com/image3_hd.jpg" },
                    { 20230930, "Jane Smith", new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Short explanation 4.", "https://example.com/image4.jpg", "image", "v1", "Image 4", "https://example.com/image4_hd.jpg" },
                    { 20231001, "A. N. Other", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Short explanation 5.", "https://example.com/image5.jpg", "image", "v1", "Image 5", "https://example.com/image5_hd.jpg" }
                });
        }
    }
}
