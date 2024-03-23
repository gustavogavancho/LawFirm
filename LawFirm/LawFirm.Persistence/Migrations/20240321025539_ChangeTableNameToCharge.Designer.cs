﻿// <auto-generated />
using System;
using LawFirm.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LawFirm.Persistence.Migrations
{
    [DbContext(typeof(LawFirmContext))]
    [Migration("20240321025539_ChangeTableNameToCharge")]
    partial class ChangeTableNameToCharge
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.20");

            modelBuilder.Entity("LawFirm.Domain.Entities.Case", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CourtInCharge")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Fiscal")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Judge")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProsecutorOffice")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Case");
                });

            modelBuilder.Entity("LawFirm.Domain.Entities.Charge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CaseId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.ToTable("Charge");
                });

            modelBuilder.Entity("LawFirm.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BusinessName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<long>("Nit")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Representative")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("LawFirm.Domain.Entities.ClientCase", b =>
                {
                    b.Property<Guid>("CaseId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.HasKey("CaseId", "ClientId");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientCase");
                });

            modelBuilder.Entity("LawFirm.Domain.Entities.CounterPart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CaseId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Nit")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.ToTable("CounterPart");
                });

            modelBuilder.Entity("LawFirm.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CaseId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EventEndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EventStartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("LawFirm.Domain.Entities.Notes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CaseId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("LawFirm.Domain.Entities.Notificacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CaseId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.ToTable("Notificacion");
                });

            modelBuilder.Entity("LawFirm.Domain.Entities.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CaseId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CaseId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("LawFirm.Domain.Entities.Charge", b =>
                {
                    b.HasOne("LawFirm.Domain.Entities.Case", null)
                        .WithMany("IlegalActs")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LawFirm.Domain.Entities.ClientCase", b =>
                {
                    b.HasOne("LawFirm.Domain.Entities.Case", null)
                        .WithMany()
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LawFirm.Domain.Entities.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LawFirm.Domain.Entities.CounterPart", b =>
                {
                    b.HasOne("LawFirm.Domain.Entities.Case", null)
                        .WithMany("CounterParts")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LawFirm.Domain.Entities.Event", b =>
                {
                    b.HasOne("LawFirm.Domain.Entities.Case", null)
                        .WithMany("Events")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LawFirm.Domain.Entities.Notes", b =>
                {
                    b.HasOne("LawFirm.Domain.Entities.Case", null)
                        .WithMany("Notes")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LawFirm.Domain.Entities.Notificacion", b =>
                {
                    b.HasOne("LawFirm.Domain.Entities.Case", null)
                        .WithMany("Notificacions")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LawFirm.Domain.Entities.Status", b =>
                {
                    b.HasOne("LawFirm.Domain.Entities.Case", null)
                        .WithMany("Status")
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LawFirm.Domain.Entities.Case", b =>
                {
                    b.Navigation("CounterParts");

                    b.Navigation("Events");

                    b.Navigation("IlegalActs");

                    b.Navigation("Notes");

                    b.Navigation("Notificacions");

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
