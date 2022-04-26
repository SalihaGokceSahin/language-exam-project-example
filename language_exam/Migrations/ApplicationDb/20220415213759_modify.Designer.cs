﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using language_exam.Models;

namespace language_exam.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220415213759_modify")]
    partial class modify
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("language_exam.Models.Exams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("answer_1_a_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_1_b_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_1_c_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_1_d_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_2_a_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_2_b_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_2_c_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_2_d_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_3_a_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_3_b_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_3_c_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_3_d_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_4_a_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_4_b_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_4_c_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_4_d_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correct_1_answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correct_2_answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correct_3_answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correct_4_answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("matchId")
                        .HasColumnType("int");

                    b.Property<string>("question_1_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("question_2_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("question_3_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("question_4_text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("matchId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("language_exam.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("answer_a_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_b_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_c_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("answer_d_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correct_answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("matchId")
                        .HasColumnType("int");

                    b.Property<string>("question_text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("matchId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("language_exam.Models.match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("context")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("outerHtml_href_for_link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("language_exam.Models.Exams", b =>
                {
                    b.HasOne("language_exam.Models.match", "match")
                        .WithMany("Exams")
                        .HasForeignKey("matchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("language_exam.Models.Question", b =>
                {
                    b.HasOne("language_exam.Models.match", "match")
                        .WithMany("Questions")
                        .HasForeignKey("matchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
