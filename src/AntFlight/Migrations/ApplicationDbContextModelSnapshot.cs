using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AntFlight.Data;

namespace AntFlight.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AntFlight.Models.Ants.Ant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GenusId");

                    b.Property<string>("SpeciesName")
                        .HasAnnotation("MaxLength", 60);

                    b.Property<int?>("SubgenusId");

                    b.HasKey("Id");

                    b.HasIndex("GenusId");

                    b.HasIndex("SubgenusId");

                    b.ToTable("Ants");
                });

            modelBuilder.Entity("AntFlight.Models.Ants.Genus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GenusName")
                        .HasAnnotation("MaxLength", 30);

                    b.Property<int>("SubfamilieId");

                    b.HasKey("Id");

                    b.HasIndex("SubfamilieId");

                    b.ToTable("Genuses");
                });

            modelBuilder.Entity("AntFlight.Models.Ants.OriginalFlightTime", b =>
                {
                    b.Property<int>("AntId");

                    b.Property<DateTime>("FlightEnd");

                    b.Property<DateTime>("FlightStart");

                    b.Property<string>("SourceName")
                        .HasAnnotation("MaxLength", 150);

                    b.HasKey("AntId");

                    b.HasIndex("AntId")
                        .IsUnique();

                    b.ToTable("OriginalFlightTime");
                });

            modelBuilder.Entity("AntFlight.Models.Ants.Subfamilie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SubfamilieName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("Id");

                    b.ToTable("Subfamilies");
                });

            modelBuilder.Entity("AntFlight.Models.Ants.Subgenus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GenusId");

                    b.Property<string>("SubgenusName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("Id");

                    b.HasIndex("GenusId");

                    b.ToTable("Subgenuses");
                });

            modelBuilder.Entity("AntFlight.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AntFlight.Models.FlightMessages.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("AntFlight.Models.FlightMessages.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("AntFlight.Models.FlightMessages.FlightMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AntId");

                    b.Property<int>("CityId");

                    b.Property<DateTime>("FlightTime");

                    b.Property<DateTime>("MessageTime");

                    b.Property<string>("UserId")
                        .HasAnnotation("MaxLength", 450);

                    b.HasKey("Id");

                    b.HasIndex("AntId");

                    b.HasIndex("CityId");

                    b.HasIndex("UserId");

                    b.ToTable("FlightMessages");
                });

            modelBuilder.Entity("AntFlight.Models.FlightMessages.FlightMessageDescription", b =>
                {
                    b.Property<int>("FlightMessageId");

                    b.Property<string>("Description");

                    b.Property<byte>("FlightIntensity");

                    b.Property<byte>("Precipitation");

                    b.Property<byte>("Sky");

                    b.Property<byte>("Temperature");

                    b.Property<byte>("Terrain");

                    b.Property<byte>("Wind");

                    b.HasKey("FlightMessageId");

                    b.HasIndex("FlightMessageId")
                        .IsUnique();

                    b.ToTable("FlightMessagesDescr");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AntFlight.Models.Ants.Ant", b =>
                {
                    b.HasOne("AntFlight.Models.Ants.Genus", "Genus")
                        .WithMany()
                        .HasForeignKey("GenusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AntFlight.Models.Ants.Subgenus", "Subgenus")
                        .WithMany()
                        .HasForeignKey("SubgenusId");
                });

            modelBuilder.Entity("AntFlight.Models.Ants.Genus", b =>
                {
                    b.HasOne("AntFlight.Models.Ants.Subfamilie", "Subfamilie")
                        .WithMany()
                        .HasForeignKey("SubfamilieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AntFlight.Models.Ants.OriginalFlightTime", b =>
                {
                    b.HasOne("AntFlight.Models.Ants.Ant", "Ant")
                        .WithOne("OriginalFlightTime")
                        .HasForeignKey("AntFlight.Models.Ants.OriginalFlightTime", "AntId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AntFlight.Models.Ants.Subgenus", b =>
                {
                    b.HasOne("AntFlight.Models.Ants.Genus", "Genus")
                        .WithMany()
                        .HasForeignKey("GenusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AntFlight.Models.FlightMessages.City", b =>
                {
                    b.HasOne("AntFlight.Models.FlightMessages.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AntFlight.Models.FlightMessages.FlightMessage", b =>
                {
                    b.HasOne("AntFlight.Models.Ants.Ant", "Ant")
                        .WithMany("FlightMessages")
                        .HasForeignKey("AntId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AntFlight.Models.FlightMessages.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AntFlight.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AntFlight.Models.FlightMessages.FlightMessageDescription", b =>
                {
                    b.HasOne("AntFlight.Models.FlightMessages.FlightMessage", "FlightMessage")
                        .WithOne("FMDescription")
                        .HasForeignKey("AntFlight.Models.FlightMessages.FlightMessageDescription", "FlightMessageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AntFlight.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AntFlight.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AntFlight.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
