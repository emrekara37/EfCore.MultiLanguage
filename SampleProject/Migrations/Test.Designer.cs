﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleProject;

namespace SampleProject.Migrations
{
    [DbContext(typeof(SampleDbContext))]
    [Migration("20210815152010_Test")]
    partial class Test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SampleProject.Language", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("SampleProject.Localization", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Localizations");
                });

            modelBuilder.Entity("SampleProject.LocalizationContent", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LocalizationId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageCode");

                    b.HasIndex("LocalizationId");

                    b.ToTable("LocalizationContents");
                });

            modelBuilder.Entity("SampleProject.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NameId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("SampleProject.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AboutId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SampleProject.LocalizationContent", b =>
                {
                    b.HasOne("SampleProject.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageCode");

                    b.HasOne("SampleProject.Localization", "Localization")
                        .WithMany("LocalizationContents")
                        .HasForeignKey("LocalizationId");

                    b.Navigation("Language");

                    b.Navigation("Localization");
                });

            modelBuilder.Entity("SampleProject.Post", b =>
                {
                    b.HasOne("SampleProject.Localization", "Name")
                        .WithMany()
                        .HasForeignKey("NameId");

                    b.Navigation("Name");
                });

            modelBuilder.Entity("SampleProject.User", b =>
                {
                    b.HasOne("SampleProject.Localization", "About")
                        .WithMany()
                        .HasForeignKey("AboutId");

                    b.Navigation("About");
                });

            modelBuilder.Entity("SampleProject.Localization", b =>
                {
                    b.Navigation("LocalizationContents");
                });
#pragma warning restore 612, 618
        }
    }
}
