﻿// <auto-generated />
using BowlingGame.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BowlingGame.Migrations
{
    [DbContext(typeof(BowlingDbContext))]
    partial class BowlingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BowlingGame.DAL.Models.FrameDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FrameNumber")
                        .HasColumnType("int");

                    b.Property<int>("ScoreCardId")
                        .HasColumnType("int");

                    b.Property<string>("Shot1")
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Shot2")
                        .HasColumnType("varchar(1)");

                    b.Property<string>("Shot3")
                        .HasColumnType("varchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("ScoreCardId");

                    b.ToTable("Frames");
                });

            modelBuilder.Entity("BowlingGame.DAL.Models.GameDTO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BowlingGame.DAL.Models.PlayerDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BowlingGame.DAL.Models.ScoreCardDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique();

                    b.ToTable("ScoreCards");
                });

            modelBuilder.Entity("BowlingGame.DAL.Models.FrameDTO", b =>
                {
                    b.HasOne("BowlingGame.DAL.Models.ScoreCardDTO", "ScoreCard")
                        .WithMany("Frames")
                        .HasForeignKey("ScoreCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScoreCard");
                });

            modelBuilder.Entity("BowlingGame.DAL.Models.PlayerDTO", b =>
                {
                    b.HasOne("BowlingGame.DAL.Models.GameDTO", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("BowlingGame.DAL.Models.ScoreCardDTO", b =>
                {
                    b.HasOne("BowlingGame.DAL.Models.PlayerDTO", "Player")
                        .WithOne("ScoreCard")
                        .HasForeignKey("BowlingGame.DAL.Models.ScoreCardDTO", "PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("BowlingGame.DAL.Models.GameDTO", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("BowlingGame.DAL.Models.PlayerDTO", b =>
                {
                    b.Navigation("ScoreCard")
                        .IsRequired();
                });

            modelBuilder.Entity("BowlingGame.DAL.Models.ScoreCardDTO", b =>
                {
                    b.Navigation("Frames");
                });
#pragma warning restore 612, 618
        }
    }
}
