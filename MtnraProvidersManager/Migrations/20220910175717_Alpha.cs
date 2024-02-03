using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MtnraProvidersManager_PAL.Migrations
{
    public partial class Alpha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FieldOfActivity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsSme = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Interlocutors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interlocutors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interlocutors_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Directions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExtendedName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InterlocutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directions_Interlocutors_InterlocutorId",
                        column: x => x.InterlocutorId,
                        principalTable: "Interlocutors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Directions_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommonRightContracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Year = table.Column<long>(type: "bigint", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonRightContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommonRightContracts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommonRightContracts_Directions_DirectionId",
                        column: x => x.DirectionId,
                        principalTable: "Directions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommonRightContracts_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvitationsToTender",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Object = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasLaunched = table.Column<bool>(type: "bit", nullable: false),
                    IsReservedForSme = table.Column<bool>(type: "bit", nullable: false),
                    Trimester = table.Column<int>(type: "int", nullable: false),
                    Nature = table.Column<int>(type: "int", nullable: false),
                    ExecutionLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Year = table.Column<long>(type: "bigint", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitationsToTender", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvitationsToTender_Directions_DirectionId",
                        column: x => x.DirectionId,
                        principalTable: "Directions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvitationsToTender_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Year = table.Column<long>(type: "bigint", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Directions_DirectionId",
                        column: x => x.DirectionId,
                        principalTable: "Directions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Markets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Object = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Estimation = table.Column<double>(type: "float", nullable: false),
                    LaunchedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProvisionalReception = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DefinitiveReception = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarrantyDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nature = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OriginalInvitationToTenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Year = table.Column<long>(type: "bigint", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DirectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Markets_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Markets_Directions_DirectionId",
                        column: x => x.DirectionId,
                        principalTable: "Directions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Markets_InvitationsToTender_OriginalInvitationToTenderId",
                        column: x => x.OriginalInvitationToTenderId,
                        principalTable: "InvitationsToTender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Markets_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MarketsStateHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MarketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketsStateHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketsStateHistory_Markets_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Markets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MarketsStateHistory_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddedBy", "CreatedOn", "FirstName", "HashedPassword", "LastName", "Role", "UpdatedOn", "Username" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), null, new DateTime(2022, 9, 10, 18, 57, 16, 915, DateTimeKind.Local).AddTicks(9768), "Mock", "$2a$12$N1WBrH9z10xi1OSrcgvG..3xMyWIMgaaO.f6CcC.r33Nhzn4Mm4ve", "Admin", "Admin", new DateTime(2022, 9, 10, 18, 57, 16, 915, DateTimeKind.Local).AddTicks(9829), "admin" });

            migrationBuilder.InsertData(
                table: "Interlocutors",
                columns: new[] { "Id", "AddedBy", "CreatedOn", "FirstName", "LastName", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("0583dc04-8226-4347-a2c8-c72da3f1ff8b"), new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(494), "Taoufik", "AZARUAL", new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(500) },
                    { new Guid("11bbfec4-f7f0-4fa0-8289-0dd682eb31df"), new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(459), "Jamal", "SALAHEDDINE", new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(467) },
                    { new Guid("7c09511c-dd8d-423e-9f6a-5cb458e1da53"), new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(511), "Sarah", "LAMRANI", new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(514) },
                    { new Guid("aa98af7a-45f0-4ad0-b0af-9594512a8481"), new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(415), "Mohamed", "MOUSSA", new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(423) },
                    { new Guid("de194360-4865-4a95-a8fe-a28fc4168643"), new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(479), "Aziz", "KHALLADI", new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(484) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddedBy", "CreatedOn", "FirstName", "HashedPassword", "LastName", "Role", "UpdatedOn", "Username" },
                values: new object[] { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 9, 10, 18, 57, 16, 915, DateTimeKind.Local).AddTicks(9870), "Mock", "$2a$12$G5zksm0jpyy63xRlG3NACuACiwJ13cX3uROX4UKrmVWI9lA4ZF60O", "Moderator", "Moderator", new DateTime(2022, 9, 10, 18, 57, 16, 915, DateTimeKind.Local).AddTicks(9872), "user" });

            migrationBuilder.InsertData(
                table: "Directions",
                columns: new[] { "Id", "Abbreviation", "AddedBy", "CreatedOn", "ExtendedName", "InterlocutorId", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("05497807-8c9d-4803-9898-9d4712bd1a05"), "DFP", new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(945), "Direction de la Fonction Publique", new Guid("0583dc04-8226-4347-a2c8-c72da3f1ff8b"), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(954) },
                    { new Guid("07783724-bb27-41e9-a751-7f627d2f4941"), "DMA", new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(897), "Direction de la Modernisation de l'Administration", new Guid("11bbfec4-f7f0-4fa0-8289-0dd682eb31df"), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(905) },
                    { new Guid("4e9d8e14-4ce6-4e34-bd98-30229687e2ee"), "DSI", new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(847), "Direction des Systèmes d'Information", new Guid("aa98af7a-45f0-4ad0-b0af-9594512a8481"), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(857) },
                    { new Guid("8e319ead-b98b-4e8e-81e4-74c05cc4df07"), "DECC", new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(981), "Direction des Études, de la Communication et de la Coopération", new Guid("7c09511c-dd8d-423e-9f6a-5cb458e1da53"), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(984) },
                    { new Guid("fcb05757-abaa-481f-acc7-1c93b9e676de"), "DRHF", new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(919), "Direction des Ressources Humaines et Financières", new Guid("de194360-4865-4a95-a8fe-a28fc4168643"), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(927) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommonRightContracts_AddedBy",
                table: "CommonRightContracts",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_CommonRightContracts_CompanyId",
                table: "CommonRightContracts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonRightContracts_DirectionId",
                table: "CommonRightContracts",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddedBy",
                table: "Companies",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Directions_AddedBy",
                table: "Directions",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Directions_InterlocutorId",
                table: "Directions",
                column: "InterlocutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Interlocutors_AddedBy",
                table: "Interlocutors",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationsToTender_AddedBy",
                table: "InvitationsToTender",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationsToTender_DirectionId",
                table: "InvitationsToTender",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_AddedBy",
                table: "Markets",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_CompanyId",
                table: "Markets",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_DirectionId",
                table: "Markets",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Markets_OriginalInvitationToTenderId",
                table: "Markets",
                column: "OriginalInvitationToTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketsStateHistory_AddedBy",
                table: "MarketsStateHistory",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MarketsStateHistory_MarketId",
                table: "MarketsStateHistory",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_AddedBy",
                table: "PurchaseOrders",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_CompanyId",
                table: "PurchaseOrders",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_DirectionId",
                table: "PurchaseOrders",
                column: "DirectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddedBy",
                table: "Users",
                column: "AddedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommonRightContracts");

            migrationBuilder.DropTable(
                name: "MarketsStateHistory");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Markets");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "InvitationsToTender");

            migrationBuilder.DropTable(
                name: "Directions");

            migrationBuilder.DropTable(
                name: "Interlocutors");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
