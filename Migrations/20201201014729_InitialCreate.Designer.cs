﻿// <auto-generated />
using HawkSoftContactsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HawkSoftContactsApi.Migrations
{
    [DbContext(typeof(UserContactsContext))]
    [Migration("20201201014729_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HawkSoftContactsApi.Data.UserContact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT")
                        .HasColumnName("last_name");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT")
                        .HasColumnName("username");

                    b.HasKey("ContactId");

                    b.HasIndex("Username");

                    b.ToTable("Contact");
                });
#pragma warning restore 612, 618
        }
    }
}
