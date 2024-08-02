using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBoperationWithEFWEbApp.Migrations
{
    /// <inheritdoc />
    public partial class addnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfPage = table.Column<int>(type: "int", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descreption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Isactive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currencyid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.id);
                    table.ForeignKey(
                        name: "FK_Currencies_Currencies_Currencyid",
                        column: x => x.Currencyid,
                        principalTable: "Currencies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BookPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    CurrencyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookPrices_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPrices_Currencies_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "id", "Created", "Currencyid", "Descreption", "Isactive", "LastUpdated", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 20, 6, 52, 53, 60, DateTimeKind.Local).AddTicks(9994), null, "Indian INR", true, new DateTime(2024, 5, 20, 6, 52, 53, 61, DateTimeKind.Local).AddTicks(7), "INR" },
                    { 2, new DateTime(2024, 5, 20, 6, 52, 53, 61, DateTimeKind.Local).AddTicks(11), null, "Dollar", true, new DateTime(2024, 5, 20, 6, 52, 53, 61, DateTimeKind.Local).AddTicks(11), "Dollar" },
                    { 3, new DateTime(2024, 5, 20, 6, 52, 53, 61, DateTimeKind.Local).AddTicks(12), null, "Euro", true, new DateTime(2024, 5, 20, 6, 52, 53, 61, DateTimeKind.Local).AddTicks(13), "Euro" },
                    { 4, new DateTime(2024, 5, 20, 6, 52, 53, 61, DateTimeKind.Local).AddTicks(13), null, "Diner", true, new DateTime(2024, 5, 20, 6, 52, 53, 61, DateTimeKind.Local).AddTicks(14), "Diner" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "ID", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Hindi", "Hindi" },
                    { 2, "English", "English" },
                    { 3, "Urdu", "Urdu" },
                    { 4, "Panjabhi", "Panjabi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookPrices_BookID",
                table: "BookPrices",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BookPrices_CurrencyID",
                table: "BookPrices",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Currencyid",
                table: "Currencies",
                column: "Currencyid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookPrices");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
