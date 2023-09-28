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
    [Migration("20230927105243_changeidtoint5")]
    partial class changeidtoint5
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
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Copyright")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.HasKey("Date");

                    b.ToTable("NasaDailyImages");

                    b.HasData(
                        new
                        {
                            Date = new DateTime(2023, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Copyright = "Theresa Clarke",
                            Explanation = "Not every road ends in a STEVE. A week ago, a sky enthusiast's journey began with a goal: to photograph an aurora over Lake Huron. Driving through rural Ontario, Canada, the forecasted sky show started unexpectedly early, causing the photographer to stop before arriving at the scenic Great Lake. Aurora images were taken toward the north -- but over land, not sea. While waiting for a second round of auroras, a peculiar band of light was noticed to the west.  Slowly, the photographer and friends realized that this western band was likely an unusual type of aurora: a Strong Thermal Emission Velocity Enhancement (STEVE). Moreover, this STEVE was putting on quite a show: appearing intertwined with the central band of our Milky Way Galaxy while intersecting the horizon just near the end of the country road. After capturing this cosmic X on camera, the photographer paused to appreciate the unexpected awesomeness of finding extraordinary beauty in an ordinary setting.     Your Sky Surprise: What picture did APOD feature on your birthday? (post 1995)",
                            HdUrl = "https://apod.nasa.gov/apod/image/2309/SteveMw_Clarke_4177.jpg",
                            MediaType = "image",
                            ServiceVersion = "v1",
                            Title = "STEVE and Milky Way Cross over Rural Road",
                            Url = "https://apod.nasa.gov/apod/image/2309/SteveMw_Clarke_960.jpg"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
