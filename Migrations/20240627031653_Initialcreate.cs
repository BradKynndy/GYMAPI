using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymApi.Migrations
{
    /// <inheritdoc />
    public partial class Initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_MEMBERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Nivelconta = table.Column<int>(type: "int", nullable: false),
                    Classe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MEMBERS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_MEMBERS",
                columns: new[] { "Id", "Classe", "Email", "Nivelconta", "Nome" },
                values: new object[,]
                {
                    { 1, 3, "brad@gmail.com", 10, "Brad" },
                    { 2, 2, "bruno@gmail.com", 8, "Bruno" },
                    { 3, 3, "eduardo@gmail.com", 6, "Eduardo" },
                    { 4, 1, "vitor@gmail.com", 4, "Vitor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_MEMBERS");
        }
    }
}
