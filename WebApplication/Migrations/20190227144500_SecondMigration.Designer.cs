﻿//// <auto-generated />
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.Migrations;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
//using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
//using WebApplication.Models;

//namespace WebApplication.Migrations
//{
//    [DbContext(typeof(HelpToTeachContext))]
//    [Migration("20190227144500_SecondMigration")]
//    partial class SecondMigration
//    {
//        protected override void BuildTargetModel(ModelBuilder modelBuilder)
//        {
//#pragma warning disable 612, 618
//            modelBuilder
//                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
//                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
//                .HasAnnotation("Relational:MaxIdentifierLength", 63);

//            modelBuilder.Entity("WebApplication.Models.Course", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd();

//                    b.Property<string>("Name");

//                    b.HasKey("Id");

//                    b.ToTable("Courses");
//                });

//            modelBuilder.Entity("WebApplication.Models.Group", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd();

//                    b.Property<string>("Name");

//                    b.HasKey("Id");

//                    b.ToTable("Groups");
//                });

//            modelBuilder.Entity("WebApplication.Models.GroupCourse", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd();

//                    b.Property<int>("CourseId");

//                    b.Property<int>("GroupId");

//                    b.HasKey("Id");

//                    b.ToTable("GroupCourses");
//                });

//            modelBuilder.Entity("WebApplication.Models.User", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd();

//                    b.Property<string>("FirstName");

//                    b.Property<string>("LastName");

//                    b.HasKey("Id");

//                    b.ToTable("Users");
//                });
//#pragma warning restore 612, 618
//        }
//    }
//}
