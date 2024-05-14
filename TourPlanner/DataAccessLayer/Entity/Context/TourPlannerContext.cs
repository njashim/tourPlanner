using System;
using System.Collections.Generic;
using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Entity.Context;

public partial class TourPlannerContext : DbContext
{

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
            entity.HasKey(e => e.Id).HasName("Tour_PK");

            entity.ToTable("Tour");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("Name");
            entity.Property(e => e.Description).HasColumnName("Description");
            entity.Property(e => e.FromLocation)
                .HasMaxLength(100)
                .HasColumnName("FromLocation");
            entity.Property(e => e.ToLocation)
                .HasMaxLength(100)
                .HasColumnName("ToLocation");
            entity.Property(e => e.TransportType).HasColumnName("TransportType");
            entity.Property(e => e.Distance).HasColumnName("Distance");
            entity.Property(e => e.EstimatedTime).HasColumnName("EstimatedTime");
            entity.Property(e => e.RouteImagePath).HasColumnName("RouteImagePath");
        });

        modelBuilder.Entity<TourLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TourLog_PK");

            entity.ToTable("TourLog");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.TourId).HasColumnName("TourId");
            entity.Property(e => e.DateTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("DateTime");
            entity.Property(e => e.Comment).HasColumnName("Comment");
            entity.Property(e => e.Difficulty).HasColumnName("Difficulty");
            entity.Property(e => e.TotalDistance).HasColumnName("TotalDistance");
            entity.Property(e => e.TotalTime).HasColumnName("TotalTime");
            entity.Property(e => e.Rating).HasColumnName("Rating");

            entity.HasOne(d => d.Tour).WithMany(p => p.TourLogs)
                .HasForeignKey(d => d.TourId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("TourLog_TourId_FK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
