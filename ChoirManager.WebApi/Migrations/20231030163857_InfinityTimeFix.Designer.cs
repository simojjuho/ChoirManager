﻿// <auto-generated />
using System;
using ChoirManager.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChoirManager.WebApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231030163857_InfinityTimeFix")]
    partial class InfinityTimeFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChoirManager.Core.CoreEntities.Choir", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateOnly>("FoundedAt")
                        .HasColumnType("date")
                        .HasColumnName("founded_at");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_choirs");

                    b.HasIndex("Name")
                        .HasDatabaseName("ix_choirs_name");

                    b.ToTable("choirs", (string)null);
                });

            modelBuilder.Entity("ChoirManager.Core.CoreEntities.ChoirUser", b =>
                {
                    b.Property<Guid>("ChoirId")
                        .HasColumnType("uuid")
                        .HasColumnName("choir_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("MembershipStatus")
                        .HasColumnType("integer")
                        .HasColumnName("membership_status");

                    b.Property<int>("RegisterFourFold")
                        .HasColumnType("integer")
                        .HasColumnName("register_four_fold");

                    b.Property<int>("RegisterThreeFold")
                        .HasColumnType("integer")
                        .HasColumnName("register_three_fold");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("UserRole")
                        .HasColumnType("integer")
                        .HasColumnName("user_role");

                    b.HasKey("ChoirId", "UserId")
                        .HasName("pk_choir_users");

                    b.ToTable("choir_users", (string)null);
                });

            modelBuilder.Entity("ChoirManager.Core.CoreEntities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ChoirId")
                        .HasColumnType("uuid")
                        .HasColumnName("choir_id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime?>("EndingTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("ending_time");

                    b.Property<int>("EventType")
                        .HasColumnType("integer")
                        .HasColumnName("event_type");

                    b.Property<DateTime>("StartingTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("starting_time");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("VenueId")
                        .HasColumnType("uuid")
                        .HasColumnName("venue_id");

                    b.HasKey("Id")
                        .HasName("pk_events");

                    b.HasIndex("ChoirId")
                        .HasDatabaseName("ix_events_choir_id");

                    b.HasIndex("VenueId")
                        .HasDatabaseName("ix_events_venue_id");

                    b.ToTable("events", (string)null);
                });

            modelBuilder.Entity("ChoirManager.Core.CoreEntities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("text")
                        .HasColumnName("verification_token");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .HasDatabaseName("ix_users_email");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("ChoirManager.Core.CoreEntities.Venue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("contact_name");

                    b.Property<string>("ContactPhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("contact_phone_number");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("street_address");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("town");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("zip_code");

                    b.HasKey("Id")
                        .HasName("pk_venues");

                    b.ToTable("venues", (string)null);
                });

            modelBuilder.Entity("ChoirManager.Core.CoreEntities.Event", b =>
                {
                    b.HasOne("ChoirManager.Core.CoreEntities.Choir", "Choir")
                        .WithMany()
                        .HasForeignKey("ChoirId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_events_choirs_choir_id");

                    b.HasOne("ChoirManager.Core.CoreEntities.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_events_venues_venue_id");

                    b.Navigation("Choir");

                    b.Navigation("Venue");
                });
#pragma warning restore 612, 618
        }
    }
}
