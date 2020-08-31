using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hello.question.api.Migrations
{
    public partial class initailize01092019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Answer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ParticipantId = table.Column<Guid>(nullable: false),
                    SubQuestionId = table.Column<Guid>(nullable: false),
                    Value = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(maxLength: 1000, nullable: true),
                    SessionId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Choise",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 1000, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    By = table.Column<string>(maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SessionId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 500, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    By = table.Column<string>(maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    Order = table.Column<int>(nullable: false),
                    By = table.Column<string>(maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubChoise",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ChoiseId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Order = table.Column<int>(nullable: false),
                    AllowSelect = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubChoise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubQuestion",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: false),
                    ChoiseId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 10, nullable: true),
                    By = table.Column<string>(maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubQuestion", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Choise",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Participant",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SubChoise",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SubQuestion",
                schema: "dbo");
        }
    }
}
