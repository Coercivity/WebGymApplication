﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(GymDbContext))]
    [Migration("20220504174521_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Abonement", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("date");

                    b.Property<bool?>("IsValid")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("date");

                    b.Property<int?>("VisitsAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Abonement");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("LoginData")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordData")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Attendance", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<double?>("CaloriesSpent")
                        .HasColumnType("float");

                    b.Property<Guid?>("CoachId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("FinishTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("HeadPressure")
                        .HasColumnType("int");

                    b.Property<int?>("HeartPressure")
                        .HasColumnType("int");

                    b.Property<int?>("Pulse")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("StatisticsDataId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("WeightData")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("StatisticsDataId");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Sex")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid?>("StatisticsDataId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AccountId" }, "UQ__Client__349DA5A78A0AC398")
                        .IsUnique()
                        .HasFilter("[AccountId] IS NOT NULL");

                    b.HasIndex(new[] { "StatisticsDataId" }, "UQ__Client__CA990C08B0708B6B")
                        .IsUnique()
                        .HasFilter("[StatisticsDataId] IS NOT NULL");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Coach", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Degree")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "AccountId" }, "UQ__Coach__349DA5A7A3903C61")
                        .IsUnique()
                        .HasFilter("[AccountId] IS NOT NULL");

                    b.ToTable("Coach");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.DayNamings", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("DayData")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.ToTable("DayNamings");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CoachId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("DayNamingsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FinishTime")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("TrainTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("DayNamingsId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("TrainTypeId");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.RoleGroup", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("Id");

                    b.ToTable("RoleGroup");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.ServiceData", b =>
                {
                    b.Property<Guid>("AbonementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AttendanceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ServiceDataTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AbonementId", "AttendanceId")
                        .HasName("PK__ServiceD__D947664382B8DCBE");

                    b.HasIndex("AttendanceId");

                    b.HasIndex("ServiceDataTypeId");

                    b.ToTable("ServiceData");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.ServiceDataType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameData")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("ServiceDataType");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.StatisticsData", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("date");

                    b.Property<double?>("MedianCaloriesSpent")
                        .HasColumnType("float");

                    b.Property<int?>("MedianHeadPressure")
                        .HasColumnType("int");

                    b.Property<int?>("MedianHeartPressure")
                        .HasColumnType("int");

                    b.Property<int?>("MedianPulse")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("date");

                    b.Property<int?>("VisitsAmount")
                        .HasColumnType("int");

                    b.Property<double?>("WeightData")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("StatisticsData");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.TrainType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TrainType");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Abonement", b =>
                {
                    b.HasOne("WebGym.Infrastructure.efModels.Client", "Client")
                        .WithMany("Abonements")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK__Abonement__Clien__33D4B598");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Account", b =>
                {
                    b.HasOne("WebGym.Infrastructure.efModels.RoleGroup", "Group")
                        .WithMany("Accounts")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK__Account__GroupId__276EDEB3")
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Attendance", b =>
                {
                    b.HasOne("WebGym.Infrastructure.efModels.Coach", "Coach")
                        .WithMany("Attendances")
                        .HasForeignKey("CoachId")
                        .HasConstraintName("FK__Attendanc__Coach__36B12243");

                    b.HasOne("WebGym.Infrastructure.efModels.StatisticsData", "StatisticsData")
                        .WithMany("Attendances")
                        .HasForeignKey("StatisticsDataId")
                        .HasConstraintName("FK__Attendanc__Stati__37A5467C");

                    b.Navigation("Coach");

                    b.Navigation("StatisticsData");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Client", b =>
                {
                    b.HasOne("WebGym.Infrastructure.efModels.Account", "Account")
                        .WithOne("Client")
                        .HasForeignKey("WebGym.Infrastructure.efModels.Client", "AccountId")
                        .HasConstraintName("FK__Client__AccountI__2C3393D0");

                    b.HasOne("WebGym.Infrastructure.efModels.StatisticsData", "StatisticsData")
                        .WithOne("Client")
                        .HasForeignKey("WebGym.Infrastructure.efModels.Client", "StatisticsDataId")
                        .HasConstraintName("FK__Client__Statisti__2D27B809");

                    b.Navigation("Account");

                    b.Navigation("StatisticsData");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Coach", b =>
                {
                    b.HasOne("WebGym.Infrastructure.efModels.Account", "Account")
                        .WithOne("Coach")
                        .HasForeignKey("WebGym.Infrastructure.efModels.Coach", "AccountId")
                        .HasConstraintName("FK__Coach__AccountId__30F848ED");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Position", b =>
                {
                    b.HasOne("WebGym.Infrastructure.efModels.Coach", "Coach")
                        .WithMany("Positions")
                        .HasForeignKey("CoachId")
                        .HasConstraintName("FK__Position__CoachI__48CFD27E");

                    b.HasOne("WebGym.Infrastructure.efModels.DayNamings", "DayNamings")
                        .WithMany("Positions")
                        .HasForeignKey("DayNamingsId")
                        .HasConstraintName("FK__Position__DayNam__46E78A0C");

                    b.HasOne("WebGym.Infrastructure.efModels.Schedule", "Schedule")
                        .WithMany("Positions")
                        .HasForeignKey("ScheduleId")
                        .HasConstraintName("FK__Position__Schedu__49C3F6B7");

                    b.HasOne("WebGym.Infrastructure.efModels.TrainType", "TrainType")
                        .WithMany("Positions")
                        .HasForeignKey("TrainTypeId")
                        .HasConstraintName("FK__Position__TrainT__47DBAE45");

                    b.Navigation("Coach");

                    b.Navigation("DayNamings");

                    b.Navigation("Schedule");

                    b.Navigation("TrainType");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.ServiceData", b =>
                {
                    b.HasOne("WebGym.Infrastructure.efModels.Abonement", "Abonement")
                        .WithMany("ServiceData")
                        .HasForeignKey("AbonementId")
                        .HasConstraintName("FK__ServiceDa__Abone__3C69FB99")
                        .IsRequired();

                    b.HasOne("WebGym.Infrastructure.efModels.Attendance", "Attendance")
                        .WithMany("ServiceData")
                        .HasForeignKey("AttendanceId")
                        .HasConstraintName("FK__ServiceDa__Atten__3D5E1FD2")
                        .IsRequired();

                    b.HasOne("WebGym.Infrastructure.efModels.ServiceDataType", "ServiceDataType")
                        .WithMany("ServiceData")
                        .HasForeignKey("ServiceDataTypeId")
                        .HasConstraintName("FK__ServiceDa__Servi__3E52440B");

                    b.Navigation("Abonement");

                    b.Navigation("Attendance");

                    b.Navigation("ServiceDataType");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Abonement", b =>
                {
                    b.Navigation("ServiceData");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Account", b =>
                {
                    b.Navigation("Client");

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Attendance", b =>
                {
                    b.Navigation("ServiceData");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Client", b =>
                {
                    b.Navigation("Abonements");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Coach", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Positions");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.DayNamings", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.RoleGroup", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.Schedule", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.ServiceDataType", b =>
                {
                    b.Navigation("ServiceData");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.StatisticsData", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("WebGym.Infrastructure.efModels.TrainType", b =>
                {
                    b.Navigation("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}
