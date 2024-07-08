﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecondHomework.Infraestructure.Persistence.Context;

#nullable disable

namespace SecondHomework.Infraestructure.Persistence.Migrations
{
    [DbContext(typeof(SecondHomeworkContext))]
    partial class SecondHomeworkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.Dish", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountOfPeople")
                        .HasColumnType("int");

                    b.Property<int>("DishCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DishCategoryId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("DishCategoryId"), false);

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.DishCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DishCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Entry"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Strong Dish"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Dessert"
                        },
                        new
                        {
                            Id = 4,
                            Name = "beverages"
                        });
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.DishIngridient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DishId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngridientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("DishId"), false);

                    b.HasIndex("IngridientId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("IngridientId"), false);

                    b.ToTable("DishIngridients");
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<double>("SubAmount")
                        .HasColumnType("float");

                    b.Property<Guid>("TableThatOrderIsFor")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TableThatOrderIsFor");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("TableThatOrderIsFor"), false);

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.OrderDish", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DishId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("DishId"), false);

                    b.HasIndex("OrderId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("OrderId"), false);

                    b.ToTable("OrderDishes");
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.Table", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountOfPeople")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TableStateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TableStateId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("TableStateId"), false);

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.TableState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TableStates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Avalible"
                        },
                        new
                        {
                            Id = 2,
                            Name = "InProcces"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Attended"
                        });
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.Dish", b =>
                {
                    b.HasOne("SecondHomework.Core.Domain.Entities.DishCategory", "DishCategory")
                        .WithMany("Dishes")
                        .HasForeignKey("DishCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DishCategory");
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.DishIngridient", b =>
                {
                    b.HasOne("SecondHomework.Core.Domain.Entities.Dish", "Dish")
                        .WithMany("DishIngridients")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecondHomework.Core.Domain.Entities.Ingredient", "Ingredient")
                        .WithMany("DishIngridients")
                        .HasForeignKey("IngridientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.Order", b =>
                {
                    b.HasOne("SecondHomework.Core.Domain.Entities.Table", "Table")
                        .WithMany("Orders")
                        .HasForeignKey("TableThatOrderIsFor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Table");
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.OrderDish", b =>
                {
                    b.HasOne("SecondHomework.Core.Domain.Entities.Dish", "Dish")
                        .WithMany("OrderDishes")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecondHomework.Core.Domain.Entities.Order", "Order")
                        .WithMany("OrderDishes")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.Table", b =>
                {
                    b.HasOne("SecondHomework.Core.Domain.Entities.TableState", "TableState")
                        .WithMany("Tables")
                        .HasForeignKey("TableStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TableState");
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.Dish", b =>
                {
                    b.Navigation("DishIngridients");

                    b.Navigation("OrderDishes");
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.DishCategory", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.Ingredient", b =>
                {
                    b.Navigation("DishIngridients");
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderDishes");
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.Table", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("SecondHomework.Core.Domain.Entities.TableState", b =>
                {
                    b.Navigation("Tables");
                });
#pragma warning restore 612, 618
        }
    }
}