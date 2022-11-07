using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NuevaAgendaApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    TelephoneNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    CelularNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacts_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 1, "karenbailapiola@gmail.com", "Lasot", "Karen", "Pa$$w0rd", "karenpiola" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 2, "elluismidetotoras@gmail.com", "Gonzales", "Luis Gonzalez", "lamismadesiempre", "luismitoto" });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "CelularNumber", "Description", "Email", "Name", "TelephoneNumber", "UserId" },
                values: new object[] { 1, 341457896, "Plomero", null, "Jaimito", null, 1 });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "CelularNumber", "Description", "Email", "Name", "TelephoneNumber", "UserId" },
                values: new object[] { 2, 34156978, "Papa", null, "Pepe", 422568, 2 });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "CelularNumber", "Description", "Email", "Name", "TelephoneNumber", "UserId" },
                values: new object[] { 3, 11425789, "Jefa", null, "Maria", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_contacts_UserId",
                table: "contacts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
