using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AymanFreelance.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BDataSchema");

            migrationBuilder.EnsureSchema(
                name: "ASecurity");

            migrationBuilder.CreateTable(
                name: "AppErrorTBLs",
                schema: "BDataSchema",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppErrorTBLs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CountryTBLs",
                schema: "BDataSchema",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTBLs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmailTBLs",
                schema: "BDataSchema",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTBLs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GenderTBLs",
                schema: "BDataSchema",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderTBLs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionTBLs",
                schema: "BDataSchema",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionTBLs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "ASecurity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypeTBLs",
                schema: "BDataSchema",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypeTBLs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "ASecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "ASecurity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "ASecurity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryTBLId = table.Column<int>(type: "int", nullable: true),
                    GenderTBLId = table.Column<int>(type: "int", nullable: true),
                    UserTypeTBLId = table.Column<int>(type: "int", nullable: true),
                    ProfessionTBLId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportOrNationalIdImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_CountryTBLs_CountryTBLId",
                        column: x => x.CountryTBLId,
                        principalSchema: "BDataSchema",
                        principalTable: "CountryTBLs",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_GenderTBLs_GenderTBLId",
                        column: x => x.GenderTBLId,
                        principalSchema: "BDataSchema",
                        principalTable: "GenderTBLs",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_ProfessionTBLs_ProfessionTBLId",
                        column: x => x.ProfessionTBLId,
                        principalSchema: "BDataSchema",
                        principalTable: "ProfessionTBLs",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_UserTypeTBLs_UserTypeTBLId",
                        column: x => x.UserTypeTBLId,
                        principalSchema: "BDataSchema",
                        principalTable: "UserTypeTBLs",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProjectTBLs",
                schema: "BDataSchema",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectOwnerTBLId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProjectFreelancerTBLId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HashCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredDaysOfDelivery = table.Column<int>(type: "int", nullable: true),
                    TotalCost = table.Column<int>(type: "int", nullable: true),
                    PaymentInAdvance = table.Column<int>(type: "int", nullable: true),
                    DateOfStartWork = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDelivery = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IncomeProfit = table.Column<int>(type: "int", nullable: true),
                    CreatedUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTBLs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectTBLs_Users_ProjectFreelancerTBLId",
                        column: x => x.ProjectFreelancerTBLId,
                        principalSchema: "ASecurity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectTBLs_Users_ProjectOwnerTBLId",
                        column: x => x.ProjectOwnerTBLId,
                        principalSchema: "ASecurity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "ASecurity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ASecurity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "ASecurity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ASecurity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "ASecurity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "ASecurity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ASecurity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "ASecurity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "ASecurity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FreelancerRatingTBLs",
                schema: "BDataSchema",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTBLId = table.Column<int>(type: "int", nullable: true),
                    AppUserWhoRatedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AppUserWhoIsRatedId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    ReviewSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHelpful = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreelancerRatingTBLs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FreelancerRatingTBLs_ProjectTBLs_ProjectTBLId",
                        column: x => x.ProjectTBLId,
                        principalSchema: "BDataSchema",
                        principalTable: "ProjectTBLs",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FreelancerRatingTBLs_Users_AppUserWhoIsRatedId",
                        column: x => x.AppUserWhoIsRatedId,
                        principalSchema: "ASecurity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FreelancerRatingTBLs_Users_AppUserWhoRatedId",
                        column: x => x.AppUserWhoRatedId,
                        principalSchema: "ASecurity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectApplicationTBLs",
                schema: "BDataSchema",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTBLId = table.Column<int>(type: "int", nullable: true),
                    AppUserWhoWroteId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaysOfDelivery = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: true),
                    PaymentInAdvance = table.Column<int>(type: "int", nullable: true),
                    CreatedUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectApplicationTBLs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectApplicationTBLs_ProjectTBLs_ProjectTBLId",
                        column: x => x.ProjectTBLId,
                        principalSchema: "BDataSchema",
                        principalTable: "ProjectTBLs",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProjectApplicationTBLs_Users_AppUserWhoWroteId",
                        column: x => x.AppUserWhoWroteId,
                        principalSchema: "ASecurity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerRatingTBLs_AppUserWhoIsRatedId",
                schema: "BDataSchema",
                table: "FreelancerRatingTBLs",
                column: "AppUserWhoIsRatedId");

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerRatingTBLs_AppUserWhoRatedId",
                schema: "BDataSchema",
                table: "FreelancerRatingTBLs",
                column: "AppUserWhoRatedId");

            migrationBuilder.CreateIndex(
                name: "IX_FreelancerRatingTBLs_ProjectTBLId",
                schema: "BDataSchema",
                table: "FreelancerRatingTBLs",
                column: "ProjectTBLId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectApplicationTBLs_AppUserWhoWroteId",
                schema: "BDataSchema",
                table: "ProjectApplicationTBLs",
                column: "AppUserWhoWroteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectApplicationTBLs_ProjectTBLId",
                schema: "BDataSchema",
                table: "ProjectApplicationTBLs",
                column: "ProjectTBLId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTBLs_ProjectFreelancerTBLId",
                schema: "BDataSchema",
                table: "ProjectTBLs",
                column: "ProjectFreelancerTBLId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTBLs_ProjectOwnerTBLId",
                schema: "BDataSchema",
                table: "ProjectTBLs",
                column: "ProjectOwnerTBLId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "ASecurity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "ASecurity",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "ASecurity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "ASecurity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "ASecurity",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "ASecurity",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryTBLId",
                schema: "ASecurity",
                table: "Users",
                column: "CountryTBLId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderTBLId",
                schema: "ASecurity",
                table: "Users",
                column: "GenderTBLId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfessionTBLId",
                schema: "ASecurity",
                table: "Users",
                column: "ProfessionTBLId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeTBLId",
                schema: "ASecurity",
                table: "Users",
                column: "UserTypeTBLId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "ASecurity",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppErrorTBLs",
                schema: "BDataSchema");

            migrationBuilder.DropTable(
                name: "EmailTBLs",
                schema: "BDataSchema");

            migrationBuilder.DropTable(
                name: "FreelancerRatingTBLs",
                schema: "BDataSchema");

            migrationBuilder.DropTable(
                name: "ProjectApplicationTBLs",
                schema: "BDataSchema");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "ASecurity");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "ASecurity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "ASecurity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "ASecurity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "ASecurity");

            migrationBuilder.DropTable(
                name: "ProjectTBLs",
                schema: "BDataSchema");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "ASecurity");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "ASecurity");

            migrationBuilder.DropTable(
                name: "CountryTBLs",
                schema: "BDataSchema");

            migrationBuilder.DropTable(
                name: "GenderTBLs",
                schema: "BDataSchema");

            migrationBuilder.DropTable(
                name: "ProfessionTBLs",
                schema: "BDataSchema");

            migrationBuilder.DropTable(
                name: "UserTypeTBLs",
                schema: "BDataSchema");
        }
    }
}
