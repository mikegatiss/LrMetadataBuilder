﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LrMetadataBuilder.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Game>()
                .HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(m => m.HomeTeamId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Game>()
                .HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(m => m.AwayTeamId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

        }

        
    }
}
