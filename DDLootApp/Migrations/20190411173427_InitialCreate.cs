using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DDLootApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monster",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MonsterItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemName = table.Column<string>(nullable: true),
                    ItemDescription = table.Column<string>(nullable: true),
                    ItemPrice = table.Column<int>(nullable: false),
                    MonsterID = table.Column<int>(nullable: false),
                    ItemRarity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MonsterItems_Monster_MonsterID",
                        column: x => x.MonsterID,
                        principalTable: "Monster",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonsterItems_MonsterID",
                table: "MonsterItems",
                column: "MonsterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonsterItems");

            migrationBuilder.DropTable(
                name: "Monster");
        }
    }
}
