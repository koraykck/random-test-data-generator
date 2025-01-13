using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RandomDataTypes",
                columns: table => new
                {
                    ObjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneratorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomDataTypes", x => x.ObjectId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RandomDatas",
                columns: table => new
                {
                    ObjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DependentRandomDataId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomDatas", x => x.ObjectId);
                    table.ForeignKey(
                        name: "FK_RandomDatas_RandomDataTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "RandomDataTypes",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RandomDatas_RandomDatas_DependentRandomDataId",
                        column: x => x.DependentRandomDataId,
                        principalTable: "RandomDatas",
                        principalColumn: "ObjectId");
                });

            migrationBuilder.InsertData(
                table: "RandomDataTypes",
                columns: new[] { "ObjectId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "GeneratorType", "IsDeleted", "Key", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 2, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7481), null, null, "English names", "db", false, "name", "Name", null, null },
                    { 3, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7495), null, null, "Countries", "db", false, "country", "Country", null, null },
                    { 4, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7497), null, null, "English last names", "db", false, "last-name", "Last Name", null, null },
                    { 5, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7498), null, null, "Mail", "code", false, "mail", "Mail", null, null },
                    { 6, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7499), null, null, "City", "db", false, "city", "City", null, null },
                    { 7, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7501), null, null, "Boolean", "code", false, "boolean", "Boolean", null, null },
                    { 8, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7502), null, null, "String", "code", false, "string", "String", null, null },
                    { 9, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7503), null, null, "Number", "code", false, "integer", "Number", null, null },
                    { 10, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7504), null, null, "Datetime", "code", false, "datetime", "Datetime", null, null },
                    { 11, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7506), null, null, "Guid", "code", false, "guid", "Guid", null, null },
                    { 12, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7508), null, null, "Gender", "db", false, "gender", "Gender", null, null }
                });

            migrationBuilder.InsertData(
                table: "RandomDatas",
                columns: new[] { "ObjectId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "DependentRandomDataId", "IsDeleted", "TypeId", "UpdatedBy", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 39, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7852), null, null, null, false, 3, null, null, "Turkey" },
                    { 40, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7853), null, null, null, false, 3, null, null, "USA" },
                    { 43, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7854), null, null, null, false, 3, null, null, "Germany" },
                    { 44, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7855), null, null, null, false, 3, null, null, "Finland" },
                    { 45, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7857), null, null, null, false, 3, null, null, "England" },
                    { 46, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7858), null, null, null, false, 3, null, null, "Norway" },
                    { 47, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7860), null, null, null, false, 3, null, null, "Poland" },
                    { 48, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7862), null, null, null, false, 3, null, null, "Russia" },
                    { 49, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7864), null, null, null, false, 3, null, null, "Brazil" },
                    { 50, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7865), null, null, null, false, 3, null, null, "China" },
                    { 51, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7866), null, null, null, false, 3, null, null, "Japan" },
                    { 52, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7867), null, null, null, false, 3, null, null, "Korea" },
                    { 53, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7869), null, null, null, false, 3, null, null, "Italy" },
                    { 54, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7870), null, null, null, false, 3, null, null, "Denmark" },
                    { 55, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7871), null, null, null, false, 3, null, null, "Canada" },
                    { 56, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7872), null, null, null, false, 3, null, null, "Mexico" },
                    { 57, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7873), null, null, null, false, 3, null, null, "India" },
                    { 58, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7874), null, null, null, false, 3, null, null, "Egypt" },
                    { 59, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7875), null, null, null, false, 3, null, null, "Singapore" },
                    { 61, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7877), null, null, null, false, 3, null, null, "Switzerland" },
                    { 62, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7878), null, null, null, false, 3, null, null, "Greece" },
                    { 63, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7879), null, null, null, false, 3, null, null, "Belgium" },
                    { 64, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7910), null, null, null, false, 3, null, null, "Bulgaria" },
                    { 65, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7912), null, null, null, false, 12, null, null, "Male" },
                    { 66, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7913), null, null, null, false, 12, null, null, "Female" },
                    { 67, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7914), null, null, null, false, 5, null, null, "@domain.com" },
                    { 68, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7915), null, null, null, false, 5, null, null, "@mailserver.com" },
                    { 69, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7916), null, null, null, false, 5, null, null, "@webmail.com" },
                    { 70, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7918), null, null, null, false, 5, null, null, "@network.com" },
                    { 71, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7920), null, null, null, false, 5, null, null, "@internet.com" },
                    { 72, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7921), null, null, null, false, 5, null, null, "@hostmail.com" },
                    { 73, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7922), null, null, null, false, 5, null, null, "@servermail.com" },
                    { 74, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7923), null, null, null, false, 5, null, null, "@custommail.com" },
                    { 75, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7924), null, null, null, false, 5, null, null, "@securemail.com" },
                    { 76, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7926), null, null, null, false, 5, null, null, "@fastmail.com" },
                    { 77, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7927), null, null, null, false, 5, null, null, "@cloudmail.com" },
                    { 78, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7928), null, null, null, false, 5, null, null, "@freemail.com" },
                    { 79, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7929), null, null, null, false, 5, null, null, "@quickmail.com" },
                    { 80, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7930), null, null, null, false, 5, null, null, "@smartmail.com" },
                    { 81, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7931), null, null, null, false, 5, null, null, "@protonmail.com" },
                    { 82, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7932), null, null, null, false, 5, null, null, "@webfastmail.com" },
                    { 83, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7934), null, null, null, false, 5, null, null, "@trustmail.com" },
                    { 84, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7935), null, null, null, false, 5, null, null, "@relaymail.com" },
                    { 85, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7936), null, null, null, false, 5, null, null, "@newmailserver.com" },
                    { 86, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7937), null, null, null, false, 5, null, null, "@publicmail.com" },
                    { 87, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7938), null, null, null, false, 4, null, null, "Smith" },
                    { 88, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7939), null, null, null, false, 4, null, null, "Johnson" },
                    { 89, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7941), null, null, null, false, 4, null, null, "Williams" },
                    { 90, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7943), null, null, null, false, 4, null, null, "Brown" },
                    { 91, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7944), null, null, null, false, 4, null, null, "Jones" },
                    { 92, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7945), null, null, null, false, 4, null, null, "Garcia" },
                    { 93, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7946), null, null, null, false, 4, null, null, "Miller" },
                    { 94, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7947), null, null, null, false, 4, null, null, "Davis" },
                    { 95, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7948), null, null, null, false, 4, null, null, "Rodriguez" },
                    { 96, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7950), null, null, null, false, 4, null, null, "Martinez" },
                    { 97, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7951), null, null, null, false, 4, null, null, "Hernandez" },
                    { 98, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7952), null, null, null, false, 4, null, null, "Lopez" },
                    { 99, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7953), null, null, null, false, 4, null, null, "Gonzalez" },
                    { 100, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7954), null, null, null, false, 4, null, null, "Wilson" },
                    { 101, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7955), null, null, null, false, 4, null, null, "Anderson" },
                    { 102, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7957), null, null, null, false, 4, null, null, "Thomas" },
                    { 103, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7964), null, null, null, false, 4, null, null, "Taylor" },
                    { 104, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7966), null, null, null, false, 4, null, null, "Moore" },
                    { 105, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7967), null, null, null, false, 4, null, null, "Jackson" },
                    { 106, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7968), null, null, null, false, 4, null, null, "Martin" },
                    { 107, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7969), null, null, null, false, 4, null, null, "Lee" },
                    { 108, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7971), null, null, null, false, 4, null, null, "Perez" },
                    { 109, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7972), null, null, null, false, 4, null, null, "Thompson" },
                    { 110, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7974), null, null, null, false, 4, null, null, "White" },
                    { 111, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7977), null, null, null, false, 4, null, null, "Harris" },
                    { 112, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7978), null, null, null, false, 4, null, null, "Sanchez" },
                    { 113, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7979), null, null, null, false, 4, null, null, "Clark" },
                    { 114, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7980), null, null, null, false, 4, null, null, "Ramirez" },
                    { 115, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7981), null, null, null, false, 4, null, null, "Lewis" },
                    { 116, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7982), null, null, null, false, 4, null, null, "Robinson" },
                    { 1, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7790), null, null, 65, false, 2, null, null, "David" },
                    { 2, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7793), null, null, 66, false, 2, null, null, "Elizabeth" },
                    { 3, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7795), null, null, 65, false, 2, null, null, "Michael" },
                    { 4, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7796), null, null, 66, false, 2, null, null, "Sarah" },
                    { 5, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7797), null, null, 65, false, 2, null, null, "James" },
                    { 6, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7799), null, null, 66, false, 2, null, null, "Emily" },
                    { 7, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7800), null, null, 65, false, 2, null, null, "John" },
                    { 8, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7802), null, null, 66, false, 2, null, null, "Sophia" },
                    { 9, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7803), null, null, 65, false, 2, null, null, "Robert" },
                    { 10, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7804), null, null, 66, false, 2, null, null, "Olivia" },
                    { 11, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7806), null, null, 65, false, 2, null, null, "William" },
                    { 12, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7807), null, null, 66, false, 2, null, null, "Emma" },
                    { 13, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7808), null, null, 65, false, 2, null, null, "Thomas" },
                    { 14, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7810), null, null, 66, false, 2, null, null, "Charlotte" },
                    { 15, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7812), null, null, 65, false, 2, null, null, "Daniel" },
                    { 16, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7813), null, null, 66, false, 2, null, null, "Amelia" },
                    { 17, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7815), null, null, 65, false, 2, null, null, "Matthew" },
                    { 18, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7817), null, null, 66, false, 2, null, null, "Mia" },
                    { 19, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7820), null, null, 65, false, 2, null, null, "Joseph" },
                    { 20, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7821), null, null, 66, false, 2, null, null, "Isabella" },
                    { 21, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7823), null, null, 65, false, 2, null, null, "Charles" },
                    { 22, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7824), null, null, 66, false, 2, null, null, "Evelyn" },
                    { 23, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7826), null, null, 65, false, 2, null, null, "Christopher" },
                    { 24, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7829), null, null, 66, false, 2, null, null, "Harper" },
                    { 25, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7830), null, null, 65, false, 2, null, null, "Anthony" },
                    { 26, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7831), null, null, 66, false, 2, null, null, "Lily" },
                    { 27, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7833), null, null, 65, false, 2, null, null, "Andrew" },
                    { 28, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7834), null, null, 66, false, 2, null, null, "Grace" },
                    { 29, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7835), null, null, 65, false, 2, null, null, "Mark" },
                    { 30, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7837), null, null, 66, false, 2, null, null, "Hannah" },
                    { 31, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7841), null, null, 65, false, 2, null, null, "George" },
                    { 32, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7842), null, null, 66, false, 2, null, null, "Zoey" },
                    { 33, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7844), null, null, 65, false, 2, null, null, "Steven" },
                    { 34, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7845), null, null, 66, false, 2, null, null, "Stella" },
                    { 35, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7847), null, null, 65, false, 2, null, null, "Paul" },
                    { 36, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7848), null, null, 66, false, 2, null, null, "Layla" },
                    { 37, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7849), null, null, 65, false, 2, null, null, "Edward" },
                    { 38, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7851), null, null, 66, false, 2, null, null, "Ellie" },
                    { 117, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7984), null, null, 39, false, 6, null, null, "Istanbul" },
                    { 118, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7985), null, null, 39, false, 6, null, null, "Ankara" },
                    { 119, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7986), null, null, 39, false, 6, null, null, "Izmir" },
                    { 120, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7988), null, null, 40, false, 6, null, null, "New York" },
                    { 121, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7989), null, null, 40, false, 6, null, null, "Los Angeles" },
                    { 122, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7990), null, null, 40, false, 6, null, null, "Chicago" },
                    { 123, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7992), null, null, 43, false, 6, null, null, "Berlin" },
                    { 124, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7993), null, null, 43, false, 6, null, null, "Munich" },
                    { 125, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7994), null, null, 43, false, 6, null, null, "Hamburg" },
                    { 126, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7995), null, null, 44, false, 6, null, null, "Helsinki" },
                    { 127, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7997), null, null, 44, false, 6, null, null, "Espoo" },
                    { 128, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(7999), null, null, 44, false, 6, null, null, "Tampere" },
                    { 129, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8051), null, null, 45, false, 6, null, null, "London" },
                    { 130, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8052), null, null, 45, false, 6, null, null, "Manchester" },
                    { 131, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8054), null, null, 45, false, 6, null, null, "Birmingham" },
                    { 132, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8055), null, null, 46, false, 6, null, null, "Oslo" },
                    { 133, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8056), null, null, 46, false, 6, null, null, "Bergen" },
                    { 134, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8058), null, null, 46, false, 6, null, null, "Trondheim" },
                    { 135, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8059), null, null, 47, false, 6, null, null, "Warsaw" },
                    { 136, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8061), null, null, 47, false, 6, null, null, "Krakow" },
                    { 137, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8062), null, null, 47, false, 6, null, null, "Gdansk" },
                    { 138, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8063), null, null, 48, false, 6, null, null, "Moscow" },
                    { 139, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8065), null, null, 48, false, 6, null, null, "Saint Petersburg" },
                    { 140, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8066), null, null, 48, false, 6, null, null, "Novosibirsk" },
                    { 141, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8067), null, null, 49, false, 6, null, null, "Rio de Janeiro" },
                    { 142, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8069), null, null, 49, false, 6, null, null, "Sao Paulo" },
                    { 143, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8071), null, null, 49, false, 6, null, null, "Brasilia" },
                    { 144, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8072), null, null, 50, false, 6, null, null, "Beijing" },
                    { 145, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8074), null, null, 50, false, 6, null, null, "Shanghai" },
                    { 146, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8075), null, null, 50, false, 6, null, null, "Guangzhou" },
                    { 147, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8076), null, null, 51, false, 6, null, null, "Tokyo" },
                    { 148, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8078), null, null, 51, false, 6, null, null, "Osaka" },
                    { 149, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8079), null, null, 51, false, 6, null, null, "Yokohama" },
                    { 150, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8080), null, null, 52, false, 6, null, null, "Seoul" },
                    { 151, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8081), null, null, 52, false, 6, null, null, "Busan" },
                    { 152, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8083), null, null, 52, false, 6, null, null, "Incheon" },
                    { 153, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8084), null, null, 53, false, 6, null, null, "Rome" },
                    { 154, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8085), null, null, 53, false, 6, null, null, "Milan" },
                    { 155, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8087), null, null, 53, false, 6, null, null, "Florence" },
                    { 156, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8088), null, null, 54, false, 6, null, null, "Copenhagen" },
                    { 157, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8089), null, null, 54, false, 6, null, null, "Aarhus" },
                    { 158, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8091), null, null, 54, false, 6, null, null, "Odense" },
                    { 159, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8093), null, null, 55, false, 6, null, null, "Toronto" },
                    { 160, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8094), null, null, 55, false, 6, null, null, "Vancouver" },
                    { 161, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8095), null, null, 55, false, 6, null, null, "Montreal" },
                    { 162, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8097), null, null, 56, false, 6, null, null, "Mexico City" },
                    { 163, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8098), null, null, 56, false, 6, null, null, "Guadalajara" },
                    { 164, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8099), null, null, 56, false, 6, null, null, "Monterrey" },
                    { 165, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8101), null, null, 57, false, 6, null, null, "Mumbai" },
                    { 166, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8102), null, null, 57, false, 6, null, null, "Delhi" },
                    { 167, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8103), null, null, 57, false, 6, null, null, "Bangalore" },
                    { 168, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8104), null, null, 58, false, 6, null, null, "Cairo" },
                    { 169, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8106), null, null, 58, false, 6, null, null, "Alexandria" },
                    { 170, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8107), null, null, 58, false, 6, null, null, "Giza" },
                    { 171, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8108), null, null, 59, false, 6, null, null, "Singapore" },
                    { 172, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8110), null, null, 59, false, 6, null, null, "Jurong" },
                    { 173, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8111), null, null, 59, false, 6, null, null, "Tampines" },
                    { 174, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8112), null, null, 61, false, 6, null, null, "Zurich" },
                    { 175, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8114), null, null, 61, false, 6, null, null, "Geneva" },
                    { 176, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8115), null, null, 61, false, 6, null, null, "Basel" },
                    { 177, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8116), null, null, 62, false, 6, null, null, "Athens" },
                    { 178, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8118), null, null, 62, false, 6, null, null, "Thessaloniki" },
                    { 179, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8119), null, null, 62, false, 6, null, null, "Patras" },
                    { 180, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8120), null, null, 63, false, 6, null, null, "Brussels" },
                    { 181, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8122), null, null, 63, false, 6, null, null, "Antwerp" },
                    { 182, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8123), null, null, 63, false, 6, null, null, "Ghent" },
                    { 183, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8124), null, null, 64, false, 6, null, null, "Sofia" },
                    { 184, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8125), null, null, 64, false, 6, null, null, "Plovdiv" },
                    { 185, 0, new DateTime(2025, 1, 13, 22, 23, 37, 27, DateTimeKind.Local).AddTicks(8127), null, null, 64, false, 6, null, null, "Varna" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RandomDatas_DependentRandomDataId",
                table: "RandomDatas",
                column: "DependentRandomDataId");

            migrationBuilder.CreateIndex(
                name: "IX_RandomDatas_TypeId",
                table: "RandomDatas",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RandomDatas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "RandomDataTypes");
        }
    }
}
