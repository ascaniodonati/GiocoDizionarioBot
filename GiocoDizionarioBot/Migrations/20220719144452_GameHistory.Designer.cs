﻿// <auto-generated />
using GiocoDizionarioBot.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GiocoDizionarioBot.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20220719144452_GameHistory")]
    partial class GameHistory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GiocoDizionarioBot.Models.GameHistory", b =>
                {
                    b.Property<long>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("GameId"), 1L, 1);

                    b.HasKey("GameId");

                    b.ToTable("GamesHistory");
                });

            modelBuilder.Entity("GiocoDizionarioBot.Models.Group", b =>
                {
                    b.Property<long>("TelegramGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TelegramGroupId"), 1L, 1);

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TelegramGroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("GiocoDizionarioBot.Models.Player", b =>
                {
                    b.Property<long>("TelegramID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TelegramID"), 1L, 1);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TelegramID");

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
