﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveysApp.Data;

#nullable disable

namespace SurveysApp.Migrations
{
    [DbContext(typeof(SurveyDbContext))]
    partial class SurveyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SurveysApp.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChoiceId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int?>("ResponseId")
                        .HasColumnType("int");

                    b.Property<int?>("SurveyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("ResponseId");

                    b.HasIndex("SurveyId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("SurveysApp.Models.Choice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("SurveysApp.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("SurveyId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("SurveysApp.Models.Response", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChoiceId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int?>("SurveyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("SurveysApp.Models.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("SurveysApp.Models.Answer", b =>
                {
                    b.HasOne("SurveysApp.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SurveysApp.Models.Response", "Response")
                        .WithMany()
                        .HasForeignKey("ResponseId");

                    b.HasOne("SurveysApp.Models.Survey", null)
                        .WithMany("Answers")
                        .HasForeignKey("SurveyId");

                    b.Navigation("Question");

                    b.Navigation("Response");
                });

            modelBuilder.Entity("SurveysApp.Models.Choice", b =>
                {
                    b.HasOne("SurveysApp.Models.Question", null)
                        .WithMany("Choices")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("SurveysApp.Models.Question", b =>
                {
                    b.HasOne("SurveysApp.Models.Survey", null)
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId");
                });

            modelBuilder.Entity("SurveysApp.Models.Response", b =>
                {
                    b.HasOne("SurveysApp.Models.Survey", null)
                        .WithMany("Responses")
                        .HasForeignKey("SurveyId");
                });

            modelBuilder.Entity("SurveysApp.Models.Question", b =>
                {
                    b.Navigation("Choices");
                });

            modelBuilder.Entity("SurveysApp.Models.Survey", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Questions");

                    b.Navigation("Responses");
                });
#pragma warning restore 612, 618
        }
    }
}
