﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fa18Team28_FinalProject.DAL;

namespace fa18Team28_FinalProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("fa18Team28_FinalProject.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("Active");

                    b.Property<string>("Birthday");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<int>("CreditCard1");

                    b.Property<int>("CreditCard2");

                    b.Property<int>("CreditCard3");

                    b.Property<string>("CustomerNumber");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MiddleInitial");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<int>("NumberofOrders");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ReviewsApproved");

                    b.Property<string>("ReviewsWritten");

                    b.Property<string>("SSN");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("Zipcode");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<int>("CopiesOnHand");

                    b.Property<decimal>("Cost");

                    b.Property<string>("Description");

                    b.Property<int?>("GenreID");

                    b.Property<DateTime>("LastOrdered");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("PublishedDate");

                    b.Property<int>("PurchaseCount");

                    b.Property<int>("Reordered");

                    b.Property<string>("Title");

                    b.Property<int>("UniqueID");

                    b.HasKey("BookID");

                    b.HasIndex("GenreID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.CustomerOrder", b =>
                {
                    b.Property<int>("CustomerOrderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppUserId");

                    b.Property<DateTime>("CustomerOrderDate");

                    b.Property<string>("CustomerOrderNotes");

                    b.Property<int>("CustomerOrderNumber");

                    b.HasKey("CustomerOrderID");

                    b.HasIndex("AppUserId");

                    b.ToTable("CustomerOrders");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.CustomerOrderDetail", b =>
                {
                    b.Property<int>("CustomerOrderDetailID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookID");

                    b.Property<int>("CustomerOrderDetailNotes");

                    b.Property<int?>("CustomerOrderID");

                    b.Property<decimal>("ExtendedPrice");

                    b.Property<decimal>("ProductPrice");

                    b.Property<int>("Quantity");

                    b.HasKey("CustomerOrderDetailID");

                    b.HasIndex("BookID");

                    b.HasIndex("CustomerOrderID");

                    b.ToTable("CustomerOrderDetails");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.Discount", b =>
                {
                    b.Property<string>("DiscountID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("DiscountID");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.DiscountDetail", b =>
                {
                    b.Property<int>("DiscountDetailID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerOrderID");

                    b.Property<string>("DiscountID");

                    b.HasKey("DiscountDetailID");

                    b.HasIndex("CustomerOrderID");

                    b.HasIndex("DiscountID");

                    b.ToTable("DiscountDetails");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.Genre", b =>
                {
                    b.Property<int>("GenreID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenreName");

                    b.HasKey("GenreID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.ManagerOrder", b =>
                {
                    b.Property<int>("ManagerOrderID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppUserId");

                    b.Property<DateTime>("ManagerOrderDate");

                    b.Property<string>("ManagerOrderDetailNotes");

                    b.Property<int>("ManagerOrderNumber");

                    b.HasKey("ManagerOrderID");

                    b.HasIndex("AppUserId");

                    b.ToTable("ManagerOrders");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.ManagerOrderDetail", b =>
                {
                    b.Property<int>("ManagerOrderDetailID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookID");

                    b.Property<decimal>("ExtendedCost");

                    b.Property<int>("ManagerOrderDetailsNotes");

                    b.Property<int?>("ManagerOrderID");

                    b.Property<decimal>("ProductCost");

                    b.Property<int>("Quantity");

                    b.HasKey("ManagerOrderDetailID");

                    b.HasIndex("BookID");

                    b.HasIndex("ManagerOrderID");

                    b.ToTable("ManagerOrderDetails");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.ProductDetail", b =>
                {
                    b.Property<int>("ProductDetailID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookID");

                    b.Property<int?>("SupplierID");

                    b.HasKey("ProductDetailID");

                    b.HasIndex("BookID");

                    b.HasIndex("SupplierID");

                    b.ToTable("ProductDetail");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApproverId");

                    b.Property<string>("Approver_user");

                    b.Property<string>("AuthorId");

                    b.Property<string>("Author_user");

                    b.Property<int?>("BookID");

                    b.Property<int>("Rating");

                    b.Property<string>("ReviewText");

                    b.HasKey("ReviewID");

                    b.HasIndex("ApproverId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EstablishedDate");

                    b.Property<bool>("PreferredSupplier");

                    b.Property<string>("SupplierEmail")
                        .IsRequired();

                    b.Property<string>("SupplierName")
                        .IsRequired();

                    b.Property<string>("SupplierNotes");

                    b.Property<string>("SupplierPhone")
                        .IsRequired();

                    b.HasKey("SupplierID");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.Book", b =>
                {
                    b.HasOne("fa18Team28_FinalProject.Models.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreID");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.CustomerOrder", b =>
                {
                    b.HasOne("fa18Team28_FinalProject.Models.AppUser", "AppUser")
                        .WithMany("CustomerOrders")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.CustomerOrderDetail", b =>
                {
                    b.HasOne("fa18Team28_FinalProject.Models.Book", "Book")
                        .WithMany("CustomerOrderDetails")
                        .HasForeignKey("BookID");

                    b.HasOne("fa18Team28_FinalProject.Models.CustomerOrder", "CustomerOrder")
                        .WithMany("CustomerOrderDetails")
                        .HasForeignKey("CustomerOrderID");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.DiscountDetail", b =>
                {
                    b.HasOne("fa18Team28_FinalProject.Models.CustomerOrder", "CustomerOrder")
                        .WithMany("DiscountDetails")
                        .HasForeignKey("CustomerOrderID");

                    b.HasOne("fa18Team28_FinalProject.Models.Discount", "Discount")
                        .WithMany("DiscountDetails")
                        .HasForeignKey("DiscountID");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.ManagerOrder", b =>
                {
                    b.HasOne("fa18Team28_FinalProject.Models.AppUser", "AppUser")
                        .WithMany("ManagerOrders")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.ManagerOrderDetail", b =>
                {
                    b.HasOne("fa18Team28_FinalProject.Models.Book", "Book")
                        .WithMany("ManagerOrderDetails")
                        .HasForeignKey("BookID");

                    b.HasOne("fa18Team28_FinalProject.Models.ManagerOrder", "ManagerOrder")
                        .WithMany("ManagerOrderDetails")
                        .HasForeignKey("ManagerOrderID");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.ProductDetail", b =>
                {
                    b.HasOne("fa18Team28_FinalProject.Models.Book", "Book")
                        .WithMany("ProductDetails")
                        .HasForeignKey("BookID");

                    b.HasOne("fa18Team28_FinalProject.Models.Supplier", "Supplier")
                        .WithMany("ProductDetails")
                        .HasForeignKey("SupplierID");
                });

            modelBuilder.Entity("fa18Team28_FinalProject.Models.Review", b =>
                {
                    b.HasOne("fa18Team28_FinalProject.Models.AppUser", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId");

                    b.HasOne("fa18Team28_FinalProject.Models.AppUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("fa18Team28_FinalProject.Models.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("fa18Team28_FinalProject.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("fa18Team28_FinalProject.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("fa18Team28_FinalProject.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("fa18Team28_FinalProject.Models.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
