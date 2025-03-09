﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Promotion.Grpc.Data;

#nullable disable

namespace Promotion.Grpc.Data.Migrations
{
    [DbContext(typeof(PromotionDbContext))]
    [Migration("20250302195732_AdjustGiftCodeTable")]
    partial class AdjustGiftCodeTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("Promotion.Grpc.Models.GiftCode", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("MoneyValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PromotionId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PromotionId");

                    b.ToTable("GiftCodes");
                });

            modelBuilder.Entity("Promotion.Grpc.Models.PromoCode", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PromotionId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PromotionId");

                    b.ToTable("PromoCodes");
                });

            modelBuilder.Entity("Promotion.Grpc.Models.Promotion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("EffectiveDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PromotionTypeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PromotionTypeId");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("Promotion.Grpc.Models.PromotionType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PromotionTypes");
                });

            modelBuilder.Entity("Promotion.Grpc.Models.PromotionTypeServicePackage", b =>
                {
                    b.Property<string>("PromotionTypeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServicePackageId")
                        .HasColumnType("TEXT");

                    b.HasKey("PromotionTypeId", "ServicePackageId");

                    b.ToTable("PromotionTypeServicePackages");
                });

            modelBuilder.Entity("Promotion.Grpc.Models.GiftCode", b =>
                {
                    b.HasOne("Promotion.Grpc.Models.Promotion", "Promotion")
                        .WithMany("GiftCodes")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("Promotion.Grpc.Models.PromoCode", b =>
                {
                    b.HasOne("Promotion.Grpc.Models.Promotion", "Promotion")
                        .WithMany("PromoCodes")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("Promotion.Grpc.Models.Promotion", b =>
                {
                    b.HasOne("Promotion.Grpc.Models.PromotionType", "PromotionType")
                        .WithMany("Promotions")
                        .HasForeignKey("PromotionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PromotionType");
                });

            modelBuilder.Entity("Promotion.Grpc.Models.PromotionTypeServicePackage", b =>
                {
                    b.HasOne("Promotion.Grpc.Models.PromotionType", "PromotionType")
                        .WithMany("PromotionTypeServicePackages")
                        .HasForeignKey("PromotionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PromotionType");
                });

            modelBuilder.Entity("Promotion.Grpc.Models.Promotion", b =>
                {
                    b.Navigation("GiftCodes");

                    b.Navigation("PromoCodes");
                });

            modelBuilder.Entity("Promotion.Grpc.Models.PromotionType", b =>
                {
                    b.Navigation("PromotionTypeServicePackages");

                    b.Navigation("Promotions");
                });
#pragma warning restore 612, 618
        }
    }
}
