﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using hello.question.api.Models;

namespace hello.question.api.Migrations
{
    [DbContext(typeof(NorthwindContext))]
    partial class NorthwindContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("hello.question.api.Models.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<Guid>("ParticipantId");

                    b.Property<Guid>("SubQuestionId");

                    b.Property<string>("Text")
                        .HasMaxLength(1000);

                    b.Property<Guid>("Value");

                    b.HasKey("Id");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("hello.question.api.Models.Choise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("By")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .HasMaxLength(1000);

                    b.Property<string>("Status")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Choise");
                });

            modelBuilder.Entity("hello.question.api.Models.Participant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("By")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(500);

                    b.Property<Guid>("SessionId");

                    b.Property<string>("Status")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("hello.question.api.Models.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("By")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<int>("Order");

                    b.Property<string>("Status")
                        .HasMaxLength(20);

                    b.Property<string>("Title")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("hello.question.api.Models.SubChoise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AllowSelect");

                    b.Property<Guid>("ChoiseId");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<int>("Order");

                    b.Property<string>("Title")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("SubChoise");
                });

            modelBuilder.Entity("hello.question.api.Models.SubQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("By")
                        .HasMaxLength(50);

                    b.Property<Guid?>("ChoiseId");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<int>("Order");

                    b.Property<Guid>("QuestionId");

                    b.Property<string>("Status")
                        .HasMaxLength(20);

                    b.Property<string>("Type")
                        .HasMaxLength(10);

                    b.Property<string>("Value")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.ToTable("SubQuestion");
                });
#pragma warning restore 612, 618
        }
    }
}
