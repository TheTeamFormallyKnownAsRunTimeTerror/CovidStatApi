using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CovidStatApi.Domain.Models
{
    public partial class CovidStatsProjectContext : DbContext
    {
        public CovidStatsProjectContext()
        {
        }

        public CovidStatsProjectContext(DbContextOptions<CovidStatsProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<CountryData> CountryData { get; set; }
        public virtual DbSet<CountryStatistics> CountryStatistics { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=covid-data-runtimeterror-dev.cmfckbnwttaa.eu-west-1.rds.amazonaws.com;Database=CovidStatsProject;user=admin;password=8n6FaTZYujfIxGDHlIuD; Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PRIMARY");

                entity.Property(e => e.CountryId).HasColumnType("int(11)");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.CountrySlug).HasColumnType("longtext");

                entity.Property(e => e.HasData).HasColumnType("tinyint(1)");

                entity.Property(e => e.Iso2).HasColumnType("longtext");
            });

            modelBuilder.Entity<CountryData>(entity =>
            {
                entity.HasKey(e => e.UpdateId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CountriesCountryId);

                entity.Property(e => e.UpdateId).HasColumnType("int(11)");

                entity.Property(e => e.ActiveCases).HasColumnType("int(11)");

                entity.Property(e => e.City).HasColumnType("longtext");

                entity.Property(e => e.ConfirmedCases).HasColumnType("int(11)");

                entity.Property(e => e.CountriesCountryId).HasColumnType("int(11)");

                entity.Property(e => e.CountryCode).HasColumnType("longtext");

                entity.Property(e => e.CountryId).HasColumnType("int(11)");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnType("longtext");

                entity.Property(e => e.DateTime).HasColumnType("datetime(6)");

                entity.Property(e => e.Deaths).HasColumnType("int(11)");

                entity.Property(e => e.Latitude).HasColumnType("longtext");

                entity.Property(e => e.Longitude).HasColumnType("longtext");

                entity.Property(e => e.Province).HasColumnType("longtext");

                entity.Property(e => e.Recovered).HasColumnType("int(11)");

                entity.HasOne(d => d.CountriesCountry)
                    .WithMany(p => p.CountryData)
                    .HasForeignKey(d => d.CountriesCountryId);
            });

            modelBuilder.Entity<CountryStatistics>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PRIMARY");

                entity.Property(e => e.CountryId).HasColumnType("int(11)");

                entity.Property(e => e.CountryName).HasColumnType("longtext");

                entity.Property(e => e.GrangerStatistics).HasColumnType("longtext");

                entity.Property(e => e.MeasureImportances).HasColumnType("longtext");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__EFMigrationsHistory");

                entity.Property(e => e.MigrationId)
                    .HasMaxLength(95)
                    .IsUnicode(false);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
