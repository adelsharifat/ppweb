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
    [Migration("20211027124302_Added Vlue")]
    partial class AddedVlue
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectProgress.Domain.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("DeletedBy");

                    b.Property<DateTime?>("DeletedDate");

                    b.Property<string>("Name");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("AppRole");

                    b.HasData(
                        new { Id = 1, CreatedDate = new DateTime(2021, 10, 27, 16, 13, 1, 928, DateTimeKind.Local), Name = "admin" },
                        new { Id = 2, CreatedDate = new DateTime(2021, 10, 27, 16, 13, 1, 929, DateTimeKind.Local), Name = "user" }
                    );
                });

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

                    b.Property<string>("LastName");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Salt")
                        .IsRequired();

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AppUser");

                    b.HasData(
                        new { Id = 1, CreatedDate = new DateTime(2021, 10, 27, 16, 13, 1, 937, DateTimeKind.Local), Password = "figwXMBSv4L7ZViuIxZJHZzxAxhBk0bXsnTkoSSs2SAFue1WuQONnn3K0Z6PEiTIp1iGutFtAYu44Aphp94i3KY5ZEf0oA==", Salt = "HtvxPsPydkDbq5sM8xvo4Z6hCgpw3SjNzP8PGR6Wfkwwvs45rtMf1wTennSHHQc1xBvaKKhM8eN1M5CWzR4fC03cn4UiOA==", UserName = "admin" }
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

                    b.Property<int?>("ObjectId");

                    b.Property<string>("Remark");

                    b.Property<Guid>("StreamId");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ObjectId");

                    b.HasIndex("UserId");

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("ParentId");

                    b.Property<int?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

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

            modelBuilder.Entity("ProjectProgress.Domain.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");

                    b.HasData(
                        new { UserId = 1, RoleId = 1 },
                        new { UserId = 1, RoleId = 2 }
                    );
                });

            modelBuilder.Entity("ProjectProgress.Domain.Attachment", b =>
                {
                    b.HasOne("ProjectProgress.Domain.Item", "Item")
                        .WithMany("Attachments")
                        .HasForeignKey("ObjectId");

                    b.HasOne("ProjectProgress.Domain.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ProjectProgress.Domain.Item", b =>
                {
                    b.HasOne("ProjectProgress.Domain.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ProjectProgress.Domain.RefreshToken", b =>
                {
                    b.HasOne("ProjectProgress.Domain.AppUser", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("CreatedBy");
                });

            modelBuilder.Entity("ProjectProgress.Domain.UserRole", b =>
                {
                    b.HasOne("ProjectProgress.Domain.AppRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectProgress.Domain.AppUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
