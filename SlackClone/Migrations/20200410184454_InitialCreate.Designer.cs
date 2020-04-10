﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SlackClone.Models;

namespace SlackClone.Migrations
{
    [DbContext(typeof(SlackCloneDbContext))]
    [Migration("20200410184454_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("SlackClone.Models.Channel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeamName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TeamName");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("SlackClone.Models.ChannelMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ChannelId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("Likes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ThreadId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChannelId");

                    b.ToTable("ChannelMessages");
                });

            modelBuilder.Entity("SlackClone.Models.DirectMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RecipientId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Sent")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DirectMessages");
                });

            modelBuilder.Entity("SlackClone.Models.Team", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.HasKey("Name");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SlackClone.Models.TeamMember", b =>
                {
                    b.Property<string>("TeamName")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ChannelId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Member")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeamName1")
                        .HasColumnType("TEXT");

                    b.HasKey("TeamName");

                    b.HasIndex("ChannelId");

                    b.HasIndex("TeamName1");

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("SlackClone.Models.User", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Online")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.HasKey("UserName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SlackClone.Models.Channel", b =>
                {
                    b.HasOne("SlackClone.Models.Team", null)
                        .WithMany("Channels")
                        .HasForeignKey("TeamName");
                });

            modelBuilder.Entity("SlackClone.Models.ChannelMessage", b =>
                {
                    b.HasOne("SlackClone.Models.Channel", null)
                        .WithMany("Messages")
                        .HasForeignKey("ChannelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SlackClone.Models.TeamMember", b =>
                {
                    b.HasOne("SlackClone.Models.Channel", null)
                        .WithMany("Members")
                        .HasForeignKey("ChannelId");

                    b.HasOne("SlackClone.Models.Team", null)
                        .WithMany("Members")
                        .HasForeignKey("TeamName1");
                });
#pragma warning restore 612, 618
        }
    }
}
