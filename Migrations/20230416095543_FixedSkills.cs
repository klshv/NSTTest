using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.Migrations
{
    /// <inheritdoc />
    public partial class FixedSkills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_SkillEntity_SkillId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_SkillId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "Persons");

            migrationBuilder.AddColumn<byte>(
                name: "Level",
                table: "SkillEntity",
                type: "INTEGER",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SkillEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PersonEntityPersonId",
                table: "SkillEntity",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillEntity_PersonEntityPersonId",
                table: "SkillEntity",
                column: "PersonEntityPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillEntity_Persons_PersonEntityPersonId",
                table: "SkillEntity",
                column: "PersonEntityPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillEntity_Persons_PersonEntityPersonId",
                table: "SkillEntity");

            migrationBuilder.DropIndex(
                name: "IX_SkillEntity_PersonEntityPersonId",
                table: "SkillEntity");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "SkillEntity");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SkillEntity");

            migrationBuilder.DropColumn(
                name: "PersonEntityPersonId",
                table: "SkillEntity");

            migrationBuilder.AddColumn<long>(
                name: "SkillId",
                table: "Persons",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_SkillId",
                table: "Persons",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_SkillEntity_SkillId",
                table: "Persons",
                column: "SkillId",
                principalTable: "SkillEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
