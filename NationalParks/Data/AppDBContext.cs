using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NationalParks.Models;

namespace NationalParks.Data;

public partial class AppDBContext : IdentityDbContext<User>
{
    public AppDBContext()
    {
    }

    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<PlaceRating> PlaceRatings { get; set; }

    public virtual DbSet<SiteType> SiteTypes { get; set; }

    public virtual DbSet<Species> Species { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketSale> TicketSales { get; set; }

    public virtual DbSet<Visitor> Visitors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=Parks;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Card_PK");

            entity.ToTable("Card");

            entity.Property(e => e.CardType)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Country_PK");

            entity.ToTable("Country");

            entity.Property(e => e.Continent)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Location_PK");

            entity.ToTable("Location");

            entity.Property(e => e.Canton)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.District)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Province)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Places_PK");

            entity.Property(e => e.Address)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .IsUnicode(false);
            
            entity.Property(e => e.LocationId).HasColumnName("Location_Id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Recognitions)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ReservedArea)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SiteTypeId).HasColumnName("SiteType_Id");
            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.Places)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("PlacesXLocation_FK");

            entity.HasOne(d => d.SiteTypeNavigation).WithMany(p => p.Places)
                .HasForeignKey(d => d.SiteTypeId)
                .HasConstraintName("SiteTypeXPlaces_FK");
        });

        modelBuilder.Entity<PlaceRating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PlaceRating_PK");

            entity.ToTable("PlaceRating");

            entity.Property(e => e.Observation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PlaceId).HasColumnName("Place_Id");
            entity.HasOne(d => d.Place).WithMany(p => p.PlaceRatings)
                .HasForeignKey(d => d.PlaceId)
                .HasConstraintName("PlacesXPlaceRating_FK");
        });

        modelBuilder.Entity<SiteType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SiteType_PK");

            entity.ToTable("SiteType");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Species>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Species_PK");

            entity.Property(e => e.CommonName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ScientificName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SpecialCharacteristics)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SpeciesType)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasMany(d => d.Places).WithMany(p => p.Species)
                .UsingEntity<Dictionary<string, object>>(
                    "PlacesXspecy",
                    r => r.HasOne<Place>().WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("PlacesXSpecies_FK2"),
                    l => l.HasOne<Species>().WithMany()
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("PlacesXSpecies_FK1"),
                    j =>
                    {
                        j.HasKey("SpeciesId", "PlaceId").HasName("PlacesXSpecies_PK");
                        j.ToTable("PlacesXSpecies");
                    });
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Ticket_PK");
            
            entity.Property(e => e.PlaceId).HasColumnName("Place_Id");
            entity.Property(e => e.TicketSaleId).HasColumnName("TicketSale_Id");

            entity.HasOne(d => d.PlaceNavigation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.PlaceId)
                .HasConstraintName("PlacesXTickets_FK");

            entity.HasOne(d => d.TicketSale).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TicketSaleId)
                .HasConstraintName("SalesXTickets_FK");

        });

        modelBuilder.Entity<TicketSale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TicketSales_PK");

            entity.Property(e => e.CardId).HasColumnName("Card_Id");
            entity.Property(e => e.Customer)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.VisitorId).HasColumnName("Visitor_Id");

            entity.HasOne(d => d.Card)
                .WithMany(p => p.TicketSales)
                .HasForeignKey(d => d.CardId)
                .HasConstraintName("SalesXCardCommission_FK");

            entity.HasOne(d => d.Visitor)
                .WithMany(p => p.TicketSales)
                .HasForeignKey(d => d.VisitorId)
                .HasConstraintName("SalesXVisitors_FK");

            entity.HasMany(d => d.Tickets)  
                .WithOne(p => p.TicketSale)  
                .HasForeignKey(p => p.TicketSaleId)  
                .OnDelete(DeleteBehavior.Cascade); 
        });


        modelBuilder.Entity<Visitor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Visitors_PK");

            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IdnumberOrPassport).HasColumnName("IDNumberOrPassport");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.VisitReason)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Visitors)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("VisitorsXCountry_FK");
        });
        base.OnModelCreating(modelBuilder); 
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
