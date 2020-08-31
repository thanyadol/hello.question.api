using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hello.question.api.Migrations
{
    public partial class initailize301092019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                schema: "dbo",
                table: "Answer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SessionId",
                schema: "dbo",
                table: "Answer",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
