using System;
using System.Collections.Generic;
using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entity.Context;

public partial class TourPlannerContext : DbContext
{
    public TourPlannerContext()
    {
    }

    public TourPlannerContext(DbContextOptions<TourPlannerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<TourLog> TourLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:TourPlannerDBConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tour>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tour");
        });

        modelBuilder.Entity<TourLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TourLog");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
