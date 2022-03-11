﻿// <auto-generated />
using Dukkantek.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dukkantek.Data.Migrations
{
    [DbContext(typeof(DukkantekApiDbContext))]
    partial class DukkantekApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dukkantek.Data.Models.Products.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "coffee/tea, juice, soda",
                            Name = "Beverages"
                        },
                        new
                        {
                            Id = 2,
                            Description = "sandwich loaves, dinner rolls, tortillas, bagels",
                            Name = "Bread/Bakery"
                        });
                });

            modelBuilder.Entity("Dukkantek.Data.Models.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Barcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Barcode = "000001",
                            Description = "soda/ soft drink",
                            Name = "CocaCola",
                            Status = 1,
                            Weight = 0.5
                        },
                        new
                        {
                            Id = 2,
                            Barcode = "000002",
                            Description = "soda/ soft drink",
                            Name = "Pepsi",
                            Status = 1,
                            Weight = 0.5
                        },
                        new
                        {
                            Id = 3,
                            Barcode = "000003",
                            Description = "A croissant is a buttery, flaky, viennoiserie pastry of Austrian origin",
                            Name = "Croissant",
                            Status = 1,
                            Weight = 0.5
                        },
                        new
                        {
                            Id = 4,
                            Barcode = "000004",
                            Description = "A pancake is a flat cake, often thin and round",
                            Name = "Pancake",
                            Status = 1,
                            Weight = 0.5
                        });
                });

            modelBuilder.Entity("Dukkantek.Data.Models.Products.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2
                        });
                });

            modelBuilder.Entity("Dukkantek.Data.Models.Products.ProductCategory", b =>
                {
                    b.HasOne("Dukkantek.Data.Models.Products.Category", "Category")
                        .WithMany("CategoryProducts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dukkantek.Data.Models.Products.Product", "Product")
                        .WithMany("ProductCategory")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Dukkantek.Data.Models.Products.Category", b =>
                {
                    b.Navigation("CategoryProducts");
                });

            modelBuilder.Entity("Dukkantek.Data.Models.Products.Product", b =>
                {
                    b.Navigation("ProductCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
