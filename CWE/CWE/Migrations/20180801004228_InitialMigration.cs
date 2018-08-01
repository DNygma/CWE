using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CWE.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyQueue",
                columns: table => new
                {
                    Queue_UserID = table.Column<string>(nullable: false),
                    Queue_CurrencyPair = table.Column<string>(nullable: true),
                    Queue_Target = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyQueue", x => x.Queue_UserID);
                });

            migrationBuilder.CreateTable(
                name: "Notifier",
                columns: table => new
                {
                    Notifier_ID = table.Column<string>(nullable: false),
                    Notifier_NotificationString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifier", x => x.Notifier_ID);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Request_ID = table.Column<string>(nullable: false),
                    Request_Pair = table.Column<string>(nullable: true),
                    Request_TargetRte = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Request_ID);
                });

            migrationBuilder.CreateTable(
                name: "Scheduler",
                columns: table => new
                {
                    Scheduler_UserID = table.Column<string>(nullable: false),
                    Scheduler_ActualRate = table.Column<double>(nullable: false),
                    Scheduler_Pair = table.Column<string>(nullable: true),
                    Scheduler_RequestRate = table.Column<double>(nullable: false),
                    Scheduler_TargetRate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scheduler", x => x.Scheduler_UserID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_ID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.User_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyQueue");

            migrationBuilder.DropTable(
                name: "Notifier");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Scheduler");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
