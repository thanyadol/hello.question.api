using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hello.question.api.Migrations
{
    public partial class initailize201092019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ChoiseId",
                schema: "dbo",
                table: "SubQuestion",
                nullable: true,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ChoiseId",
                schema: "dbo",
                table: "SubQuestion",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
