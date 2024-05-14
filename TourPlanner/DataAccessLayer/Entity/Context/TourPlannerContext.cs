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
            entity.HasKey(e => e.Id).HasName("tour_pkey");

            entity.ToTable("tour");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Distance).HasColumnName("distance");
            entity.Property(e => e.Estimatedtime).HasColumnName("estimatedtime");
            entity.Property(e => e.Fromlocation)
                .HasMaxLength(100)
                .HasColumnName("fromlocation");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Routeimagepath)
                .HasMaxLength(255)
                .HasColumnName("routeimagepath");
            entity.Property(e => e.Tolocation)
                .HasMaxLength(100)
                .HasColumnName("tolocation");
            entity.Property(e => e.Transporttype)
                .HasMaxLength(50)
                .HasColumnName("transporttype");
        });

        modelBuilder.Entity<TourLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tourlog_pkey");

            entity.ToTable("tourlog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Datetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datetime");
            entity.Property(e => e.Difficulty)
                .HasMaxLength(50)
                .HasColumnName("difficulty");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Totaldistance).HasColumnName("totaldistance");
            entity.Property(e => e.Totaltime).HasColumnName("totaltime");
            entity.Property(e => e.Tourid).HasColumnName("tourid");

            entity.HasOne(d => d.Tour).WithMany(p => p.Tourlogs)
                .HasForeignKey(d => d.Tourid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("tourlog_tourid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
