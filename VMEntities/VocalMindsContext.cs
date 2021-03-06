﻿using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace VMEntities
{
    public class VocalMindsContext : DbContext
    {
        public DbSet<FaceRecognitionScenario> FaceRecognitionScenarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["BloggingDatabase"].ConnectionString);
        }

    }
}
