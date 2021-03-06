﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizAPI.Data;

namespace QuizAPI.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210208172332_AddMathQuizAndNumberTable")]
    partial class AddMathQuizAndNumberTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("QuizAPI.Model.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NameString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("QuizAPI.Model.Answered", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PointEarned")
                        .HasColumnType("int");

                    b.Property<string>("QuestionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YourAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Answereds");
                });

            modelBuilder.Entity("QuizAPI.Model.MathQuiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.HasKey("Id");

                    b.ToTable("MathQuizzes");
                });

            modelBuilder.Entity("QuizAPI.Model.Number", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MathQuizId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MathQuizId");

                    b.ToTable("Numbers");
                });

            modelBuilder.Entity("QuizAPI.Model.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<bool>("isAnswered")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuizAPI.Model.Answer", b =>
                {
                    b.HasOne("QuizAPI.Model.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuizAPI.Model.Number", b =>
                {
                    b.HasOne("QuizAPI.Model.MathQuiz", "MathQuiz")
                        .WithMany("Numbers")
                        .HasForeignKey("MathQuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MathQuiz");
                });

            modelBuilder.Entity("QuizAPI.Model.MathQuiz", b =>
                {
                    b.Navigation("Numbers");
                });

            modelBuilder.Entity("QuizAPI.Model.Question", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
