using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace identity.Models
{
    public partial class Care_todayContext : DbContext
    {
        public Care_todayContext()
        {
        }

        public Care_todayContext(DbContextOptions<Care_todayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<BloodBank> BloodBanks { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Governorate> Governorates { get; set; }
        public virtual DbSet<Nursery> Nurseries { get; set; }
        public virtual DbSet<OxygenTube> OxygenTubes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Care_today;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BloodBank>(entity =>
            {
                entity.HasKey(e => e.BloodId)
                    .HasName("PK__Blood_ba__A0B98A9C9C1CBE98");

                entity.ToTable("Blood_bank");

                entity.Property(e => e.BloodId).HasColumnName("Blood_Id");

                entity.Property(e => e.BloodCost).HasColumnName("Blood_Cost");

                entity.Property(e => e.BloodDescription)
                    .HasMaxLength(200)
                    .HasColumnName("Blood_Description");

                entity.Property(e => e.BloodLocation)
                    .HasMaxLength(50)
                    .HasColumnName("Blood_Location");

                entity.Property(e => e.BloodPhone)
                    .HasMaxLength(50)
                    .HasColumnName("Blood_phone");

                entity.Property(e => e.BloodType)
                    .HasMaxLength(50)
                    .HasColumnName("Blood_type");

                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.BloodBanks)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Blood_ban__City___3F466844");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.Property(e => e.CityName)
                    .HasMaxLength(50)
                    .HasColumnName("City_name");

                entity.Property(e => e.GovId).HasColumnName("Gov_id");

                entity.HasOne(d => d.Gov)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.GovId)
                    .HasConstraintName("FK__City__Gov_id__398D8EEE");
            });

            modelBuilder.Entity<Governorate>(entity =>
            {
                entity.HasKey(e => e.GovId)
                    .HasName("PK__Governor__53EAE3B61DE901A9");

                entity.ToTable("Governorate");

                entity.HasIndex(e => e.GovName, "UQ__Governor__82E2C2CCF3FD83A0")
                    .IsUnique();

                entity.Property(e => e.GovId).HasColumnName("Gov_id");

                entity.Property(e => e.GovName)
                    .HasMaxLength(50)
                    .HasColumnName("Gov_name");
            });

            modelBuilder.Entity<Nursery>(entity =>
            {
                entity.HasKey(e => e.NurId)
                    .HasName("PK__Nursery__3107BA498E8FDBB7");

                entity.ToTable("Nursery");

                entity.Property(e => e.NurId).HasColumnName("Nur_Id");

                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.Property(e => e.NurCost).HasColumnName("Nur_Cost");

                entity.Property(e => e.NurDescription)
                    .HasMaxLength(200)
                    .HasColumnName("Nur_Description");

                entity.Property(e => e.NurLocation)
                    .HasMaxLength(50)
                    .HasColumnName("Nur_Location");

                entity.Property(e => e.NurPhone)
                    .HasMaxLength(50)
                    .HasColumnName("Nur_phone");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Nurseries)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Nursery__City_id__3C69FB99");
            });

            modelBuilder.Entity<OxygenTube>(entity =>
            {
                entity.HasKey(e => e.OxgnId)
                    .HasName("PK__Oxygen_t__8D1F1018A9B4BE38");

                entity.ToTable("Oxygen_tube");

                entity.Property(e => e.OxgnId).HasColumnName("Oxgn_Id");

                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.Property(e => e.OxgnAmount).HasColumnName("Oxgn_amount");

                entity.Property(e => e.OxgnCost).HasColumnName("Oxgn_Cost");

                entity.Property(e => e.OxgnDescription)
                    .HasMaxLength(200)
                    .HasColumnName("Oxgn_Description");

                entity.Property(e => e.OxgnLocation)
                    .HasMaxLength(50)
                    .HasColumnName("Oxgn_Location");

                entity.Property(e => e.OxgnPhone)
                    .HasMaxLength(50)
                    .HasColumnName("Oxgn_phone");

                entity.Property(e => e.OxgnType)
                    .HasMaxLength(50)
                    .HasColumnName("Oxgn_type");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.OxygenTubes)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Oxygen_tu__City___4222D4EF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
