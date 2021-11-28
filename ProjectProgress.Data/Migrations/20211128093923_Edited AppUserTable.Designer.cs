﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectProgress.Data;

namespace ProjectProgress.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211128093923_Edited AppUserTable")]
    partial class EditedAppUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectProgress.Domain.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar");

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("LastName");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AppUser");

                    b.HasData(
                        new { Id = 1, CreatedDate = new DateTime(2021, 11, 28, 13, 9, 22, 851, DateTimeKind.Local), IsAdmin = false, Password = "$HASH|V1$10000$84VEIZZKQddLzOLmelRXPgUeKpdKC4LUavU6ersN0ZlZpz8d", UserName = "admin" }
                    );
                });

            modelBuilder.Entity("ProjectProgress.Domain.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("FileName");

                    b.Property<string>("FileType");

                    b.Property<bool>("IsDelete");

                    b.Property<int>("ObjectId");

                    b.Property<string>("Remark");

                    b.Property<Guid>("StreamId");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ObjectId");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("ProjectProgress.Domain.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<bool>("IsDelete");

                    b.Property<int>("ItemsType");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("ParentId");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("ProjectProgress.Domain.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedBy");

                    b.Property<string>("CreatedByIp");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<DateTime>("ExpiryDate");

                    b.Property<bool>("IsUsed");

                    b.Property<string>("JwtId");

                    b.Property<DateTime?>("Revoked");

                    b.Property<string>("RevokedByIp");

                    b.Property<string>("Token");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("ProjectProgress.Domain.Attachment", b =>
                {
                    b.HasOne("ProjectProgress.Domain.AppUser", "User")
                        .WithMany("Attachments")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("ProjectProgress.Domain.Item", "Item")
                        .WithMany("Attachments")
                        .HasForeignKey("ObjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectProgress.Domain.Item", b =>
                {
                    b.HasOne("ProjectProgress.Domain.Item", "GetItem")
                        .WithMany("Items")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("ProjectProgress.Domain.RefreshToken", b =>
                {
                    b.HasOne("ProjectProgress.Domain.AppUser", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("CreatedBy");
                });
#pragma warning restore 612, 618
        }
    }
}
