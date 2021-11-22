using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Oceans11.Models
{
    public partial class MoneyHeistDBContext : DbContext
    {
        public MoneyHeistDBContext()
        {
        }

        public MoneyHeistDBContext(DbContextOptions<MoneyHeistDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Heist> Heists { get; set; }
        public virtual DbSet<HeistMember> HeistMembers { get; set; }
        public virtual DbSet<MemberSkill> MemberSkills { get; set; }
        public virtual DbSet<MembersInHeist> MembersInHeists { get; set; }
        public virtual DbSet<RequiredSkillsForHeist> RequiredSkillsForHeists { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-7EO7DRN2\\SQLEXPRESS;Database=MoneyHeistDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.Naziv).IsRequired();
            });

            modelBuilder.Entity<Heist>(entity =>
            {
                entity.ToTable("Heist");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("endTime");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NameOfHeist)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("startTime");
            });

            modelBuilder.Entity<HeistMember>(entity =>
            {
                entity.HasIndex(e => e.GenderId, "IX_HeistMembers_GenderId");

                entity.HasIndex(e => e.MainSkillId, "IX_HeistMembers_MainSkillId");

                entity.HasIndex(e => e.StatusId, "IX_HeistMembers_StatusId");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.HeistMembers)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_HeistMembers_Genders");

                entity.HasOne(d => d.MainSkill)
                    .WithMany(p => p.HeistMembers)
                    .HasForeignKey(d => d.MainSkillId)
                    .HasConstraintName("FK_HeistMembers_Skills");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.HeistMembers)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_HeistMembers_Statuses");
            });

            modelBuilder.Entity<MemberSkill>(entity =>
            {
                entity.HasKey(e => new { e.HeistMemberId, e.SkillId });

                entity.ToTable("MemberSkill");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.HeistMember)
                    .WithMany(p => p.MemberSkills)
                    .HasForeignKey(d => d.HeistMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberSkill_HeistMembers");

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.MemberSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberSkill_Skills");
            });

            modelBuilder.Entity<MembersInHeist>(entity =>
            {
                entity.ToTable("MembersInHeist");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Heist)
                    .WithMany(p => p.MembersInHeists)
                    .HasForeignKey(d => d.HeistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembersInHeist_Heist");

                entity.HasOne(d => d.HeistMember)
                    .WithMany(p => p.MembersInHeists)
                    .HasForeignKey(d => d.HeistMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembersInHeist_HeistMembers");
            });

            modelBuilder.Entity<RequiredSkillsForHeist>(entity =>
            {
                entity.ToTable("RequiredSkillsForHeist");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Heist)
                    .WithMany(p => p.RequiredSkillsForHeists)
                    .HasForeignKey(d => d.HeistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RequiredSkillsForHeist_Heist");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Naziv).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
