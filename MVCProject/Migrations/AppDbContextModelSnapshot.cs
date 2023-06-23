﻿// <auto-generated />
using System;
using MVCProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVCProject.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("MVCProject.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GoverId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("ShippingCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("GoverId");

                    b.ToTable("Cities");
                });

<<<<<<< HEAD
=======
            modelBuilder.Entity("MVCProject.Models.DeliverType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeliverTypes");
                });

>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00
            modelBuilder.Entity("MVCProject.Models.DiscountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Percentage")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DiscountTypes");
                });

            modelBuilder.Entity("MVCProject.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

<<<<<<< HEAD
            modelBuilder.Entity("MVCProject.Models.Governorate", b =>
=======
            modelBuilder.Entity("MVCProject.Models.Government", b =>
>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("governorates");
                });

<<<<<<< HEAD
=======
            modelBuilder.Entity("MVCProject.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("ClientCityId")
                        .HasColumnType("int");

                    b.Property<string>("ClientEmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientGovernorateId")
                        .HasColumnType("int");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientPhone1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientPhone2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DeliverToVillage")
                        .HasColumnType("bit");

                    b.Property<int>("DeliveryTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("OrderStateId")
                        .HasColumnType("int");

                    b.Property<int>("OrderTypeId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<int>("TraderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("ClientCityId");

                    b.HasIndex("ClientGovernorateId");

                    b.HasIndex("DeliveryTypeId");

                    b.HasIndex("OrderStateId");

                    b.HasIndex("OrderTypeId");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("TraderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MVCProject.Models.OrderState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderStates");
                });

            modelBuilder.Entity("MVCProject.Models.OrderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("OrderTypes");
                });

            modelBuilder.Entity("MVCProject.Models.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("MVCProject.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Products");
                });

>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00
            modelBuilder.Entity("MVCProject.Models.Representative", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<decimal>("CompanyPercentageOfOrder")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("DiscountTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GovernorateId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("DiscountTypeId");

                    b.HasIndex("GovernorateId");

                    b.ToTable("Representatives");
                });

            modelBuilder.Entity("MVCProject.Models.Trader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GoverId")
                        .HasColumnType("int");

<<<<<<< HEAD
=======
                    b.Property<int?>("GovernorateId")
                        .HasColumnType("int");

>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00
                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpecialPickupCost")
                        .HasColumnType("int");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TraderTaxForRejectedOrders")
                        .HasColumnType("int");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CityId");

<<<<<<< HEAD
                    b.HasIndex("GoverId");
=======
                    b.HasIndex("GovernorateId");
>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00

                    b.ToTable("Trader");
                });

            modelBuilder.Entity("MVCProject.Models.TraderSpecialPriceForCities", b =>
                {
<<<<<<< HEAD
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));
=======
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));
>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Shippingprice")
                        .HasColumnType("int");

                    b.Property<int>("TraderId")
                        .HasColumnType("int");

<<<<<<< HEAD
                    b.HasKey("id");
=======
                    b.HasKey("Id");
>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00

                    b.HasIndex("CityId");

                    b.HasIndex("TraderId");

<<<<<<< HEAD
                    b.ToTable("traderSpecialPriceForCities");
=======
                    b.ToTable("TraderSpecialPriceForCities");
                });

            modelBuilder.Entity("MVCProject.Models.WeightSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("DefaultSize")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PriceForEachExtraKilo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WeightSetting");
>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00
                });

            modelBuilder.Entity("MVCProject.Models.City", b =>
                {
<<<<<<< HEAD
                    b.HasOne("MVCProject.Models.Governorate", "Governorate")
                        .WithMany("City")
=======
                    b.HasOne("MVCProject.Models.Government", "Governorate")
                        .WithMany("Cities")
>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00
                        .HasForeignKey("GoverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Governorate");
                });

<<<<<<< HEAD
=======
            modelBuilder.Entity("MVCProject.Models.Order", b =>
                {
                    b.HasOne("MVCProject.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCProject.Models.City", "ClientCity")
                        .WithMany()
                        .HasForeignKey("ClientCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCProject.Models.Government", "ClientGovernorate")
                        .WithMany()
                        .HasForeignKey("ClientGovernorateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCProject.Models.DeliverType", "DeliverType")
                        .WithMany()
                        .HasForeignKey("DeliveryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCProject.Models.OrderState", "OrderState")
                        .WithMany()
                        .HasForeignKey("OrderStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCProject.Models.OrderType", "OrderType")
                        .WithMany()
                        .HasForeignKey("OrderTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCProject.Models.PaymentMethod", "PaymentMethod")
                        .WithMany()
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCProject.Models.Trader", "Trader")
                        .WithMany("Orders")
                        .HasForeignKey("TraderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("ClientCity");

                    b.Navigation("ClientGovernorate");

                    b.Navigation("DeliverType");

                    b.Navigation("OrderState");

                    b.Navigation("OrderType");

                    b.Navigation("PaymentMethod");

                    b.Navigation("Trader");
                });

            modelBuilder.Entity("MVCProject.Models.Product", b =>
                {
                    b.HasOne("MVCProject.Models.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00
            modelBuilder.Entity("MVCProject.Models.Representative", b =>
                {
                    b.HasOne("MVCProject.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCProject.Models.DiscountType", "DiscountType")
                        .WithMany()
                        .HasForeignKey("DiscountTypeId");

<<<<<<< HEAD
                    b.HasOne("MVCProject.Models.Governorate", "Governorate")
=======
                    b.HasOne("MVCProject.Models.Government", "Governorate")
>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00
                        .WithMany()
                        .HasForeignKey("GovernorateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("DiscountType");

                    b.Navigation("Governorate");
                });

            modelBuilder.Entity("MVCProject.Models.Trader", b =>
                {
                    b.HasOne("MVCProject.Models.Branch", "Branch")
<<<<<<< HEAD
                        .WithMany("Traders")
=======
                        .WithMany()
>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCProject.Models.City", "City")
                        .WithMany("Traders")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

<<<<<<< HEAD
                    b.HasOne("MVCProject.Models.Governorate", "Governorate")
                        .WithMany("Traders")
                        .HasForeignKey("GoverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
=======
                    b.HasOne("MVCProject.Models.Government", "Governorate")
                        .WithMany("Traders")
                        .HasForeignKey("GovernorateId");
>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00

                    b.Navigation("Branch");

                    b.Navigation("City");

                    b.Navigation("Governorate");
                });

            modelBuilder.Entity("MVCProject.Models.TraderSpecialPriceForCities", b =>
                {
                    b.HasOne("MVCProject.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

<<<<<<< HEAD
                    b.HasOne("MVCProject.Models.Trader", "trader")
                        .WithMany()
=======
                    b.HasOne("MVCProject.Models.Trader", "Trader")
                        .WithMany("SpecialPriceForCities")
>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00
                        .HasForeignKey("TraderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

<<<<<<< HEAD
                    b.Navigation("trader");
                });

            modelBuilder.Entity("MVCProject.Models.Branch", b =>
                {
                    b.Navigation("Traders");
=======
                    b.Navigation("Trader");
>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00
                });

            modelBuilder.Entity("MVCProject.Models.City", b =>
                {
                    b.Navigation("Traders");
                });

<<<<<<< HEAD
            modelBuilder.Entity("MVCProject.Models.Governorate", b =>
                {
                    b.Navigation("City");

                    b.Navigation("Traders");
                });
=======
            modelBuilder.Entity("MVCProject.Models.Government", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Traders");
                });

            modelBuilder.Entity("MVCProject.Models.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MVCProject.Models.Trader", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("SpecialPriceForCities");
                });
>>>>>>> 80f5ff9cd2f16b6e638bf64c85b26b0858d82f00
#pragma warning restore 612, 618
        }
    }
}
