﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zahradneek.Api.Data;

#nullable disable

namespace Zahradneek.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230507093119_ChangedTypeOfCoordinates")]
    partial class ChangedTypeOfCoordinates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Zahradneek.Api.Models.Coordinate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<double>("Latitude")
                        .HasColumnType("double")
                        .HasColumnName("latitude");

                    b.Property<double>("Longitude")
                        .HasColumnType("double")
                        .HasColumnName("longitude");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_at");

                    b.Property<int>("ParcelId")
                        .HasColumnType("int")
                        .HasColumnName("parcel_id");

                    b.HasKey("Id")
                        .HasName("pk_coordinates");

                    b.HasIndex("ParcelId")
                        .HasDatabaseName("ix_coordinates_parcel_id");

                    b.ToTable("coordinates", (string)null);
                });

            modelBuilder.Entity("Zahradneek.Api.Models.Parcel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_at");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int")
                        .HasColumnName("owner_id");

                    b.HasKey("Id")
                        .HasName("pk_parcels");

                    b.HasIndex("OwnerId")
                        .HasDatabaseName("ix_parcels_owner_id");

                    b.ToTable("parcels", (string)null);
                });

            modelBuilder.Entity("Zahradneek.Api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("last_name");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("modified_at");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("phone_number");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Zahradneek.Api.Models.Coordinate", b =>
                {
                    b.HasOne("Zahradneek.Api.Models.Parcel", "Parcel")
                        .WithMany("Coordinates")
                        .HasForeignKey("ParcelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_coordinates_parcels_parcel_id");

                    b.Navigation("Parcel");
                });

            modelBuilder.Entity("Zahradneek.Api.Models.Parcel", b =>
                {
                    b.HasOne("Zahradneek.Api.Models.User", "Owner")
                        .WithMany("Parcels")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_parcels_users_owner_id");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Zahradneek.Api.Models.Parcel", b =>
                {
                    b.Navigation("Coordinates");
                });

            modelBuilder.Entity("Zahradneek.Api.Models.User", b =>
                {
                    b.Navigation("Parcels");
                });
#pragma warning restore 612, 618
        }
    }
}
