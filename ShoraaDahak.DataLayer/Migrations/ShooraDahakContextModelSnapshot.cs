﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoraaDahak.DataLayer.Context;

namespace ShoraaDahak.DataLayer.Migrations
{
    [DbContext(typeof(ShooraDahakContext))]
    partial class ShooraDahakContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Blog.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlogBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogImageName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BlogTitle")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("LittleDescription")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("SubCatId")
                        .HasColumnType("int");

                    b.Property<int>("WriterId")
                        .HasColumnType("int");

                    b.HasKey("BlogId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("GenderId");

                    b.HasIndex("SubCatId");

                    b.HasIndex("WriterId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Blog.BlogCategory", b =>
                {
                    b.Property<int>("BlogCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlogCategoryTitle")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int?>("ParrentId")
                        .HasColumnType("int");

                    b.HasKey("BlogCategoryId");

                    b.HasIndex("ParrentId");

                    b.ToTable("BlogCategories");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Blog.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GenderId");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Discussion.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiscussionId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AnswerId");

                    b.HasIndex("DiscussionId");

                    b.HasIndex("UserId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Discussion.Discussion", b =>
                {
                    b.Property<int>("DiscussionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiscussionBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DiscussionCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiscussionTitle")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("ImpLevelId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DiscussionId");

                    b.HasIndex("ImpLevelId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("UserId");

                    b.ToTable("Discussions");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Discussion.DiscussionImpLevel", b =>
                {
                    b.Property<int>("ImpLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImpLevelTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ImpLevelId");

                    b.ToTable("DiscussionImpLevels");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Letter.Letter", b =>
                {
                    b.Property<int>("LetterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("LetterBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LetterFileName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LetterSendDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LetterTitle")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("LetterToId")
                        .HasColumnType("int");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.HasKey("LetterId");

                    b.HasIndex("LetterToId");

                    b.HasIndex("SenderId");

                    b.ToTable("Letters");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Letter.LetterAnswer", b =>
                {
                    b.Property<int>("LetterAnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LetterAnswerBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LetterId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.HasKey("LetterAnswerId");

                    b.HasIndex("LetterId");

                    b.HasIndex("SenderId");

                    b.ToTable("LetterAnswers");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Letter.LetterTo", b =>
                {
                    b.Property<int>("LetterToId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LetterToTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LetterToId");

                    b.ToTable("LetterTos");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Permission.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParrentId")
                        .HasColumnType("int");

                    b.Property<string>("PermissionTitle")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("PermissionId");

                    b.HasIndex("ParrentId");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Permission.RolePermission", b =>
                {
                    b.Property<int>("RolePrmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("RolePrmId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermission");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Services.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("RelatedInstitutions")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ServiceBudget")
                        .HasColumnType("int");

                    b.Property<string>("ServiceDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ServiceEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ServiceImageName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ServiceStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ServiceTitle")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("ServiceUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ServiceVideoName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("SubGroup")
                        .HasColumnType("int");

                    b.Property<int>("WriterId")
                        .HasColumnType("int");

                    b.HasKey("ServiceId");

                    b.HasIndex("GroupId");

                    b.HasIndex("StatusId");

                    b.HasIndex("SubGroup");

                    b.HasIndex("WriterId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Services.ServiceGroup", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("ParrentId")
                        .HasColumnType("int");

                    b.HasKey("GroupId");

                    b.HasIndex("ParrentId");

                    b.ToTable("ServiceGroups");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Services.ServiceStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusTitle")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("StatusId");

                    b.ToTable("ServiceStatus");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.User.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.User.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActivationCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsConfirmedByAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("NCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.User.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.quote.Quote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuoteBody")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("QuoteBy")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("QuoteImageName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("QuoterJob")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("QuoteId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Blog.Blog", b =>
                {
                    b.HasOne("ShoraaDahak.DataLayer.Models.Blog.BlogCategory", "BlogCategory")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoraaDahak.DataLayer.Models.Blog.Gender", "Gender")
                        .WithMany("Blogs")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoraaDahak.DataLayer.Models.Blog.BlogCategory", "SubCategory")
                        .WithMany("SubBloges")
                        .HasForeignKey("SubCatId");

                    b.HasOne("ShoraaDahak.DataLayer.Models.User.User", "User")
                        .WithMany("Blogs")
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlogCategory");

                    b.Navigation("Gender");

                    b.Navigation("SubCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Blog.BlogCategory", b =>
                {
                    b.HasOne("ShoraaDahak.DataLayer.Models.Blog.BlogCategory", null)
                        .WithMany("BlogCategories")
                        .HasForeignKey("ParrentId");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Discussion.Answer", b =>
                {
                    b.HasOne("ShoraaDahak.DataLayer.Models.Discussion.Discussion", "Discussion")
                        .WithMany("Answers")
                        .HasForeignKey("DiscussionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoraaDahak.DataLayer.Models.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Discussion");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Discussion.Discussion", b =>
                {
                    b.HasOne("ShoraaDahak.DataLayer.Models.Discussion.DiscussionImpLevel", "DiscussionImpLevel")
                        .WithMany("Discussions")
                        .HasForeignKey("ImpLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoraaDahak.DataLayer.Models.Services.Service", "Service")
                        .WithMany("Discussions")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoraaDahak.DataLayer.Models.User.User", "User")
                        .WithMany("Discussions")
                        .HasForeignKey("UserId");

                    b.Navigation("DiscussionImpLevel");

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Letter.Letter", b =>
                {
                    b.HasOne("ShoraaDahak.DataLayer.Models.Letter.LetterTo", "LetterTo")
                        .WithMany("Letters")
                        .HasForeignKey("LetterToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoraaDahak.DataLayer.Models.User.User", "User")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LetterTo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Letter.LetterAnswer", b =>
                {
                    b.HasOne("ShoraaDahak.DataLayer.Models.Letter.Letter", "Letter")
                        .WithMany("LetterAnswers")
                        .HasForeignKey("LetterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoraaDahak.DataLayer.Models.User.User", "User")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.Navigation("Letter");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Permission.Permission", b =>
                {
                    b.HasOne("ShoraaDahak.DataLayer.Models.Permission.Permission", null)
                        .WithMany("Permissions")
                        .HasForeignKey("ParrentId");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Permission.RolePermission", b =>
                {
                    b.HasOne("ShoraaDahak.DataLayer.Models.Permission.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoraaDahak.DataLayer.Models.User.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Services.Service", b =>
                {
                    b.HasOne("ShoraaDahak.DataLayer.Models.Services.ServiceGroup", "ServiceGroup")
                        .WithMany("Services")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoraaDahak.DataLayer.Models.Services.ServiceStatus", "ServiceStatus")
                        .WithMany("Services")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoraaDahak.DataLayer.Models.Services.ServiceGroup", "Grooup")
                        .WithMany("SubServices")
                        .HasForeignKey("SubGroup");

                    b.HasOne("ShoraaDahak.DataLayer.Models.User.User", "User")
                        .WithMany("Services")
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grooup");

                    b.Navigation("ServiceGroup");

                    b.Navigation("ServiceStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Services.ServiceGroup", b =>
                {
                    b.HasOne("ShoraaDahak.DataLayer.Models.Services.ServiceGroup", null)
                        .WithMany("ServiceGroups")
                        .HasForeignKey("ParrentId");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.User.UserRole", b =>
                {
                    b.HasOne("ShoraaDahak.DataLayer.Models.User.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoraaDahak.DataLayer.Models.User.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Blog.BlogCategory", b =>
                {
                    b.Navigation("BlogCategories");

                    b.Navigation("Blogs");

                    b.Navigation("SubBloges");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Blog.Gender", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Discussion.Discussion", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Discussion.DiscussionImpLevel", b =>
                {
                    b.Navigation("Discussions");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Letter.Letter", b =>
                {
                    b.Navigation("LetterAnswers");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Letter.LetterTo", b =>
                {
                    b.Navigation("Letters");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Permission.Permission", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Services.Service", b =>
                {
                    b.Navigation("Discussions");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Services.ServiceGroup", b =>
                {
                    b.Navigation("ServiceGroups");

                    b.Navigation("Services");

                    b.Navigation("SubServices");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.Services.ServiceStatus", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.User.Role", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ShoraaDahak.DataLayer.Models.User.User", b =>
                {
                    b.Navigation("Blogs");

                    b.Navigation("Discussions");

                    b.Navigation("Services");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
