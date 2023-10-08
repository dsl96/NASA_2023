using API.Migrations;
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
        public DbSet<AstronautResponse>  Astronauts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AstronautResponse>(entity =>
            {
                entity.OwnsOne(a => a.status);
            });
        }
    }
}

