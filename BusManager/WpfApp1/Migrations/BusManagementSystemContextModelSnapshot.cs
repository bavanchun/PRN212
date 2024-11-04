﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WpfApp1.DAL;

#nullable disable

namespace WpfApp1.Migrations
{
    [DbContext(typeof(BusManagementSystemContext))]
    partial class BusManagementSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GoThrough", b =>
                {
                    b.Property<int>("RouteId")
                        .HasColumnType("int")
                        .HasColumnName("RouteID");

                    b.Property<int>("StationId")
                        .HasColumnType("int")
                        .HasColumnName("StationID");

                    b.HasKey("RouteId", "StationId")
                        .HasName("PK__GoThroug__4E9A10C0F4FA780A");

                    b.HasIndex("StationId");

                    b.ToTable("GoThrough", (string)null);
                });

            modelBuilder.Entity("WpfApp1.BOs.Bus", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BusID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusId"));

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RouteId")
                        .HasColumnType("int")
                        .HasColumnName("RouteID");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.HasKey("BusId")
                        .HasName("PK__Bus__6A0F6095AEB1FAD1");

                    b.HasIndex("RouteId");

                    b.HasIndex(new[] { "LicensePlate" }, "UQ__Bus__026BC15CAA13991E")
                        .IsUnique();

                    b.ToTable("Bus", (string)null);
                });

            modelBuilder.Entity("WpfApp1.BOs.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("OrderId")
                        .HasName("PK__Order__C3905BAFD86D78FD");

                    b.HasIndex("UserId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("WpfApp1.BOs.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RoleId")
                        .HasName("PK__Role__8AFACE3AE71981AD");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("WpfApp1.BOs.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RouteID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RouteId")
                        .HasName("PK__Route__80979AADE5A5D14A");

                    b.ToTable("Route", (string)null);
                });

            modelBuilder.Entity("WpfApp1.BOs.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StationID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StationId"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StationId")
                        .HasName("PK__Station__E0D8A6DD392DE23B");

                    b.ToTable("Station", (string)null);
                });

            modelBuilder.Entity("WpfApp1.BOs.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TicketID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<decimal>("FinalPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<int?>("RouteId")
                        .HasColumnType("int")
                        .HasColumnName("RouteID");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TicketId")
                        .HasName("PK__Ticket__712CC6278DA062DE");

                    b.HasIndex("OrderId");

                    b.HasIndex("RouteId");

                    b.ToTable("Ticket", (string)null);
                });

            modelBuilder.Entity("WpfApp1.BOs.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<int?>("UserTypeId")
                        .HasColumnType("int")
                        .HasColumnName("UserTypeID");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId")
                        .HasName("PK__User__1788CCAC95967697");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserTypeId");

                    b.HasIndex(new[] { "Username" }, "UQ__User__536C85E431DB4B79")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("WpfApp1.BOs.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserTypeID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserTypeId"));

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserTypeId")
                        .HasName("PK__UserType__40D2D8F666D84E96");

                    b.ToTable("UserType", (string)null);
                });

            modelBuilder.Entity("GoThrough", b =>
                {
                    b.HasOne("WpfApp1.BOs.Route", null)
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .IsRequired()
                        .HasConstraintName("FK__GoThrough__Route__47DBAE45");

                    b.HasOne("WpfApp1.BOs.Station", null)
                        .WithMany()
                        .HasForeignKey("StationId")
                        .IsRequired()
                        .HasConstraintName("FK__GoThrough__Stati__48CFD27E");
                });

            modelBuilder.Entity("WpfApp1.BOs.Bus", b =>
                {
                    b.HasOne("WpfApp1.BOs.Route", "Route")
                        .WithMany("Buses")
                        .HasForeignKey("RouteId")
                        .IsRequired()
                        .HasConstraintName("FK__Bus__BasePrice__4316F928");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("WpfApp1.BOs.Order", b =>
                {
                    b.HasOne("WpfApp1.BOs.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Order__UserID__4BAC3F29");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WpfApp1.BOs.Ticket", b =>
                {
                    b.HasOne("WpfApp1.BOs.Order", "Order")
                        .WithMany("Tickets")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__Ticket__OrderID__4F7CD00D");

                    b.HasOne("WpfApp1.BOs.Route", "Route")
                        .WithMany("Tickets")
                        .HasForeignKey("RouteId")
                        .HasConstraintName("FK__Ticket__RouteID__4E88ABD4");

                    b.Navigation("Order");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("WpfApp1.BOs.User", b =>
                {
                    b.HasOne("WpfApp1.BOs.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__User__RoleID__3C69FB99");

                    b.HasOne("WpfApp1.BOs.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeId")
                        .HasConstraintName("FK__User__UserTypeID__3D5E1FD2");

                    b.Navigation("Role");

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("WpfApp1.BOs.Order", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("WpfApp1.BOs.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WpfApp1.BOs.Route", b =>
                {
                    b.Navigation("Buses");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("WpfApp1.BOs.User", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WpfApp1.BOs.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
