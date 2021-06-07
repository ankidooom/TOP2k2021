using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace testje_amk.Models
{
    public partial class Top2000Context : DbContext
    {
        public Top2000Context()
        {
        }

        public Top2000Context(DbContextOptions<Top2000Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Artiest> Artiests { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Lijst> Lijsts { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<Top2000Jaar> Top2000Jaars { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Top2000;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Artiest>(entity =>
            {
                entity.ToTable("Artiest");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("naam");
            });

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

            modelBuilder.Entity<Lijst>(entity =>
            {
                entity.HasKey(e => new { e.Songid, e.Top2000jaar });

                entity.ToTable("Lijst");

                entity.Property(e => e.Songid).HasColumnName("songid");

                entity.Property(e => e.Top2000jaar).HasColumnName("top2000jaar");

                entity.Property(e => e.Positie).HasColumnName("positie");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.Lijsts)
                    .HasForeignKey(d => d.Songid)
                    .HasConstraintName("FK_Lijst_Song");

                entity.HasOne(d => d.Top2000jaarNavigation)
                    .WithMany(p => p.Lijsts)
                    .HasForeignKey(d => d.Top2000jaar)
                    .HasConstraintName("FK_Lijst_Top2000Jaar");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("Song");

                entity.Property(e => e.Songid).HasColumnName("songid");

                entity.Property(e => e.Artiestid).HasColumnName("artiestid");

                entity.Property(e => e.Jaar).HasColumnName("jaar");

                entity.Property(e => e.Titel)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("titel");

                entity.HasOne(d => d.Artiest)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.Artiestid)
                    .HasConstraintName("FK_Song_Artiest");
            });

            modelBuilder.Entity<Top2000Jaar>(entity =>
            {
                entity.HasKey(e => e.Jaar);

                entity.ToTable("Top2000Jaar");

                entity.Property(e => e.Jaar).ValueGeneratedNever();

                entity.Property(e => e.Titel)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasComputedColumnSql("('De TOP 2000 van '+CONVERT([char](5),[Jaar]))", false);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserProf__1788CC4C274188EE");

                entity.ToTable("UserProfile");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
