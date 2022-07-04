using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnoTech_Blazor_Training.Server.Migrations
{
    public partial class AddSomeConfigurationsAndValidations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OurEmpoyees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurEmpoyees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectConfiguration ",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectConfiguration ", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassRoom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoom", x => x.Id);
                    table.ForeignKey(
                        name: "fk-classroom-subject",
                        column: x => x.SubjectId,
                        principalTable: "SubjectConfiguration ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk-classroom-teacher",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GPA = table.Column<double>(type: "float", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsTable_ClassRoom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRoom",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClassRoomStudent",
                columns: table => new
                {
                    ClassRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoomStudent", x => new { x.ClassRoomId, x.StudentId });
                    table.ForeignKey(
                        name: "fk-classroom-classroomstudents",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk-classroomstudent-student",
                        column: x => x.StudentId,
                        principalTable: "StudentsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoom_Name",
                table: "ClassRoom",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoom_SubjectId",
                table: "ClassRoom",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoom_TeacherId",
                table: "ClassRoom",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoomStudent_StudentId",
                table: "ClassRoomStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_OurEmpoyees_Name",
                table: "OurEmpoyees",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsTable_ClassRoomId",
                table: "StudentsTable",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsTable_Name",
                table: "StudentsTable",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectConfiguration _Name",
                table: "SubjectConfiguration ",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_Name",
                table: "Teacher",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassRoomStudent");

            migrationBuilder.DropTable(
                name: "OurEmpoyees");

            migrationBuilder.DropTable(
                name: "StudentsTable");

            migrationBuilder.DropTable(
                name: "ClassRoom");

            migrationBuilder.DropTable(
                name: "SubjectConfiguration ");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
