﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using intern_track_back.Data;

#nullable disable

namespace intern_track_back.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220523133604_AddStudentPlanForInterview")]
    partial class AddStudentPlanForInterview
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("intern_track_back.Models.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("intern_track_back.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("intern_track_back.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("intern_track_back.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("VacancyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.HasIndex("UserId");

                    b.HasIndex("VacancyId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("intern_track_back.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeaneryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeaneryId");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("intern_track_back.Models.Interview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Format")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stack")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("StudentId");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("intern_track_back.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("intern_track_back.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Remark")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("StudentId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("intern_track_back.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.Property<int?>("VacancyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.HasIndex("VacancyId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("intern_track_back.Models.Resume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Stack")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("intern_track_back.Models.StackForInterviewPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StackType")
                        .HasColumnType("int");

                    b.Property<int>("StudentPlanForInterviewId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentPlanForInterviewId");

                    b.ToTable("StackForInterviewPlans");
                });

            modelBuilder.Entity("intern_track_back.Models.StudentPlanForInterview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PreferableTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentPlanForInterviews");
                });

            modelBuilder.Entity("intern_track_back.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ChatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CuratorId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique();

                    b.HasIndex("ChatId");

                    b.HasIndex("CuratorId");

                    b.ToTable("UsersCustom");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("intern_track_back.Models.UserChat", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "ChatId");

                    b.HasIndex("ChatId");

                    b.ToTable("UserChats");
                });

            modelBuilder.Entity("intern_track_back.Models.Vacancy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifyDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Stack")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("intern_track_back.Models.Company", b =>
                {
                    b.HasBaseType("intern_track_back.Models.User");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Company_Address");

                    b.HasDiscriminator().HasValue("Company");
                });

            modelBuilder.Entity("intern_track_back.Models.Curator", b =>
                {
                    b.HasBaseType("intern_track_back.Models.User");

                    b.HasDiscriminator().HasValue("Curator");
                });

            modelBuilder.Entity("intern_track_back.Models.Deanery", b =>
                {
                    b.HasBaseType("intern_track_back.Models.User");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Deanery");
                });

            modelBuilder.Entity("intern_track_back.Models.Student", b =>
                {
                    b.HasBaseType("intern_track_back.Models.User");

                    b.Property<int>("Course")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("intern_track_back.Models.ApplicationUser", b =>
                {
                    b.HasOne("intern_track_back.Models.User", null)
                        .WithOne("ApplicationUser")
                        .HasForeignKey("intern_track_back.Models.ApplicationUser", "UserId");
                });

            modelBuilder.Entity("intern_track_back.Models.Contact", b =>
                {
                    b.HasOne("intern_track_back.Models.Resume", "Resume")
                        .WithMany("Contacts")
                        .HasForeignKey("ResumeId");

                    b.HasOne("intern_track_back.Models.User", "User")
                        .WithMany("Contacts")
                        .HasForeignKey("UserId");

                    b.HasOne("intern_track_back.Models.Vacancy", "Vacancy")
                        .WithMany("Contacts")
                        .HasForeignKey("VacancyId");

                    b.Navigation("Resume");

                    b.Navigation("User");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("intern_track_back.Models.Grade", b =>
                {
                    b.HasOne("intern_track_back.Models.Deanery", "Deanery")
                        .WithMany("Grades")
                        .HasForeignKey("DeaneryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("intern_track_back.Models.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Deanery");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("intern_track_back.Models.Interview", b =>
                {
                    b.HasOne("intern_track_back.Models.Company", "Company")
                        .WithMany("Interviews")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("intern_track_back.Models.Student", "Student")
                        .WithMany("Interviews")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("intern_track_back.Models.Message", b =>
                {
                    b.HasOne("intern_track_back.Models.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("intern_track_back.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("intern_track_back.Models.Note", b =>
                {
                    b.HasOne("intern_track_back.Models.Company", "Company")
                        .WithMany("Notes")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("intern_track_back.Models.Student", "Student")
                        .WithMany("Notes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("intern_track_back.Models.Project", b =>
                {
                    b.HasOne("intern_track_back.Models.Resume", "Resume")
                        .WithMany("Projects")
                        .HasForeignKey("ResumeId");

                    b.HasOne("intern_track_back.Models.Vacancy", "Vacancy")
                        .WithMany("Projects")
                        .HasForeignKey("VacancyId");

                    b.Navigation("Resume");

                    b.Navigation("Vacancy");
                });

            modelBuilder.Entity("intern_track_back.Models.Resume", b =>
                {
                    b.HasOne("intern_track_back.Models.Student", "Student")
                        .WithMany("Resumes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("intern_track_back.Models.StackForInterviewPlan", b =>
                {
                    b.HasOne("intern_track_back.Models.StudentPlanForInterview", "StudentPlanForInterview")
                        .WithMany("StackTypes")
                        .HasForeignKey("StudentPlanForInterviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentPlanForInterview");
                });

            modelBuilder.Entity("intern_track_back.Models.StudentPlanForInterview", b =>
                {
                    b.HasOne("intern_track_back.Models.Company", "Company")
                        .WithMany("StudentPlanForInterviews")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("intern_track_back.Models.Student", "Student")
                        .WithMany("StudentPlanForInterviews")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("intern_track_back.Models.User", b =>
                {
                    b.HasOne("intern_track_back.Models.ApplicationUser", null)
                        .WithOne("User")
                        .HasForeignKey("intern_track_back.Models.User", "ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("intern_track_back.Models.Chat", null)
                        .WithMany("Contingent")
                        .HasForeignKey("ChatId");

                    b.HasOne("intern_track_back.Models.Curator", null)
                        .WithMany("Mentee")
                        .HasForeignKey("CuratorId");
                });

            modelBuilder.Entity("intern_track_back.Models.UserChat", b =>
                {
                    b.HasOne("intern_track_back.Models.Chat", "Chat")
                        .WithMany("Users")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("intern_track_back.Models.User", "User")
                        .WithMany("Chats")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("intern_track_back.Models.Vacancy", b =>
                {
                    b.HasOne("intern_track_back.Models.Company", "Company")
                        .WithMany("Vacancies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("intern_track_back.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("intern_track_back.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("intern_track_back.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("intern_track_back.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("intern_track_back.Models.ApplicationUser", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("intern_track_back.Models.Chat", b =>
                {
                    b.Navigation("Contingent");

                    b.Navigation("Messages");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("intern_track_back.Models.Resume", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("intern_track_back.Models.StudentPlanForInterview", b =>
                {
                    b.Navigation("StackTypes");
                });

            modelBuilder.Entity("intern_track_back.Models.User", b =>
                {
                    b.Navigation("ApplicationUser")
                        .IsRequired();

                    b.Navigation("Chats");

                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("intern_track_back.Models.Vacancy", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("intern_track_back.Models.Company", b =>
                {
                    b.Navigation("Interviews");

                    b.Navigation("Notes");

                    b.Navigation("StudentPlanForInterviews");

                    b.Navigation("Vacancies");
                });

            modelBuilder.Entity("intern_track_back.Models.Curator", b =>
                {
                    b.Navigation("Mentee");
                });

            modelBuilder.Entity("intern_track_back.Models.Deanery", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("intern_track_back.Models.Student", b =>
                {
                    b.Navigation("Grades");

                    b.Navigation("Interviews");

                    b.Navigation("Notes");

                    b.Navigation("Resumes");

                    b.Navigation("StudentPlanForInterviews");
                });
#pragma warning restore 612, 618
        }
    }
}
