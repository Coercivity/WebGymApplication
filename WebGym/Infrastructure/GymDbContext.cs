﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebGym.Infrastructure.efModels;

#nullable disable

namespace WebGym.Infrastructure
{
    public partial class GymDbContext : DbContext
    {

        public GymDbContext(DbContextOptions<GymDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abonement> Abonements { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<DayNaming> DayNamings { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<RoleGroup> RoleGroups { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ServiceDataType> ServiceDataTypes { get; set; }
        public virtual DbSet<ServiceData> ServiceData { get; set; }
        public virtual DbSet<StatisticsData> StatisticsData { get; set; }
        public virtual DbSet<TrainType> TrainTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Abonement>(entity =>
            {
                entity.ToTable("Abonement");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FinishDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Abonements)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Abonement__Clien__33D4B598");
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LoginData)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordData)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account__GroupId__276EDEB3");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.FinishTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.CoachId)
                    .HasConstraintName("FK__Attendanc__Coach__36B12243");

                entity.HasOne(d => d.StatisticsData)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.StatisticsDataId)
                    .HasConstraintName("FK__Attendanc__Stati__37A5467C");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.HasIndex(e => e.AccountId, "UQ__Client__349DA5A78A0AC398")
                    .IsUnique();

                entity.HasIndex(e => e.StatisticsDataId, "UQ__Client__CA990C08B0708B6B")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Sex).HasMaxLength(10);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.Client)
                    .HasForeignKey<Client>(d => d.AccountId)
                    .HasConstraintName("FK__Client__AccountI__2C3393D0");

                entity.HasOne(d => d.StatisticsData)
                    .WithOne(p => p.Client)
                    .HasForeignKey<Client>(d => d.StatisticsDataId)
                    .HasConstraintName("FK__Client__Statisti__2D27B809");
            });

            modelBuilder.Entity<Coach>(entity =>
            {
                entity.ToTable("Coach");

                entity.HasIndex(e => e.AccountId, "UQ__Coach__349DA5A7A3903C61")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Degree).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.HasOne(d => d.Account)
                    .WithOne(p => p.Coach)
                    .HasForeignKey<Coach>(d => d.AccountId)
                    .HasConstraintName("FK__Coach__AccountId__30F848ED");
            });

            modelBuilder.Entity<DayNaming>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DayData).HasMaxLength(12);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FinishTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Coach)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.CoachId)
                    .HasConstraintName("FK__Position__CoachI__48CFD27E");

                entity.HasOne(d => d.DayNamings)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.DayNamingsId)
                    .HasConstraintName("FK__Position__DayNam__46E78A0C");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.ScheduleId)
                    .HasConstraintName("FK__Position__Schedu__49C3F6B7");

                entity.HasOne(d => d.TrainType)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.TrainTypeId)
                    .HasConstraintName("FK__Position__TrainT__47DBAE45");
            });

            modelBuilder.Entity<RoleGroup>(entity =>
            {
                entity.ToTable("RoleGroup");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(12);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(100);
            });

            modelBuilder.Entity<ServiceDataType>(entity =>
            {
                entity.ToTable("ServiceDataType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NameData).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<ServiceData>(entity =>
            {
                entity.HasKey(e => new { e.AbonementId, e.AttendanceId })
                    .HasName("PK__ServiceD__D947664382B8DCBE");

                entity.HasOne(d => d.Abonement)
                    .WithMany(p => p.ServiceData)
                    .HasForeignKey(d => d.AbonementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ServiceDa__Abone__3C69FB99");

                entity.HasOne(d => d.Attendance)
                    .WithMany(p => p.ServiceData)
                    .HasForeignKey(d => d.AttendanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ServiceDa__Atten__3D5E1FD2");

                entity.HasOne(d => d.ServiceDataType)
                    .WithMany(p => p.ServiceData)
                    .HasForeignKey(d => d.ServiceDataTypeId)
                    .HasConstraintName("FK__ServiceDa__Servi__3E52440B");
            });

            modelBuilder.Entity<StatisticsData>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FinishDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<TrainType>(entity =>
            {
                entity.ToTable("TrainType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
