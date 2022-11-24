using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doan.Migrations
{
    /// <inheritdoc />
    public partial class khoitaos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GeneralProducts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Ima",
                value: "https://fakestoreapi.com/img/71-3HjGNDUL._AC_SY879._SX._UX._SY._UY_.jpg");

            migrationBuilder.UpdateData(
                table: "GeneralProducts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Ima",
                value: "https://fakestoreapi.com/img/71li-ujtlUL._AC_UX679_.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GeneralProducts",
                keyColumn: "ID",
                keyValue: 1,
                column: "Ima",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralProducts",
                keyColumn: "ID",
                keyValue: 2,
                column: "Ima",
                value: "");
        }
    }
}
