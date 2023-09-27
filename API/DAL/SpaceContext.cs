﻿using Azure;
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

        public DbSet<NasaDailyImageResponse> NasaDailyImages{ get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<NasaDailyImageResponse>().HasData(
              new NasaDailyImageResponse
              {
                  Date = new DateTime(2023, 09, 27),

                  Copyright = "Theresa Clarke",
                  Explanation =  "Not every road ends in a STEVE. A week ago, a sky enthusiast's journey began with a goal: to photograph an aurora over Lake Huron. Driving through rural Ontario, Canada, the forecasted sky show started unexpectedly early, causing the photographer to stop before arriving at the scenic Great Lake. Aurora images were taken toward the north -- but over land, not sea. While waiting for a second round of auroras, a peculiar band of light was noticed to the west.  Slowly, the photographer and friends realized that this western band was likely an unusual type of aurora: a Strong Thermal Emission Velocity Enhancement (STEVE). Moreover, this STEVE was putting on quite a show: appearing intertwined with the central band of our Milky Way Galaxy while intersecting the horizon just near the end of the country road. After capturing this cosmic X on camera, the photographer paused to appreciate the unexpected awesomeness of finding extraordinary beauty in an ordinary setting.     Your Sky Surprise: What picture did APOD feature on your birthday? (post 1995)",
                  HdUrl =  "https://apod.nasa.gov/apod/image/2309/SteveMw_Clarke_4177.jpg",
                  MediaType = "image",
                  ServiceVersion =  "v1",
                  Title =  "STEVE and Milky Way Cross over Rural Road",
                  Url =  "https://apod.nasa.gov/apod/image/2309/SteveMw_Clarke_960.jpg"
              }
         );  
        }
    }
}

