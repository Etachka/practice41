﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using practice.Database;

#nullable disable

namespace practice.Migrations
{
    [DbContext(typeof(PracticeContext))]
    [Migration("20240126111502_www")]
    partial class www
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("practice.Models.Action", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ActionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("DayNumber")
                        .HasColumnType("integer");

                    b.Property<int?>("IdIvent")
                        .HasColumnType("integer");

                    b.Property<int>("IventId")
                        .HasColumnType("integer");

                    b.Property<int>("ModeratorId")
                        .HasColumnType("integer");

                    b.Property<string>("ModeratorName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("OrganizerID")
                        .HasColumnType("integer");

                    b.Property<int>("OrganizersId")
                        .HasColumnType("integer");

                    b.Property<TimeOnly?>("TimeBegin")
                        .HasColumnType("time without time zone");

                    b.HasKey("ID");

                    b.HasIndex("IventId");

                    b.HasIndex("ModeratorId");

                    b.HasIndex("OrganizersId");

                    b.ToTable("Action");
                });

            modelBuilder.Entity("practice.Models.ActionJury", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ActionId")
                        .HasColumnType("integer");

                    b.Property<int>("JuryID")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("JuryID");

                    b.ToTable("ActionJury");
                });

            modelBuilder.Entity("practice.Models.ActivitiesInformationSecurity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("City")
                        .HasColumnType("integer");

                    b.Property<DateOnly?>("Data")
                        .HasColumnType("date");

                    b.Property<int?>("Days")
                        .HasColumnType("integer");

                    b.Property<string>("Ivent")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("Id");

                    b.ToTable("ActivitiesInformationSecurity");
                });

            modelBuilder.Entity("practice.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("practice.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.Property<int>("CodeNumber")
                        .HasColumnType("integer");

                    b.Property<string>("CountryEngName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("practice.Models.Direction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DirectionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("practice.Models.Ivent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("DateBegin")
                        .HasColumnType("date");

                    b.Property<int?>("DurationDays")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IventName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Winner")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Ivent");
                });

            modelBuilder.Entity("practice.Models.Jury", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateOnly?>("Birthday")
                        .HasColumnType("date");

                    b.Property<int?>("Country")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int?>("DirectionId")
                        .HasColumnType("integer");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("IdNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Photo")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<char?>("gender")
                        .HasColumnType("character(1)");

                    b.HasKey("Id");

                    b.HasIndex("DirectionId");

                    b.ToTable("Jury");
                });

            modelBuilder.Entity("practice.Models.Moderator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateOnly?>("Birthday")
                        .HasColumnType("date");

                    b.Property<int>("CountryID")
                        .HasColumnType("integer");

                    b.Property<int>("DirectionId")
                        .HasColumnType("integer");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<char?>("Gender")
                        .HasColumnType("character(1)");

                    b.Property<string>("Mail")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.HasKey("Id");

                    b.HasIndex("CountryID");

                    b.HasIndex("DirectionId");

                    b.ToTable("Moderators");
                });

            modelBuilder.Entity("practice.Models.Organizers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("Birthday")
                        .HasColumnType("date");

                    b.Property<int?>("CountryID")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<char?>("Gender")
                        .HasColumnType("character(1)");

                    b.Property<int>("IdNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Photo")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.HasKey("Id");

                    b.HasIndex("CountryID");

                    b.ToTable("Organizers");
                });

            modelBuilder.Entity("practice.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("Birthday")
                        .HasColumnType("date");

                    b.Property<int?>("CountryID")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<char?>("Gender")
                        .HasColumnType("character(1)");

                    b.Property<int>("IdNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Photo")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.HasKey("Id");

                    b.HasIndex("CountryID");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("practice.Models.Action", b =>
                {
                    b.HasOne("practice.Models.Ivent", "Ivent")
                        .WithMany()
                        .HasForeignKey("IventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("practice.Models.Moderator", "Moderator")
                        .WithMany()
                        .HasForeignKey("ModeratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("practice.Models.Organizers", "Organizers")
                        .WithMany()
                        .HasForeignKey("OrganizersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ivent");

                    b.Navigation("Moderator");

                    b.Navigation("Organizers");
                });

            modelBuilder.Entity("practice.Models.ActionJury", b =>
                {
                    b.HasOne("practice.Models.Action", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId");

                    b.HasOne("practice.Models.Jury", "Jury")
                        .WithMany()
                        .HasForeignKey("JuryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("Jury");
                });

            modelBuilder.Entity("practice.Models.Jury", b =>
                {
                    b.HasOne("practice.Models.Direction", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionId");

                    b.Navigation("Direction");
                });

            modelBuilder.Entity("practice.Models.Moderator", b =>
                {
                    b.HasOne("practice.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("practice.Models.Direction", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Direction");
                });

            modelBuilder.Entity("practice.Models.Organizers", b =>
                {
                    b.HasOne("practice.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("practice.Models.Participant", b =>
                {
                    b.HasOne("practice.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
