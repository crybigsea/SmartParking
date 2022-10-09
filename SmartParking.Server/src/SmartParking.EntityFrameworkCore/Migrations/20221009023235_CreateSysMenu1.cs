using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartParking.Migrations
{
    public partial class CreateSysMenu1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SysMenu",
                table: "SysMenu");

            migrationBuilder.RenameTable(
                name: "SysMenu",
                newName: "SysMenus");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "SysMenus",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SysMenus",
                table: "SysMenus",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SysMenus",
                table: "SysMenus");

            migrationBuilder.RenameTable(
                name: "SysMenus",
                newName: "SysMenu");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "SysMenu",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SysMenu",
                table: "SysMenu",
                column: "Id");
        }
    }
}
