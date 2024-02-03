using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MtnraProvidersManager_PAL.Migrations
{
    public partial class UnifyingStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "Id",
                keyValue: new Guid("05497807-8c9d-4803-9898-9d4712bd1a05"));

            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "Id",
                keyValue: new Guid("07783724-bb27-41e9-a751-7f627d2f4941"));

            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "Id",
                keyValue: new Guid("4e9d8e14-4ce6-4e34-bd98-30229687e2ee"));

            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "Id",
                keyValue: new Guid("8e319ead-b98b-4e8e-81e4-74c05cc4df07"));

            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "Id",
                keyValue: new Guid("fcb05757-abaa-481f-acc7-1c93b9e676de"));

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "CommonRightContracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Directions",
                columns: new[] { "Id", "Abbreviation", "AddedBy", "CreatedOn", "ExtendedName", "InterlocutorId", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("15ad0f48-31e2-4741-900d-67cfa414cfa4"), "DECC", new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5408), "Direction des Études, de la Communication et de la Coopération", new Guid("7c09511c-dd8d-423e-9f6a-5cb458e1da53"), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5411) },
                    { new Guid("44348fb1-3c7e-42a7-afc4-76ee3940140b"), "DMA", new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5374), "Direction de la Modernisation de l'Administration", new Guid("11bbfec4-f7f0-4fa0-8289-0dd682eb31df"), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5377) },
                    { new Guid("6fa2d638-5793-4606-8d3b-dd75783177c0"), "DFP", new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5396), "Direction de la Fonction Publique", new Guid("0583dc04-8226-4347-a2c8-c72da3f1ff8b"), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5399) },
                    { new Guid("8a9a5f15-b5f0-407b-8510-393b92f51a97"), "DRHF", new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5386), "Direction des Ressources Humaines et Financières", new Guid("de194360-4865-4a95-a8fe-a28fc4168643"), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5389) },
                    { new Guid("a4889f52-a618-4d89-ae0d-3e109e1af171"), "DSI", new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5315), "Direction des Systèmes d'Information", new Guid("aa98af7a-45f0-4ad0-b0af-9594512a8481"), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5323) }
                });

            migrationBuilder.UpdateData(
                table: "Interlocutors",
                keyColumn: "Id",
                keyValue: new Guid("0583dc04-8226-4347-a2c8-c72da3f1ff8b"),
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5002), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5010) });

            migrationBuilder.UpdateData(
                table: "Interlocutors",
                keyColumn: "Id",
                keyValue: new Guid("11bbfec4-f7f0-4fa0-8289-0dd682eb31df"),
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4954), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4964) });

            migrationBuilder.UpdateData(
                table: "Interlocutors",
                keyColumn: "Id",
                keyValue: new Guid("7c09511c-dd8d-423e-9f6a-5cb458e1da53"),
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5016), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(5022) });

            migrationBuilder.UpdateData(
                table: "Interlocutors",
                keyColumn: "Id",
                keyValue: new Guid("aa98af7a-45f0-4ad0-b0af-9594512a8481"),
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4901), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4915) });

            migrationBuilder.UpdateData(
                table: "Interlocutors",
                keyColumn: "Id",
                keyValue: new Guid("de194360-4865-4a95-a8fe-a28fc4168643"),
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4976), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4986) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4313), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4371) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4404), new DateTime(2022, 9, 14, 21, 21, 42, 115, DateTimeKind.Local).AddTicks(4415) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "Id",
                keyValue: new Guid("15ad0f48-31e2-4741-900d-67cfa414cfa4"));

            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "Id",
                keyValue: new Guid("44348fb1-3c7e-42a7-afc4-76ee3940140b"));

            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "Id",
                keyValue: new Guid("6fa2d638-5793-4606-8d3b-dd75783177c0"));

            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "Id",
                keyValue: new Guid("8a9a5f15-b5f0-407b-8510-393b92f51a97"));

            migrationBuilder.DeleteData(
                table: "Directions",
                keyColumn: "Id",
                keyValue: new Guid("a4889f52-a618-4d89-ae0d-3e109e1af171"));

            migrationBuilder.DropColumn(
                name: "State",
                table: "CommonRightContracts");

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

            migrationBuilder.UpdateData(
                table: "Interlocutors",
                keyColumn: "Id",
                keyValue: new Guid("0583dc04-8226-4347-a2c8-c72da3f1ff8b"),
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(494), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(500) });

            migrationBuilder.UpdateData(
                table: "Interlocutors",
                keyColumn: "Id",
                keyValue: new Guid("11bbfec4-f7f0-4fa0-8289-0dd682eb31df"),
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(459), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(467) });

            migrationBuilder.UpdateData(
                table: "Interlocutors",
                keyColumn: "Id",
                keyValue: new Guid("7c09511c-dd8d-423e-9f6a-5cb458e1da53"),
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(511), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(514) });

            migrationBuilder.UpdateData(
                table: "Interlocutors",
                keyColumn: "Id",
                keyValue: new Guid("aa98af7a-45f0-4ad0-b0af-9594512a8481"),
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(415), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(423) });

            migrationBuilder.UpdateData(
                table: "Interlocutors",
                keyColumn: "Id",
                keyValue: new Guid("de194360-4865-4a95-a8fe-a28fc4168643"),
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(479), new DateTime(2022, 9, 10, 18, 57, 16, 916, DateTimeKind.Local).AddTicks(484) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 9, 10, 18, 57, 16, 915, DateTimeKind.Local).AddTicks(9768), new DateTime(2022, 9, 10, 18, 57, 16, 915, DateTimeKind.Local).AddTicks(9829) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 9, 10, 18, 57, 16, 915, DateTimeKind.Local).AddTicks(9870), new DateTime(2022, 9, 10, 18, 57, 16, 915, DateTimeKind.Local).AddTicks(9872) });
        }
    }
}
