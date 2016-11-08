using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UraApp.Repository.Infrastructure;

namespace UraApp.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20161104204921_MyMigration")]
    partial class MyMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UraApp.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("BusinessHours")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("City")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("ContactNo")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("EmaildId")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("State")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("WebsiteLink")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("ZipCode")
                        .HasAnnotation("MaxLength", 10);

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("UraApp.Models.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("Odr");

                    b.Property<string>("PortfolioDescription");

                    b.Property<string>("PortfolioName");

                    b.Property<int>("PortfolioType");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Portfolio");
                });

            modelBuilder.Entity("UraApp.Models.RoleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("RoleName");

                    b.HasKey("Id");

                    b.ToTable("RoleTypes");
                });

            modelBuilder.Entity("UraApp.Models.SocialNetwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("SocialNetwork");
                });

            modelBuilder.Entity("UraApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UraApp.Models.SocialNetwork", b =>
                {
                    b.HasOne("UraApp.Models.Company")
                        .WithMany("SocialNetworks")
                        .HasForeignKey("CompanyId");
                });
        }
    }
}
