using Azure;
using DATA_CLASSES;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;

namespace API.DAL
{
    public class SpaceContext : DbContext
    {

        public SpaceContext(DbContextOptions<SpaceContext> options) : base(options)
        {
        }

        public DbSet<NasaDailyImageResponse> NasaDailyImages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<NasaDailyImageResponse>().HasData(
          new NasaDailyImageResponse
          {
              Date = new DateTime(2023, 09, 27),
              Copyright = "Theresa Clarke",
              Explanation = "Short explanation 1.",
              HdUrl = "https://apod.nasa.gov/apod/image/2309/SteveMw_Clarke_4177.jpg",
              MediaType = "image",
              ServiceVersion = "v1",
              Title = "Image 1",
              Url = "https://apod.nasa.gov/apod/image/2309/SteveMw_Clarke_960.jpg"
          },
          new NasaDailyImageResponse
          {
              Date = new DateTime(2023, 09, 28),
              Copyright = "Another Author",
              Explanation = "Short explanation 2.",
              HdUrl = "https://example.com/image2.jpg",
              MediaType = "image",
              ServiceVersion = "v1",
              Title = "Image 2",
              Url = "https://example.com/image2_hd.jpg"
          },
          new NasaDailyImageResponse
          {
              Date = new DateTime(2023, 09, 29),
              Copyright = "John Doe",
              Explanation = "Short explanation 3.",
              HdUrl = "https://example.com/image3.jpg",
              MediaType = "image",
              ServiceVersion = "v1",
              Title = "Image 3",
              Url = "https://example.com/image3_hd.jpg"
          },
          new NasaDailyImageResponse
          {
              Date = new DateTime(2023, 09, 30),
              Copyright = "Jane Smith",
              Explanation = "Short explanation 4.",
              HdUrl = "https://example.com/image4.jpg",
              MediaType = "image",
              ServiceVersion = "v1",
              Title = "Image 4",
              Url = "https://example.com/image4_hd.jpg"
          },
          new NasaDailyImageResponse
          {
              Date = new DateTime(2023, 10, 1),
              Copyright = "A. N. Other",
              Explanation = "Short explanation 5.",
              HdUrl = "https://example.com/image5.jpg",
              MediaType = "image",
              ServiceVersion = "v1",
              Title = "Image 5",
              Url = "https://example.com/image5_hd.jpg"
          }
               );
        }
    }
}

