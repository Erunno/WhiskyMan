using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiskyMan.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BottleDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Distillery = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Voltage = table.Column<decimal>(type: "TEXT", nullable: false),
                    PictureUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    DescriptionText = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Region = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BottleDescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PictureUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bottles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BottleDescriptionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount_ml = table.Column<int>(type: "INTEGER", nullable: false),
                    ShotPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    BottlePrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsDrunk = table.Column<bool>(type: "INTEGER", nullable: false),
                    WastePercent = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bottles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bottles_BottleDescriptions_BottleDescriptionId",
                        column: x => x.BottleDescriptionId,
                        principalTable: "BottleDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ownership",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    BottleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ownership", x => new { x.BottleId, x.OwnerId });
                    table.ForeignKey(
                        name: "FK_Ownership_Bottles_BottleId",
                        column: x => x.BottleId,
                        principalTable: "Bottles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ownership_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BuyerId = table.Column<int>(type: "INTEGER", nullable: false),
                    BottleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount_ml = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsPayed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PaymentTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Bottles_BottleId",
                        column: x => x.BottleId,
                        principalTable: "Bottles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BottleDescriptions_Active_Id",
                table: "BottleDescriptions",
                columns: new[] { "Active", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Bottles_BottleDescriptionId",
                table: "Bottles",
                column: "BottleDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bottles_IsDrunk",
                table: "Bottles",
                column: "IsDrunk");

            migrationBuilder.CreateIndex(
                name: "IX_Ownership_OwnerId",
                table: "Ownership",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BottleId",
                table: "Transactions",
                column: "BottleId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BuyerId",
                table: "Transactions",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CreationTime",
                table: "Transactions",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IsPayed_CreationTime",
                table: "Transactions",
                columns: new[] { "IsPayed", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Active_Id",
                table: "Users",
                columns: new[] { "Active", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ownership");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Bottles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BottleDescriptions");
        }
    }
}
