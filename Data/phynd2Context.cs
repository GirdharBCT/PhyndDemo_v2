 using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PhyndDemo_v2.Models;

#nullable disable

namespace PhyndDemo_v2.Data
{
    public partial class phynd2Context : DbContext
    {
        public phynd2Context()
        {
        }

        public phynd2Context(DbContextOptions<phynd2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Models.Program> Programs { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Providerprogram> Providerprograms { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Userrole> Userroles { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseMySQL("server=localhost;uid=root;pwd=root;database=phynd2;SSL mode=none");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>(entity =>
            {
                entity.Property(e => e.ActionTime).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Models.Program>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Providers)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("provider_hospitalId");
            });

            modelBuilder.Entity<Providerprogram>(entity =>
            {
                entity.HasOne(d => d.Program)
                    .WithMany(p => p.Providerprograms)
                    .HasForeignKey(d => d.ProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("programId");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Providerprograms)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("providerId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.ModifiedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.UserHospital)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserHospitalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_hospitalId");
            });

            modelBuilder.Entity<Userrole>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Userroles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userroles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
