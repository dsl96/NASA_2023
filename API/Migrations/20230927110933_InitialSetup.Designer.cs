﻿// <auto-generated />
using System;
using API.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(SpaceContext))]
    [Migration("20230927110933_InitialSetup")]
    partial class InitialSetup
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DATA_CLASSES.NasaDailyImageResponse", b =>
                {
                    b.Property<int>("DateId")
                        .HasColumnType("int");

                    b.Property<string>("Copyright")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HdUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediaType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceVersion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DateId");

                    b.ToTable("NasaDailyImages");

                    b.HasData(
                        new
                        {
                            DateId = 20230927,
                            Copyright = "Theresa Clarke",
                            Date = new DateTime(2023, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Explanation = "Short explanation 1.",
                            HdUrl = "https://apod.nasa.gov/apod/image/2309/SteveMw_Clarke_4177.jpg",
                            MediaType = "image",
                            ServiceVersion = "v1",
                            Title = "Image 1",
                            Url = "https://apod.nasa.gov/apod/image/2309/SteveMw_Clarke_960.jpg"
                        },
                        new
                        {
                            DateId = 20230928,
                            Copyright = "Another Author",
                            Date = new DateTime(2023, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Explanation = "Short explanation 2.",
                            HdUrl = "https://example.com/image2.jpg",
                            MediaType = "image",
                            ServiceVersion = "v1",
                            Title = "Image 2",
                            Url = "https://example.com/image2_hd.jpg"
                        },
                        new
                        {
                            DateId = 20230929,
                            Copyright = "John Doe",
                            Date = new DateTime(2023, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Explanation = "Short explanation 3.",
                            HdUrl = "https://example.com/image3.jpg",
                            MediaType = "image",
                            ServiceVersion = "v1",
                            Title = "Image 3",
                            Url = "https://example.com/image3_hd.jpg"
                        },
                        new
                        {
                            DateId = 20230930,
                            Copyright = "Jane Smith",
                            Date = new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Explanation = "Short explanation 4.",
                            HdUrl = "https://example.com/image4.jpg",
                            MediaType = "image",
                            ServiceVersion = "v1",
                            Title = "Image 4",
                            Url = "https://example.com/image4_hd.jpg"
                        },
                        new
                        {
                            DateId = 20231001,
                            Copyright = "A. N. Other",
                            Date = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Explanation = "Short explanation 5.",
                            HdUrl = "https://example.com/image5.jpg",
                            MediaType = "image",
                            ServiceVersion = "v1",
                            Title = "Image 5",
                            Url = "https://example.com/image5_hd.jpg"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
