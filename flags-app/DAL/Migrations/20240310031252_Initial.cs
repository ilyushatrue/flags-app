using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Context = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CapitalName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    StripDirectionId = table.Column<int>(type: "INTEGER", nullable: true),
                    StripColorId = table.Column<int>(type: "INTEGER", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flags_Catalog_StripColorId",
                        column: x => x.StripColorId,
                        principalTable: "Catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flags_Catalog_StripDirectionId",
                        column: x => x.StripDirectionId,
                        principalTable: "Catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flags_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlagAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    FlagId = table.Column<int>(type: "INTEGER", nullable: false),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: true),
                    ColorId = table.Column<int>(type: "INTEGER", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlagAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlagAreas_Catalog_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlagAreas_FlagAreas_ParentId",
                        column: x => x.ParentId,
                        principalTable: "FlagAreas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FlagAreas_Flags_FlagId",
                        column: x => x.FlagId,
                        principalTable: "Flags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlagPatterns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    NameId = table.Column<int>(type: "INTEGER", nullable: false),
                    ColorId = table.Column<int>(type: "INTEGER", nullable: false),
                    AreaId = table.Column<int>(type: "INTEGER", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlagPatterns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlagPatterns_Catalog_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlagPatterns_Catalog_NameId",
                        column: x => x.NameId,
                        principalTable: "Catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlagPatterns_FlagAreas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "FlagAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlagAreas_ColorId",
                table: "FlagAreas",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_FlagAreas_FlagId",
                table: "FlagAreas",
                column: "FlagId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlagAreas_ParentId",
                table: "FlagAreas",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_FlagPatterns_AreaId",
                table: "FlagPatterns",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_FlagPatterns_ColorId",
                table: "FlagPatterns",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_FlagPatterns_NameId",
                table: "FlagPatterns",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_Flags_CountryId",
                table: "Flags",
                column: "CountryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flags_StripColorId",
                table: "Flags",
                column: "StripColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Flags_StripDirectionId",
                table: "Flags",
                column: "StripDirectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlagPatterns");

            migrationBuilder.DropTable(
                name: "FlagAreas");

            migrationBuilder.DropTable(
                name: "Flags");

            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
