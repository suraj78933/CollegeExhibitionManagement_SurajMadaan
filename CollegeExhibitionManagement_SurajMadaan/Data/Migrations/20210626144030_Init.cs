using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeExhibitionManagement_SurajMadaan.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassMasters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(nullable: true),
                    Section = table.Column<string>(nullable: true),
                    NumberOfStudents = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassMasters", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExhibitionCoordinators",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassMasterID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExhibitionCoordinators", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExhibitionCoordinators_ClassMasters_ClassMasterID",
                        column: x => x.ClassMasterID,
                        principalTable: "ClassMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ClassMasterID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Students_ClassMasters_ClassMasterID",
                        column: x => x.ClassMasterID,
                        principalTable: "ClassMasters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExhibitionCoordinators_ClassMasterID",
                table: "ExhibitionCoordinators",
                column: "ClassMasterID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassMasterID",
                table: "Students",
                column: "ClassMasterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExhibitionCoordinators");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ClassMasters");
        }
    }
}
