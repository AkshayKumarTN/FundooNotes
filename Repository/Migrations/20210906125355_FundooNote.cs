using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class FundooNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "FundooNotes",
                columns: table => new
                {
                    NotesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Reminder = table.Column<string>(nullable: true),
                    Collaborator = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Lable = table.Column<string>(nullable: true),
                    Pin = table.Column<bool>(nullable: false),
                    Archieve = table.Column<bool>(nullable: false),
                    Trash = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundooNotes", x => x.NotesId);
                    table.ForeignKey(
                        name: "FK_FundooNotes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Collaborators",
                columns: table => new
                {
                    CollaboratorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderEmail = table.Column<string>(nullable: true),
                    ReceiverEmail = table.Column<string>(nullable: true),
                    NoteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaborators", x => x.CollaboratorId);
                    table.ForeignKey(
                        name: "FK_Collaborators_FundooNotes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "FundooNotes",
                        principalColumn: "NotesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lables",
                columns: table => new
                {
                    LableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lable = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    NotesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lables", x => x.LableId);
                    table.ForeignKey(
                        name: "FK_Lables_FundooNotes_NotesId",
                        column: x => x.NotesId,
                        principalTable: "FundooNotes",
                        principalColumn: "NotesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lables_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collaborators_NoteId",
                table: "Collaborators",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_FundooNotes_UserId",
                table: "FundooNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lables_NotesId",
                table: "Lables",
                column: "NotesId");

            migrationBuilder.CreateIndex(
                name: "IX_Lables_UserId",
                table: "Lables",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collaborators");

            migrationBuilder.DropTable(
                name: "Lables");

            migrationBuilder.DropTable(
                name: "FundooNotes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
