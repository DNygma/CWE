﻿// <auto-generated />
using CWE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CWE.Migrations
{
    [DbContext(typeof(CEA_DBContext))]
    partial class CEA_DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CWE.Models.CurrencyQueue", b =>
                {
                    b.Property<string>("Queue_UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Queue_CurrencyPair");

                    b.Property<double>("Queue_Target");

                    b.HasKey("Queue_UserID");

                    b.ToTable("CurrencyQueue");
                });

            modelBuilder.Entity("CWE.Models.Notifier", b =>
                {
                    b.Property<string>("Notifier_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Notifier_NotificationString");

                    b.HasKey("Notifier_ID");

                    b.ToTable("Notifier");
                });

            modelBuilder.Entity("CWE.Models.Request", b =>
                {
                    b.Property<string>("Request_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Request_Pair");

                    b.Property<double>("Request_TargetRte");

                    b.HasKey("Request_ID");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("CWE.Models.Scheduler", b =>
                {
                    b.Property<string>("Scheduler_UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Scheduler_ActualRate");

                    b.Property<string>("Scheduler_Pair");

                    b.Property<double>("Scheduler_RequestRate");

                    b.Property<double>("Scheduler_TargetRate");

                    b.HasKey("Scheduler_UserID");

                    b.ToTable("Scheduler");
                });

            modelBuilder.Entity("CWE.Models.User", b =>
                {
                    b.Property<string>("User_ID")
                        .ValueGeneratedOnAdd();

                    b.HasKey("User_ID");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
