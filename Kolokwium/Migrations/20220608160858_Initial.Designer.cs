﻿// <auto-generated />
using System;
using Kolokwium.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kolokwium.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220608160858_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Kolokwium.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GameName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Kolokwium.Entities.Match", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FirstTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatchResult")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SecondTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WinnerTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FirstTeamId");

                    b.HasIndex("GameId");

                    b.HasIndex("SecondTeamId");

                    b.HasIndex("WinnerTeamId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Kolokwium.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Kolokwium.Entities.Match", b =>
                {
                    b.HasOne("Kolokwium.Entities.Team", "FirstTeam")
                        .WithMany()
                        .HasForeignKey("FirstTeamId");

                    b.HasOne("Kolokwium.Entities.Game", "GameType")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.HasOne("Kolokwium.Entities.Team", "SecondTeam")
                        .WithMany()
                        .HasForeignKey("SecondTeamId");

                    b.HasOne("Kolokwium.Entities.Team", "WinnerTeam")
                        .WithMany()
                        .HasForeignKey("WinnerTeamId");

                    b.Navigation("FirstTeam");

                    b.Navigation("GameType");

                    b.Navigation("SecondTeam");

                    b.Navigation("WinnerTeam");
                });
#pragma warning restore 612, 618
        }
    }
}
